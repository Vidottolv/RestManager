using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestManager.Services;

namespace RestManager.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


    }
}
