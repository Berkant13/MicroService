using System;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController:ControllerBase
    {
        public PlatformsController()
        {
            
        }
        [HttpPost]
        public ActionResult TestInBoundConnection()
        {
            Console.WriteLine("------->Test");
            return Ok("Test");
        }
    }
}