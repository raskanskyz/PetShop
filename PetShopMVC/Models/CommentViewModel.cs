using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShopMVC.Models
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public Guid AnimalId { get; set; }
        public string Comment1 { get; set; }

        public AnimalViewModel Animal { get; set; }
    }
}