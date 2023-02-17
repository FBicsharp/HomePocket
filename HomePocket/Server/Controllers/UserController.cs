 using HomePocket.Server.Context;
using HomePocket.Shared;
using HomePocket.Shared.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomePocket.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly ChatDbContext _context;

        public UserController(ILogger<UserController> logger,ChatDbContext context)
        {
            _logger = logger;
            _context = context;
            
        }

        [HttpGet]
        public async Task<List<User>> GetAllUser()
        {
            List<User> users = await _context.Users.ToListAsync();
            List<Contact> contacts = new List<Contact>();
            for (int i = 0; i < 20000; i++)
            {
                users.Add(new User() { FirstName = "name" + i, EmailAddress = "mail" + i, UserId = i + 999, LastName = "" });
            }


            return users;
            
        }
		[HttpGet("GetVisibleUser")]
		public async Task<List<User>> GetVisibleUser(int startsIndex,int count)
		{
            List<User> users = new();// await _context.Users.ToListAsync();
			for(int i = 0; i < 20000; i++)
            {
				users.Add(new User() { FirstName = "name" + i, EmailAddress = "mail" + i, UserId = i + 999, LastName = "" });
			}
			return users.Skip(startsIndex).Take(count).ToList();

		}


		[HttpPut("UpdateProfile/{id}")]
        public async Task<User> UpdateProfile(int id,User user)
        {

            User userToUpdate = await _context.Users.Where(u => u.UserId == user.UserId).FirstOrDefaultAsync();
            if(userToUpdate == null)  
                return new User();
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.EmailAddress = user.EmailAddress;

            await _context.SaveChangesAsync();

            return await Task.FromResult(user);
        }

        [HttpGet("getprofile/{userId}")]
        public async Task<User> GetProfile(int userId)
        {
            var user = await _context.Users.Where(u => u.UserId == userId).FirstOrDefaultAsync();
            user ??= new User();            
            return user;
        }

        [HttpPut("UpdateNotifications/{id}/{notification}")]
        public async Task<User> UpdateNotifications(int id,long notification)
        {

            User user = await _context.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();
            if(user == null)  
                return new User();
            user.Notifications = notification;
            await _context.SaveChangesAsync();
            return await Task.FromResult(user);
        }

        [HttpPut("UpdateTheme/{id}/{theme}")]
        public async Task<User> UpdateTheme(int id,long theme)
        {

            User user = await _context.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();
            if(user == null)  
                return new User();
            user.DarkTheme = theme;
            await _context.SaveChangesAsync();
            return await Task.FromResult(user);
        }




    }
}