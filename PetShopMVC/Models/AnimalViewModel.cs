using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShopMVC.Models
{
    public class AnimalViewModel
    {
        public Guid AnimalId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string PictureName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}