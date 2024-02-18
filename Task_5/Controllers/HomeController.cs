using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_5.Interfaces;
using Task_5.Models;
using Task_5.Services;

namespace Task_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        IDataGenerator _generator;
        public HomeController(IDataGenerator dataGenerator)
        {
            _generator = dataGenerator;
        }

        [HttpPost]
        [Route("/Index")]
        public IActionResult GetUsers([FromBody] UserSettings userSettings)
        {
            
            var user = _generator.GeneratePersons(userSettings.region, userSettings.seed);
            return Ok(user);
        }

        [HttpPost]
        [Route("/ErrorUsers")]
        public IActionResult GetUsersWithError(string region, int errorCount, int seed)
        {
            var _errorGenerator = new ErrorGenerator(seed, errorCount, region);

            return Ok();
        }
    }
}
