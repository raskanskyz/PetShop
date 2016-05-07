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
            }
            return View(result);
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
    }
}