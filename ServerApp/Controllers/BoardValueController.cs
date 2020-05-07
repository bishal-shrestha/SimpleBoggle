using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;

namespace ServerApp.Controllers
{
    [Route("api/board")]
    [ApiController]
    public class BoardValueController : Controller
    {
        

        public BoardValueController()
        {
            
        }

        [HttpGet]
        public Board GetBoard()
        {
            BoardGenerator board = new BoardGenerator();
            
            return new Board() {
                    GeneratedBoard=board.GenerateBoard()
                } ;
        }
    }
}