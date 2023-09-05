using Microsoft.AspNetCore.Mvc;
using Synonyms.Models;

namespace Synonyms.Controllers
{
    public class HomeController : Controller
    {
        private static SynonymDict _Synonyms = new SynonymDict();

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Request req)
        {
            if(req.word != null && req.synonym != null)
            {
                List<string> synonyms = req.synonym.Split(',').ToList();
                _Synonyms.Add(req.word, synonyms);

                return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get(string word)
        {
            return Json(_Synonyms.GetSynonyms(word));
        }
    }

    public class Request
    {
        public string word { get; set; }
        public string synonym { get; set; }
    }
}
