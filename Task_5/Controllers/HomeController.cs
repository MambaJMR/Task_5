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

        [HttpGet]
        public IActionResult GetUsers()
        {
            var user = _generator.GeneratePerson("ru", 1);
            var test = user[0].FirstName.ToString();


            return Ok(test);
        }
    }
}
