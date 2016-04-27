using PetShopSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopDAL
{
    interface IPetShopDAL
    {
        void DeleteAllTables();
        void InsertCategory(string CategoryName);
        void InsertAnimal(string animalName, int age, string pictureName, string description, string categoryName);
        void UpdateAnimal(Guid animalId, string animalName, int age, string pictureName, string description);
        void InsertComment(string animalName, string comment);
        List<string> GetCategories();
        List<Animal> GetAnimalsInCategory(string categoryName);
        List<string> GetCommentsOfAnimal(string animalName);
        List<Rating> GetAnimalsOrderedByCommentCount();
    }
}
