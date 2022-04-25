using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using MODELS;
using MODELS.ApiModels;
using MODELS.DataModels;
using Data;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Golf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : Controller
    {
        private readonly ICosmosDbService _cosmosDbService;
        public ClubController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        // GET: api/values
        [Route("newClub")]
        [HttpPost]
        public ActionResult<Task<Club>> NewClub(ApiClub new_club)
        {
            var res = _cosmosDbService.AddClub(new_club);
            if (res == null)
                return BadRequest(new { msg = "Something went wrong." });

            return Ok(res.Result);

        }


        
    }
}

