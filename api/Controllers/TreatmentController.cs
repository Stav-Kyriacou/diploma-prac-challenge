using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Handlers;
using Microsoft.AspNetCore.Cors;
using System;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TreatmentController : ControllerBase
    {
        private TreatmentHandler dbHandler = new TreatmentHandler();

        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("/treatments")]
        public IEnumerable<Treatment> Get()
        {
            return dbHandler.GetAllTreatments();
        }
        /// <summary>
        /// Create a treatment
        /// </summary>
        /// <param name="ownerID"></param>
        /// <param name="petID"></param>
        /// <param name="procedureID"></param>
        /// <param name="date"></param>
        /// <param name="notes"></param>
        /// <param name="payment"></param>
        /// <returns></returns>
        [HttpPost]
        [EnableCors("MyPolicy")]
        [Route("/create-treatment")]
        public int CreateNewOwner(int ownerID, int petID, int procedureID, DateTime date, string notes, float payment)
        {
            return dbHandler.CreateNewTreatment(ownerID, petID, procedureID, date, notes, payment);
        }
    }
}
