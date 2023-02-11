 using HomePocket.Server.Context;
using HomePocket.Shared.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HomePocket.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> _logger;
        private readonly ChatDbContext _context;

        public AuthController(ILogger<AuthController> logger,ChatDbContext context)
        {
            _logger = logger;
            _context = context;
            
        }


        [HttpGet("LogOutUser")]
		public async Task<ActionResult> LogOutUser()
		{
			await HttpContext.SignOutAsync();
			return Ok();
        }

		[HttpGet("GetCurrentUser")]
		public async Task<ActionResult<User>> GetCurrentUser()
		{
            var currentUser = new User();
            if (!User.Identity.IsAuthenticated)
                return Ok(currentUser);

            currentUser.EmailAddress = User.FindFirstValue(ClaimTypes.Name);
            return Ok(currentUser);
		}


		[HttpPost("LoginUser")]
        public async Task<ActionResult<User>> LoginUser(User user)
        {
            //Review access with crypted password
            var loggedUser = await _context.Users.Where(u => u.EmailAddress == user.EmailAddress && u.Password == user.Password).FirstOrDefaultAsync();
            if (loggedUser is null)
                return BadRequest();

            //create claim
            var claim = new Claim(ClaimTypes.Name, loggedUser.EmailAddress);
            var claimsIdentity = new ClaimsIdentity(new[] { claim }, "serverAuth");
            var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrinciple);
			return Ok(user);
        }




    }
}