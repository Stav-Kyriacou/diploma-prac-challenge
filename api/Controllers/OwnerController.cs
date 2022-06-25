using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Handlers;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : ControllerBase
    {
        private OwnerHandler dbHandler = new OwnerHandler();

        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("/owners")]
        public IEnumerable<Owner> Get()
        {
            return dbHandler.GetAllOwners();
        }
        /// <summary>
        /// Create a new owner
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="firstname"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        [HttpPost]
        [EnableCors("MyPolicy")]
        [Route("/create-owner")]
        public int CreateNewOwner(string surname, string firstname, int phone)
        {
            return dbHandler.CreateNewOwner(surname, firstname, phone);
        }
    }
}
