using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;
using System.Collections.Generic;

namespace ServerApp.Controllers
{
    //can be tested from
    //https://localhost:5001/swagger/index.html
    [Route("api/solver")]
    [ApiController]

    /// <summary>
    /// Service to get requests for board
    /// </summary>
    public class BoggleSolverController : Controller
    {
        public BoggleSolverController()
        {}

        [HttpPost]
        public IActionResult SolveBoard(Board board)
        {
            if(ModelState.IsValid)
            {
            if(board!=null && board.GeneratedBoard!=null)
            {
                BoggleSolver solver = new BoggleSolver();
                solver.InitializeBoard(board.GeneratedBoard);
                solver.SolveBoard();

                HashSet<string> words= solver.wordList;

                List<string> wordList = new List<string>(words);
                wordList.Sort();

                return Ok(wordList);
            }
            else
                return Ok(new List<string>());
            }
            else
                return BadRequest(ModelState);

        }
    }
}