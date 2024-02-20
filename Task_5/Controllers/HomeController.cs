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
        IUserResponse _userResponse;
        public HomeController(IUserResponse userResponse)
        {

            _userResponse = userResponse;

        }

        [HttpPost]
        [Route("/Index")]
        public  IActionResult GetUsers([FromBody] UserSettings userSettings)
        {
            var user =  _userResponse.GetUsers(userSettings.seed, userSettings.region, userSettings.errorValue);
            return Ok(user);
        }
    }
}
