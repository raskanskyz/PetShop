using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShopMVC.Models
{
    public class AnimalViewModel
    {
        public System.Guid AnimalId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string PictureName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryViewModel Category { get; set; }
        public virtual ICollection<CategoryViewModel> Comments { get; set; }
    }
}