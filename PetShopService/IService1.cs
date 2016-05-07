using PetShopDAL;
using PetShopSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PetShopService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Comment> GetCommentsList();

        [OperationContract]
        List<Category> GetCategoryEntities();

        [OperationContract]
        void InsertAnimal(string animalName, int age, string pictureName, string description, string categoryName);

        [OperationContract]
        List<string> GetCategories();//<--GetCategoryEntities() returns objects

        [OperationContract]
        List<Animal> AnimalsList();

        [OperationContract]
        List<Rating> GetAnimalsOrderedByCommentCount();//<--might need dataContract

        [OperationContract]
        void UpdateAnimal(Guid animalId, string animalName, int age, string pictureName, string description);

        [OperationContract]
        void InsertCategory(string categoryName);

        [OperationContract]
        List<string> GetCommentsOfAnimal(string animalName);

        [OperationContract]
        List<string> GetCommentsOfAnimalById(Guid animalId);

        [OperationContract]
        List<Comment> GetCommentEntitiesByAnimalId(Guid animalId);

        [OperationContract]
        Animal GetAnimalById(Guid animalId);

        [OperationContract]
        void AddComment(Guid animalId, string comment);

        [OperationContract]
        List<Animal> GetAnimalsInCategoryId(int categoryId);
    }
}
