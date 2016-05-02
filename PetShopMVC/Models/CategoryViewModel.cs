using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShopMVC.Models
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            AnimalViewModels = new List<AnimalViewModel>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public List<AnimalViewModel> AnimalViewModels { get; set; }
    }
}