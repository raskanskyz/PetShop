using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShopMVC.Models
{
    public class RatingViewModel
    {
        public AnimalViewModel Animal { get; set; }
        public int CommentCount { get; set; }
    }
}