using AutoMapper;
using PetShopMVC.Models;
using PetShopMVC.PetShopDALService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShopMVC.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Rating, RatingViewModel>();
                cfg.CreateMap<RatingViewModel, Rating>();
                cfg.CreateMap<Animal, AnimalViewModel>();
                cfg.CreateMap<AnimalViewModel, Animal>();
                cfg.CreateMap<Comment, CommentViewModel>();
                cfg.CreateMap<CommentViewModel, Comment>();
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<CategoryViewModel, Category>();
            });
        }
    }
}