using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShopSolution.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;

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
            try
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
                        //CategoryId = categoryId,
                        Category = context.Categories.Where(x => x.CategoryId == categoryId).First(),
                        Comments = null//<--noo comments on new animal
                    };
                    context.Animals.Add(entity);
                    context.SaveChanges();
                }
            }

            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
        }

        public List<Comment> GetCommentEntitiesByAnimalId(Guid animalId)
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                return context.Comments.Where(x => x.Animal.AnimalId == animalId).ToList();
            }
        }

        public Animal GetAnimalById(Guid animalId)
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                var entity = context.Animals.Where(x => x.AnimalId == animalId).FirstOrDefault();//.Include(x => x.Comments).FirstOrDefault(); - Include for eager loading
                return entity;
            }
        }

        public List<string> GetCommentsOfAnimalById(Guid animalId)
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                return context.Comments.Where(x => x.Animal.AnimalId == animalId).Select(x => x.Comment1).ToList();
            }
        }

        public void AddComment(Guid animalId, string comment)
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                Comment entity = new Comment()
                {
                    Animal = context.Animals.Where(x => x.AnimalId == animalId).First(),
                    Comment1 = comment
                };
                context.Comments.Add(entity);
                context.SaveChanges();
            }
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
                        CommentCount = context.Comments.Where(x => x.Animal.AnimalId == entity.AnimalId).Count()
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
                return context.Comments.Where(x => x.Animal.AnimalId == animalId).Select(x => x.Comment1).ToList<string>();
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
                return context.Animals.Where(animal => animal.Category.CategoryId == id).ToList<Animal>();
            }
        }

        public List<Animal> GetAnimalsInCategoryId(int categoryId)
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                return context.Animals.Where(animal => categoryId == animal.Category.CategoryId).ToList<Animal>();
            }
        }

        public void InsertComment(Guid animalId, string comment)
        {
            Comment entity = new Comment()
            {
                Animal = GetAnimalById(animalId),
                Comment1 = comment
            };
            using (PetShopEntities context = new PetShopEntities())
            {
                context.Comments.Add(entity);
                context.SaveChanges();
            }
        }

        public List<Animal> GetAnimalsInCategoryByName(string categoryName)
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                return context.Animals.Where(animal => animal.Category.Name == categoryName).ToList<Animal>();
            }
        }

        public void DeleteAnimal(Guid animalId)
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                var commentList = context.Comments.Where(x => x.AnimalId == animalId).ToList();
                Animal entity = context.Animals.Where(x => x.AnimalId == animalId).FirstOrDefault();
                context.Comments.RemoveRange(commentList);
                context.Animals.Remove(entity);//consider implementing single access to DB
                context.SaveChanges();
            }
        }

        //stupid animalName - NOT UNIQUE
        public void InsertComment(string animalName, string comment)
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                Animal entity = context.Animals.Where(x => x.Name == animalName).FirstOrDefault();
                context.Animals.Remove(entity);//consider implementing single access to DB
                context.SaveChanges();
            }
        }

        public Category GetAnimalCategory(Guid animalId)
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                return context.Categories.Select(category => category.Animals.Where(x => x.AnimalId == animalId).Select(c => c.Category).FirstOrDefault()).FirstOrDefault();
            }
        }

        public string GetCategoryNameById(int id)
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                return context.Categories.Where(c => c.CategoryId == id).Select(n => n.Name).FirstOrDefault();
            }
        }

        public void DeleteComment(Comment comment)
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                var entity = context.Comments.Where(x => x.CommentId == comment.CommentId).SingleOrDefault();
                context.Comments.Remove(entity);
                context.SaveChanges();
            }
        }

        public void UploadImage(Image image)
        {
            using (PetShopEntities context = new PetShopEntities())
            {
                if (context.Images.Where(img => img.animalId == image.animalId).Count() > 0)
                {
                    var original = context.Images.Find(image);
                    original.animalId = image.animalId;
                    original.image1 = image.image1;
                    context.SaveChanges();
                }
                else
                {
                    context.Images.Add(image);
                    context.SaveChanges();
                }
                
            }
        }
    }
}