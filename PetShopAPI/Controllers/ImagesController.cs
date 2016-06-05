using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Hosting;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(Guid animalId)
        {
            HostingEnvironment path = new HostingEnvironment();
            path.MapPath("virtualPath");
            //DAL dal = new DAL();
            //return dal.GetImage(animalId);
            //var url = this.Url.Link("Default", new { Controller = "MyMvc", Action = "MyAction", param1 = 1, param2 = "somestring" });
            //return url;
            return "tmep";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
