using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;
using System.Linq;
using System.Collections.Generic;

namespace ServerApp.Controllers
{
    //can be tested from
    ////https://localhost:5001/swagger/index.html
    [Route("api/word")]
    [ApiController]
    
    /// <summary>
    /// Service to check if word is feasible
    /// </summary>
    public class WordValueController : Controller
    {
        public WordValueController()
        {
        }

        [HttpPost]
        /// <summary>
        /// Handles POST request to verify word
        /// </summary>
        /// <param name="word">Submitted Word to be checked</param>
        /// <returns>OK response with result or BadRequest response</returns>
        public IActionResult GetWord([FromBody] SubmittedWord word)
        {
            if(ModelState.IsValid)
            {
                if(word.GeneratedBoard!=null)
                {
                    WordFeasibilityChecker wordVerifier = new WordFeasibilityChecker(word.GeneratedBoard);
                    if(wordVerifier.IsWordFeasible(word.WordValue))
                    {
                        if(WordValidator.IsWordInDict(word.WordValue))
                            return Ok(true);
                        else
                            return Ok(false);
                    }
                    else
                        return Ok(false);
                }
                else
                    return BadRequest(ModelState);
            }
            else
                return BadRequest(ModelState);
        }
    }
}