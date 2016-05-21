using AutoMapper;
using PetShopMVC.Models;
using PetShopMVC.PetShopDALService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShopMVC.Controllers
{
    public class CatalogController : Controller
    {
        // GET: Catalog
        public ActionResult Index()
        {
            List<AnimalViewModel> result = new List<AnimalViewModel>();
            using (Service1Client dalService = new Service1Client())
            {
                foreach (Animal item in dalService.AnimalsList())
                {
                    result.Add(Mapper.Map<Animal, AnimalViewModel>(item));
                }
                var entities = dalService.GetCategoryEntities();

                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem
                {
                    Text = "---select a category---",
                    Selected = true,
                    Value = "0"
                });
                items.AddRange(entities.Select(x => new SelectListItem
                {
                    Value = x.CategoryId.ToString(),
                    Text = x.Name
                }).ToList());
                ViewBag.CategoriesSelectList = items;
            }
            return View("Index", result);
        }

        public ActionResult Administrator(string email, string password)
        {
            Animal temp = new Animal();
            return Index();
        }

        public ActionResult AnimalDetails(Guid animalId)
        {
            AnimalViewModel model;
            using (Service1Client dalService = new Service1Client())
            {
                var entity = dalService.GetAnimalById(animalId);
                model = Mapper.Map<Animal, AnimalViewModel>(entity);
            }
            return View("AnimalDetails", model);
        }

        [HttpPost]
        public ActionResult AddComment(Guid animalId, string comment)
        {
            using (Service1Client dalService = new Service1Client())
            {
                dalService.AddComment(animalId, comment);
            }
            return ViewComments(animalId);
        }

        //[ActionName(name: "comments")]
        public ActionResult ViewComments(Guid animalId)
        {
            List<CommentViewModel> viewModels = new List<CommentViewModel>();
            List<Comment> entities;
            using (Service1Client dalService = new Service1Client())
            {
                entities = dalService.GetCommentEntitiesByAnimalId(animalId);
                foreach (var entity in entities)
                {
                    viewModels.Add(Mapper.Map<Comment, CommentViewModel>(entity));
                }
            }
            return PartialView("CommentsListPartial", viewModels);
        }

        public ActionResult Categories()
        {
            List<CategoryViewModel> list = new List<CategoryViewModel>();
            using (Service1Client dalService = new Service1Client())
            {
                var entities = dalService.GetCategoryEntities();
                foreach (var entity in entities)
                {
                    list.Add(Mapper.Map<Category, CategoryViewModel>(entity));
                }
                return PartialView("CategoryNamesPartial", list);
            }
        }

        public ActionResult GetAnimalsInCategory(int categoryId)
        {
            List<AnimalViewModel> result = new List<AnimalViewModel>();
            using (Service1Client dalService = new Service1Client())
            {
                List<Animal> entities = dalService.GetAnimalsInCategoryId(categoryId);
                foreach (var entity in entities)
                {
                    result.Add(Mapper.Map<Animal, AnimalViewModel>(entity));
                }
                return PartialView("GetAnimalsInCategoryPartial", result);
            }
        }

        public ActionResult GetAnimalsInCategoryByName(string categoryName)
        {
            List<AnimalViewModel> result = new List<AnimalViewModel>();
            using (Service1Client dalService = new Service1Client())
            {
                List<Animal> entities = dalService.GetAnimalsInCategoryByName(categoryName);
                foreach (var entity in entities)
                {
                    result.Add(Mapper.Map<Animal, AnimalViewModel>(entity));
                }
                return PartialView("GetAnimalsInCategoryPartial", result);
            }
        }

        public ActionResult GetAllAnimals()
        {
            List<AnimalViewModel> result = new List<AnimalViewModel>();
            using (Service1Client dalService = new Service1Client())
            {
                List<Animal> entities = dalService.AnimalsList();
                foreach (var entity in entities)
                {
                    result.Add(Mapper.Map<Animal, AnimalViewModel>(entity));
                }
                return PartialView("GetAnimalsInCategoryPartial", result);
            }
        }

        //[HttpPut]
        public void AddAnimal(AnimalViewModel model)
        {
            Animal entity = Mapper.Map<AnimalViewModel, Animal>(model);
            using (Service1Client dalService = new Service1Client())
            {
                dalService.InsertAnimal(entity.Name, entity.Age, entity.PictureName, entity.Description, entity.Category.Name);
            }
        }

        public ActionResult UpdateAnimal(AnimalViewModel model)
        {
            return null;
        }

        public ActionResult DeleteAnimal(Guid animalId)
        {
            using (Service1Client dalService = new Service1Client())
            {
                dalService.DeleteAnimal(animalId);
            }
            return GetAllAnimals();
        }
    }
}