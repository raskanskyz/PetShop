﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetShopSolution.PetShopDALService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PetShopDALService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetCommentsList", ReplyAction="http://tempuri.org/IService1/GetCommentsListResponse")]
        PetShopDAL.Comment[] GetCommentsList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetCommentsList", ReplyAction="http://tempuri.org/IService1/GetCommentsListResponse")]
        System.Threading.Tasks.Task<PetShopDAL.Comment[]> GetCommentsListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetCategoryEntities", ReplyAction="http://tempuri.org/IService1/GetCategoryEntitiesResponse")]
        PetShopDAL.Category[] GetCategoryEntities();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetCategoryEntities", ReplyAction="http://tempuri.org/IService1/GetCategoryEntitiesResponse")]
        System.Threading.Tasks.Task<PetShopDAL.Category[]> GetCategoryEntitiesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/InsertAnimal", ReplyAction="http://tempuri.org/IService1/InsertAnimalResponse")]
        void InsertAnimal(string animalName, int age, string pictureName, string description, string categoryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/InsertAnimal", ReplyAction="http://tempuri.org/IService1/InsertAnimalResponse")]
        System.Threading.Tasks.Task InsertAnimalAsync(string animalName, int age, string pictureName, string description, string categoryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetCategories", ReplyAction="http://tempuri.org/IService1/GetCategoriesResponse")]
        string[] GetCategories();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetCategories", ReplyAction="http://tempuri.org/IService1/GetCategoriesResponse")]
        System.Threading.Tasks.Task<string[]> GetCategoriesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AnimalsList", ReplyAction="http://tempuri.org/IService1/AnimalsListResponse")]
        PetShopDAL.Animal[] AnimalsList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AnimalsList", ReplyAction="http://tempuri.org/IService1/AnimalsListResponse")]
        System.Threading.Tasks.Task<PetShopDAL.Animal[]> AnimalsListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAnimalsOrderedByCommentCount", ReplyAction="http://tempuri.org/IService1/GetAnimalsOrderedByCommentCountResponse")]
        PetShopSolution.Models.Rating[] GetAnimalsOrderedByCommentCount();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAnimalsOrderedByCommentCount", ReplyAction="http://tempuri.org/IService1/GetAnimalsOrderedByCommentCountResponse")]
        System.Threading.Tasks.Task<PetShopSolution.Models.Rating[]> GetAnimalsOrderedByCommentCountAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateAnimal", ReplyAction="http://tempuri.org/IService1/UpdateAnimalResponse")]
        void UpdateAnimal(System.Guid animalId, string animalName, int age, string pictureName, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateAnimal", ReplyAction="http://tempuri.org/IService1/UpdateAnimalResponse")]
        System.Threading.Tasks.Task UpdateAnimalAsync(System.Guid animalId, string animalName, int age, string pictureName, string description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/InsertCategory", ReplyAction="http://tempuri.org/IService1/InsertCategoryResponse")]
        void InsertCategory(string categoryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/InsertCategory", ReplyAction="http://tempuri.org/IService1/InsertCategoryResponse")]
        System.Threading.Tasks.Task InsertCategoryAsync(string categoryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetCommentsOfAnimal", ReplyAction="http://tempuri.org/IService1/GetCommentsOfAnimalResponse")]
        string[] GetCommentsOfAnimal(string animalName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetCommentsOfAnimal", ReplyAction="http://tempuri.org/IService1/GetCommentsOfAnimalResponse")]
        System.Threading.Tasks.Task<string[]> GetCommentsOfAnimalAsync(string animalName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : PetShopSolution.PetShopDALService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<PetShopSolution.PetShopDALService.IService1>, PetShopSolution.PetShopDALService.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PetShopDAL.Comment[] GetCommentsList() {
            return base.Channel.GetCommentsList();
        }
        
        public System.Threading.Tasks.Task<PetShopDAL.Comment[]> GetCommentsListAsync() {
            return base.Channel.GetCommentsListAsync();
        }
        
        public PetShopDAL.Category[] GetCategoryEntities() {
            return base.Channel.GetCategoryEntities();
        }
        
        public System.Threading.Tasks.Task<PetShopDAL.Category[]> GetCategoryEntitiesAsync() {
            return base.Channel.GetCategoryEntitiesAsync();
        }
        
        public void InsertAnimal(string animalName, int age, string pictureName, string description, string categoryName) {
            base.Channel.InsertAnimal(animalName, age, pictureName, description, categoryName);
        }
        
        public System.Threading.Tasks.Task InsertAnimalAsync(string animalName, int age, string pictureName, string description, string categoryName) {
            return base.Channel.InsertAnimalAsync(animalName, age, pictureName, description, categoryName);
        }
        
        public string[] GetCategories() {
            return base.Channel.GetCategories();
        }
        
        public System.Threading.Tasks.Task<string[]> GetCategoriesAsync() {
            return base.Channel.GetCategoriesAsync();
        }
        
        public PetShopDAL.Animal[] AnimalsList() {
            return base.Channel.AnimalsList();
        }
        
        public System.Threading.Tasks.Task<PetShopDAL.Animal[]> AnimalsListAsync() {
            return base.Channel.AnimalsListAsync();
        }
        
        public PetShopSolution.Models.Rating[] GetAnimalsOrderedByCommentCount() {
            return base.Channel.GetAnimalsOrderedByCommentCount();
        }
        
        public System.Threading.Tasks.Task<PetShopSolution.Models.Rating[]> GetAnimalsOrderedByCommentCountAsync() {
            return base.Channel.GetAnimalsOrderedByCommentCountAsync();
        }
        
        public void UpdateAnimal(System.Guid animalId, string animalName, int age, string pictureName, string description) {
            base.Channel.UpdateAnimal(animalId, animalName, age, pictureName, description);
        }
        
        public System.Threading.Tasks.Task UpdateAnimalAsync(System.Guid animalId, string animalName, int age, string pictureName, string description) {
            return base.Channel.UpdateAnimalAsync(animalId, animalName, age, pictureName, description);
        }
        
        public void InsertCategory(string categoryName) {
            base.Channel.InsertCategory(categoryName);
        }
        
        public System.Threading.Tasks.Task InsertCategoryAsync(string categoryName) {
            return base.Channel.InsertCategoryAsync(categoryName);
        }
        
        public string[] GetCommentsOfAnimal(string animalName) {
            return base.Channel.GetCommentsOfAnimal(animalName);
        }
        
        public System.Threading.Tasks.Task<string[]> GetCommentsOfAnimalAsync(string animalName) {
            return base.Channel.GetCommentsOfAnimalAsync(animalName);
        }
    }
}