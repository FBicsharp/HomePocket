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

        //[HttpGet]
        //public IEnumerable<Contact> Get()
        //{
        //    var users = _context.Users.ToList();
        //    var contacts = new List<Contact>();
        //    foreach (var item in users)
        //    {
        //        contacts.Add(new Contact((int)item.UserId, item.FirstName, item.LastName));
        //    }


        //    return contacts;
        //}
        [HttpGet]
        public List<Contact> Get()
        {
            List<User> users = _context.Users.ToList();
            List<Contact> contacts = new List<Contact>();

            foreach (var user in users)
            {
                contacts.Add(new Contact(user.FirstName, user.LastName));
            }
            return contacts;
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
    }
}