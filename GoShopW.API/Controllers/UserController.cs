using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoShopW.Contracts;
using GoShopW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GoShopW.Controllers
{
    /// <summary>
    /// Endpoint which facilitate user data fetching via <see cref="IUserService"/>.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(
            IUserService userService,
            ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            return new JsonResult(this._userService.GetUser());
        }
    }
}
