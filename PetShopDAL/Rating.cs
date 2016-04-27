using PetShopDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PetShopSolution.Models
{
    [DataContract]
    public class Rating
    {
        [DataMember]
        public Animal Animal { get; set; }

        [DataMember]
        public int CommentCount { get; set; }
    }
}