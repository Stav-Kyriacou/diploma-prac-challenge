using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Handlers;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        private PetHandler dbHandler = new PetHandler();

        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("/pets")]
        public IEnumerable<Pet> Get()
        {
            return dbHandler.GetAllPets();
        }
        /// <summary>
        /// Create pet
        /// </summary>
        /// <param name="ownerID"></param>
        /// <param name="petname"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPost]
        [EnableCors("MyPolicy")]
        [Route("/create-pet")]
        public int CreateNewOwner(int ownerID, string petname, string type)
        {
            return dbHandler.CreateNewPet(ownerID, petname, type);
        }
    }
}
