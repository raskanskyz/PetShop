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
            return View(model);
        }

        public ActionResult AddComment(Guid animalId, string comment)
        {
            AnimalViewModel model;
            using (Service1Client dalService = new Service1Client())
            {
                dalService.AddComment(animalId, comment);
                //change implementation; try not to call dalService for animal
                model = Mapper.Map<Animal, AnimalViewModel>(dalService.GetAnimalById(animalId));
            }
            return View("AnimalDetails", model);
        }
    }
}