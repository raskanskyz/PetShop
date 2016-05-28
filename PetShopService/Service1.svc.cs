using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PetShopDAL;
using PetShopSolution.Models;

namespace PetShopService
{
    public class Service1 : IService1
    {
        public List<Animal> AnimalsList()
        {
            DAL dal = new DAL();
            return dal.AnimalsList();
        }

        public List<Rating> GetAnimalsOrderedByCommentCount()
        {
            DAL dal = new DAL();
            return dal.GetAnimalsOrderedByCommentCount();
        }

        public List<string> GetCategories()
        {
            DAL dal = new DAL();
            return dal.GetCategories();
        }

        public List<Category> GetCategoryEntities()
        {
            DAL dal = new DAL();
            return dal.GetCategoryEntities();
        }

        public List<Comment> GetCommentsList()
        {
            DAL dal = new DAL();
            return dal.GetCommentsList();
        }

        public List<string> GetCommentsOfAnimal(string animalName)
        {
            DAL dal = new DAL();
            return dal.GetCommentsOfAnimal(animalName);
        }

        public List<string> GetCommentsOfAnimalById(Guid animalId)
        {
            DAL dal = new DAL();
            return dal.GetCommentsOfAnimalById(animalId);
        }

        public List<Comment> GetCommentEntitiesByAnimalId(Guid animalId)
        {
            DAL dal = new DAL();
            return dal.GetCommentEntitiesByAnimalId(animalId);
        }

        public Animal GetAnimalById(Guid animalId)
        {
            DAL dal = new DAL();
            return dal.GetAnimalById(animalId);
        }

        public void InsertAnimal(string animalName, int age, string pictureName, string description, string categoryName)
        {
            DAL dal = new DAL();
            dal.InsertAnimal(animalName, age, pictureName, description, categoryName);
        }

        public void InsertCategory(string categoryName)
        {
            DAL dal = new DAL();
            dal.InsertCategory(categoryName);
        }

        public void UpdateAnimal(Guid animalId, string animalName, int age, string pictureName, string description)
        {
            DAL dal = new DAL();
            dal.UpdateAnimal(animalId, animalName, age, pictureName, description);
        }

        public void AddComment(Guid animalId, string comment)
        {
            DAL dal = new DAL();
            dal.AddComment(animalId, comment);
        }

        public List<Animal> GetAnimalsInCategoryId(int categoryId)
        {
            DAL dal = new DAL();
            return dal.GetAnimalsInCategoryId(categoryId);
        }

        public List<Animal> GetAnimalsInCategoryByName(string categoryName)
        {
            DAL dal = new DAL();
            return dal.GetAnimalsInCategoryByName(categoryName);
        }

        public void DeleteAnimal(Guid animalId)
        {
            DAL dal = new DAL();
            dal.DeleteAnimal(animalId);
        }

        public Category GetAnimalCategory(Guid animalId)
        {
            DAL dal = new DAL();
            return dal.GetAnimalCategory(animalId);
        }

        public string GetCategoryNameById(int id)
        {
            DAL dal = new DAL();
            return dal.GetCategoryNameById(id);
        }
    }
}
