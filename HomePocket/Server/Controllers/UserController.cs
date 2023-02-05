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
            return users;
            
        }


        [HttpPut("UpdateProfile/{id}")]
        public async Task<User> UpdateProfile(int id,User user)
        {

            User userToUpdate = await _context.Users.Where(u => u.UserId == user.UserId).FirstOrDefaultAsync();

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.EmailAddress = user.EmailAddress;

            await _context.SaveChangesAsync();

            return await Task.FromResult(user);
        }

        [HttpGet("getprofile/{userId}")]
        public async Task<User> GetProfile(int userId)
        {
            return await _context.Users.Where(u => u.UserId == userId).FirstOrDefaultAsync();
        }

        [HttpPut("UpdateNotifications/{id}/{notification}")]
        public async Task<User> UpdateNotifications(int id,long notification)
        {

            User user = await _context.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();

            user.Notifications = notification;
            await _context.SaveChangesAsync();
            return await Task.FromResult(user);
        }

        [HttpPut("UpdateTheme/{id}/{theme}")]
        public async Task<User> UpdateTheme(int id,long theme)
        {

            User user = await _context.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();

            user.DarkTheme = theme;
            await _context.SaveChangesAsync();
            return await Task.FromResult(user);
        }




    }
}