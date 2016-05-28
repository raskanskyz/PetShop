using AutoMapper;
using PetShopMVC.Models;
using PetShopMVC.PetShopDALService;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PetShopMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Feel free to contact to for any questions regarding technologies used for building this web application";
            return View();
        }

        public ActionResult TopRatedAnimals()
        {
            List<RatingViewModel> result = new List<RatingViewModel>();
            
            using (Service1Client service = new Service1Client())
            {
                List<Rating> list = service.GetAnimalsOrderedByCommentCount();
                foreach (var item in list)
                {
                    result.Add(Mapper.Map<Rating, RatingViewModel>(item));
                }
            }
            return PartialView("TopRatedPartial", result.Take(2).ToList());
        }
    }
}