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
            this.AnimalViewModels = new HashSet<AnimalViewModel>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AnimalViewModel> AnimalViewModels { get; set; }
    }
}