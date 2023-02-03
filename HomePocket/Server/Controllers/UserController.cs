 using HomePocket.Server.Context;
using HomePocket.Shared;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<Contact> Get()
        {
            var users = _context.Users.ToList();
            var contacts = new List<Contact>();
            foreach (var item in users)
            {
                contacts.Add(new Contact((int)item.UserId, item.FirstName, item.LastName));
            }


            return contacts;           
        }
    }
}