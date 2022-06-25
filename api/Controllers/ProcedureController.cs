using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Handlers;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcedureController : ControllerBase
    {
        private ProcedureHandler dbHandler = new ProcedureHandler();

        [HttpGet]
        [Route("/procedures")]
        public IEnumerable<Procedure> Get()
        {
            return dbHandler.GetAllProcedures();
        }
    }
}
