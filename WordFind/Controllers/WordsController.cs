using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WordFind.Drivers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WordFind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly WordFinder _wordFinder;

        public WordsController(WordFinder wordFinder)
        {
            _wordFinder = wordFinder;
        }

        [HttpGet]
        public ActionResult Get([FromQuery(Name = "from")] string letterSet)
        {
            if (string.IsNullOrWhiteSpace(letterSet))
            {
                return this.BadRequest("you must provide a set of letters to search with the 'from' query parameter");
            }

            return this.Ok(_wordFinder.FindAllWords(letterSet));
        }

    }
}
