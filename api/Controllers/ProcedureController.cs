using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Handlers;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcedureController : ControllerBase
    {
        private ProcedureHandler dbHandler = new ProcedureHandler();

        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("/procedures")]
        public IEnumerable<Procedure> Get()
        {
            return dbHandler.GetAllProcedures();
        }
    }
}
