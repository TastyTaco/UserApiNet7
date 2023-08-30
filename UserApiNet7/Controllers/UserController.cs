using Microsoft.AspNetCore.Mvc;
using UserApiNet7.Services.UserService;
using Serilog;

namespace UserApiNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserService> _logger;

        public UserController(IUserService userService, ILogger<UserService> logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            Log.Information("Retrieving all users");
            return await _userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            Log.Information("Retrieving user with Id: {@Id}", id);
            var result = await _userService.GetUserById(id);

            if (result is null)
            {
                return NotFound("User was not found.");
            }

            Log.Information("User retrieved: {@User}", result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            Log.Information("Creating new user: {@User}", user);
            var result = await _userService.CreateUser(user);

            return Ok(result);
        }
    }
}
