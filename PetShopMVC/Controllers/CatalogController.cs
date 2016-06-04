using AutoMapper;
using PetShopMVC.Models;
using PetShopMVC.PetShopDALService;
using System;
using System.Collections.Generic;
using System.IO;
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
                    var category = Mapper.Map<Category, CategoryViewModel>(dalService.GetAnimalCategory(item.AnimalId));
                    AnimalViewModel model = Mapper.Map<Animal, AnimalViewModel>(item);
                    model.Category = category;
                    result.Add(model);
                }
                PopulateDropDownList(dalService);
            }
            return View("Index", result.OrderBy(animal => animal.Name));
        }

        [ActionName(name: "AdministratorLogin")]
        public ActionResult Administrator()
        {
            return View("Administrator");
        }

        [ActionName(name: "Administrator")]
        public ActionResult Administrator(string inputEmail, string inputPassword)
        {
            //TODO: iplement authentication
            if (inputEmail == "mcsd2016@gmail.com" && inputPassword == "mcsd2016@gmail.com")
            {
                HttpContext.Session.Add("IsAdmin", true);
            }
            return RedirectToAction("Index");
        }

        public ActionResult AnimalDetails(Guid animalId)
        {
            AnimalViewModel model;
            using (Service1Client dalService = new Service1Client())
            {
                var entity = dalService.GetAnimalById(animalId);
                var category = Mapper.Map<Category, CategoryViewModel>(dalService.GetAnimalCategory(animalId));
                model = Mapper.Map<Animal, AnimalViewModel>(entity);
                model.Category = category;
            }
            return View("AnimalDetails", model);
        }

        public JsonResult AnimalDetailsJson(Guid animalId)
        {
            AnimalViewModel model;
            using (Service1Client dalService = new Service1Client())
            {
                var entity = dalService.GetAnimalById(animalId);
                model = Mapper.Map<Animal, AnimalViewModel>(entity);
            }
            return Json(new { result = model }, JsonRequestBehavior.AllowGet);
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
            ModelState.Clear();//used to clear entity state so comments can get updated values. alternative is using explicit hiddent input instead of @Html.Hidden
            return PartialView("CommentsListPartial", viewModels);
        }
        [HttpPost]
        public ActionResult DeleteComment(Comment comment)
        {
            using (Service1Client dalService = new Service1Client())
            {
                dalService.DeleteComment(comment);
            }
            return ViewComments(comment.AnimalId);
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
                return PartialView("GetAnimalsInCategoryPartial", result.OrderByDescending(x => x.Name));
            }
        }

        //[HttpPut]
        public void AddAnimal(AnimalViewModel model)
        {
            Animal entity = Mapper.Map<AnimalViewModel, Animal>(model);
            string categoryName = string.Empty;

            //TODO: not modular
            switch (entity.CategoryId)
            {
                case 1:
                    categoryName = "Mamal";
                    break;
                case 2:
                    categoryName = "Reptile";
                    break;
                case 3:
                    categoryName = "Aquatic";
                    break;
                default:
                    break;
            }
            using (Service1Client dalService = new Service1Client())
            {
                dalService.InsertAnimal(entity.Name, entity.Age, entity.PictureName, entity.Description, categoryName);
            }
        }

        public ActionResult UpdateAnimal(AnimalViewModel model)
        {
            using (Service1Client dalService = new Service1Client())
            {
                dalService.UpdateAnimal(model.AnimalId, model.Name, model.Age, model.PictureName, model.Description);
            }
            return GetAnimalsInCategory(model.CategoryId);
        }

        public ActionResult DeleteAnimal(Guid animalId)
        {
            using (Service1Client dalService = new Service1Client())
            {
                dalService.DeleteAnimal(animalId);
            }
            return GetAllAnimals();
        }

        public string GetCategoryNameById(int id)
        {
            using (Service1Client dalService = new Service1Client())
            {
                return dalService.GetCategoryNameById(id);
            }
        }

        private void PopulateDropDownList(Service1Client dalService)
        {
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
                Text = x.Name,
            }).ToList());
            ViewBag.CategoriesSelectList = items;
        }

        public ActionResult UploadImage(Guid animalId)
        {

            //bool isSavedSuccessfully = true;
            string fName = "";

            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fileName];
                //Save file content goes here
                fName = file.FileName;
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream target = new MemoryStream();
                    file.InputStream.CopyTo(target);

                    Picture tmp = new Picture()
                    {
                        pictureId = Guid.NewGuid(),
                        image = target.ToArray(),
                        animalId = animalId
                    };
                    using (Service1Client dalService = new Service1Client())
                    {
                        dalService.UploadImage(tmp);
                        // TODO: attach image loacation to animal pictureName
                    }

                    //var originalDirectory = new System.IO.DirectoryInfo(string.Format("{0}Images\\WallImages", Server.MapPath(@"\")));
                    //string pathString = System.IO.Path.Combine(originalDirectory.ToString(), "imagepath");
                    //var fileName1 = System.IO.Path.GetFileName(file.FileName);
                    //bool isExists = System.IO.Directory.Exists(pathString);
                    //if (!isExists)
                    //    System.IO.Directory.CreateDirectory(pathString);
                    //var path = string.Format("{0}\\{1}", pathString, file.FileName);
                    //file.SaveAs(path);
                }

            }
            return Index();
        }
    }
}