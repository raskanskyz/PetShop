using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShopMVC.Models
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public System.Guid AnimalId { get; set; }
        public string Comment1 { get; set; }

        public virtual AnimalViewModel Animal { get; set; }
    }
}