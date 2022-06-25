using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Handlers;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : ControllerBase
    {
        private OwnerHandler dbHandler = new OwnerHandler();

        [HttpGet]
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
        [Route("/create-owner")]
        public int CreateNewOwner(string surname, string firstname, int phone)
        {
            return dbHandler.CreateNewOwner(surname, firstname, phone);
        }
    }
}
