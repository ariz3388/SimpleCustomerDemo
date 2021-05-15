using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleCustomerDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IConfiguration config;

        public CustomerController(IConfiguration configuration)
        {
            config = configuration;
        }

        [HttpGet]
        public string Get(int Id = 0)
        {            
            Logic.CustomerManager manager = new Logic.CustomerManager(new Database.CustomerDemoContext(config));
            Id = Math.Abs(Id);

            if (Id != 0) return JsonConvert.SerializeObject(manager.GetById(Id));
            else return JsonConvert.SerializeObject(manager.GetList(x => x.Id > 0).OrderBy(x => x.LastName));
        }

        [HttpPost]
        public string Post(Database.Customer entity)
        {            
            if (entity != null)
            {
                if (entity != new Database.Customer())
                {
                    Logic.CustomerManager manager = new Logic.CustomerManager(new Database.CustomerDemoContext(config));
                    if (manager.AddUpdate(entity)) return "{\"UpdateStatus\":\"COMPLETE\"}";
                    else return "{\"UpdateStatus\":\"FAIL\"}";
                }
            }

            return "{\"UpdateStatus\":\"INVALID\"}";
        }
    }
}
