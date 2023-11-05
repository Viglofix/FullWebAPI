using DataBase;
using DataBase.Models;
using DataBase.Services;
using FullWebAPI.ScopeData;
using FullWebAPI.SingletonData;
using FullWebAPI.TransientData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MorenController : ControllerBase
    {
        private readonly IMorenService _morenService;
        private readonly MorenDatabaseDbContext _db;

        public MorenController(IMorenService _morenService, MorenDatabaseDbContext _db)
        {
            this._morenService = _morenService;
            this._db = _db;
        }
          [HttpGet("/Moren")]
          public async Task<IActionResult> GetHeroes()
          {
            //System.NotSupportedException: Serialization and deserialization of
            //'System.Action' instances are not supported. Path: $.MoveNextAction.
            // await is the only method to deserialize or serialize service or repository
            var objToReturn = _morenService.GetAll();
            if(objToReturn.Result.Count == 0)
            {
                return NotFound("Empty List");
            }
            return Ok(await objToReturn);
          }
         [HttpGet("/Moren/{id}")]
         public async Task<IActionResult> GetHero(int id)
         {
            var objToReturn = _morenService.GetSingle(id);
            if(objToReturn is null)
            {
                return NotFound(objToReturn);
            }
            return Ok(await objToReturn);
         }

          [HttpPost("/Moren")]
          public async Task<IActionResult> CreateHero([FromBody]AutoMapperMorenHeroes obj)
          {
            var objToReturn = _morenService.Create(obj);
            if(objToReturn is null)
            {
                return NotFound();
            }
            return Ok(await objToReturn);
          }
          [HttpPut("/Moren/{id}")]
          public async Task<IActionResult> PutHero([FromBody]AutoMapperMorenHeroes obj, int id)
          {
            var objToReturn = _morenService.Put(obj, id);
            if(objToReturn is null)
            {
                return NotFound();
            }
            return Ok(await objToReturn);
          }
        // Uwazaj na Http Verbs 
        // Microsoft.AspNetCore.Routing.Matching.AmbiguousMatchException: The request matched multiple endpoints. Matches: 
        [HttpDelete("/Moren/{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var objToReturn = _morenService.Delete(id);
            if (objToReturn is null)
            {
                return NotFound();
            }
            return Ok(await objToReturn);
        }


         /* [HttpGet]
          public async Task<IActionResult> GetLocations()
          {
             var objToReturn = _morenService.GetAllLocations();
             if (objToReturn is null)
             {
                return NotFound();
             }
             return Ok(await objToReturn);
          } */
      } 
    }
