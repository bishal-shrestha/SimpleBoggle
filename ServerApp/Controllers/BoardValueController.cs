using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;

namespace ServerApp.Controllers
{
    //can be tested from
    //https://localhost:5001/api/board
    //https://localhost:5001/swagger/index.html
    [Route("api/board")]
    [ApiController]

    /// <summary>
    /// Service to get requests for board
    /// </summary>
    public class BoardValueController : Controller
    {
        public BoardValueController()
        {
        }

        [HttpGet]
        /// <summary>
        /// Handles GET requests
        /// </summary>
        /// <returns>Board configuration</returns>
        public Board GetBoard()
        {
            BoardGenerator board = new BoardGenerator();
            
            return new Board() {
                    GeneratedBoard = board.GenerateBoard()
                } ;
        }
    }
}