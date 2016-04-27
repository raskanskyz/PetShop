using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShopSolution.Models;

namespace PetShopDAL
{
    public class DAL : IPetShopDAL
    {
        #region used in console

        public List<Comment> GetCommentsList()
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                return context.Comments.ToList<Comment>();
            }
        }

        public List<Category> GetCategoryEntities()
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                return context.Categories.ToList<Category>();
            }
        }

        public void InsertAnimal(string animalName, int age, string pictureName, string description, string categoryName)
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                var categoryId = context.Categories.Where(x => x.Name == categoryName).Select(x => x.CategoryId).FirstOrDefault();
                Animal entity = new Animal()
                {
                    AnimalId = Guid.NewGuid(),
                    Name = animalName,
                    Age = age,
                    PictureName = pictureName,
                    Description = description,
                    CategoryId = categoryId,
                    Category = context.Categories.Where(x => x.CategoryId == categoryId).First(),
                    Comments = null//<--noo comments on new animal
                };
                context.Animals.Add(entity);
                context.SaveChanges();
            }//{"Violation of PRIMARY KEY constraint 'PK_Categories'. Cannot insert duplicate key in object 'dbo.Categories'. The duplicate key value is (1).\r\nThe statement has been terminated."}
        }

        public List<string> GetCategories()
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                return context.Categories.Select(x => x.Name).ToList<string>();
            }
        }

        public List<Animal> AnimalsList()
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                return context.Animals.ToList();
            }
        }

        public List<Rating> GetAnimalsOrderedByCommentCount()
        {
            List<Rating> result = new List<Rating>();
            using (PetShopEntities context = new PetShopEntities())
            {
                foreach (Animal entity in context.Animals.ToList())
                {
                    Rating rating = new Rating()
                    {
                        Animal = entity,
                        CommentCount =5// context.Comments.Where(x => x.AnimalId == entity.AnimalId).ToList().Count// entity.Comments.Count//getting error when counting via context.Comments.Where(x => x.AnimalId == entity.AnimalId).ToList().Count
                    };
                    result.Add(rating);
                }
            }
            return result.OrderByDescending(x => x.CommentCount).ToList();
        }

        public void UpdateAnimal(Guid animalId, string animalName, int age, string pictureName, string description)
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                var original = context.Animals.Find(animalId);

                if (original != null)
                {
                    original.Name = animalName;
                    original.Age = age;
                    original.PictureName = pictureName;
                    original.Description = description;
                    context.SaveChanges();
                }
            }
        }

        public void InsertCategory(string CategoryName)
        {
            Category entity = new Category()
            {
                Name = CategoryName,
                Animals = GetAnimalsInCategory(CategoryName),
            };
            using (PetShopEntities context = new PetShopEntities())
            {
                context.Categories.Add(entity);
                context.SaveChanges();
            }
        }

        public List<string> GetCommentsOfAnimal(string animalName)//<--why by name? names can repeat
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                var animalId = GetAnimalIdFromName(animalName);
                return context.Comments.Where(x => x.AnimalId == animalId).Select(x => x.Comment1).ToList<string>();
            }
        }

        #endregion

        #region my helper methods

        public bool IsAnimalNew(Guid animalId)
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                return context.Animals.Find(animalId) == null ? true : false;
            }
        }

        private Guid GetAnimalIdFromName(string animalName)
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                return context.Animals.Where(x => x.Name == animalName).Select(x => x.AnimalId).FirstOrDefault();
            }
        }

        #endregion

        public void DeleteAllTables()
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                // disable all foreign keys
                context.Database.ExecuteSqlCommand("EXEC sp_MSforeachtable @command1 = 'ALTER TABLE ? NOCHECK CONSTRAINT all'");

                bool tryAgain = true;

                // need to perform multiple drop attempts due to the possibility of linked foreign key data
                while (tryAgain)
                {
                    try
                    {
                        // drop tables
                        context.Database.ExecuteSqlCommand("EXEC sp_MSforeachtable @command1 = 'DROP TABLE ?'");

                        // remove try again flag
                        tryAgain = false;
                    }
                    catch { } // ignore errors as these are expected due to linked foreign key data
                }
            }
        }

        public List<Animal> GetAnimalsInCategory(string categoryName)
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                var id = context.Categories.Where(cat => cat.Name == categoryName).Select(cat => cat.CategoryId).FirstOrDefault();
                return context.Animals.Where(animal => animal.CategoryId == id).ToList<Animal>();
            }
        }

        public void InsertComment(string animalName, string comment)
        {
            Comment entity = new Comment()
            {
                AnimalId = GetAnimalIdFromName(comment),
                Comment1 = comment
            };
            using (PetShopEntities context = new PetShopEntities())
            {
                context.Comments.Add(entity);
                context.SaveChanges();
            }
        }
    }
}