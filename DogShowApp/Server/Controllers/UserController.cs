using Microsoft.AspNetCore.Mvc;
using DogShowApp.Shared.Data;

namespace DogShowApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        //MUST be static to persist
        private static List<User> Users { get; set; } = new List<User>();

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;

            if (Users.Count == 0)
            {
                Users.Add(new User("Jim", "Bob", "jimbo123", "jimbob@jimbob.com", "jimbob123", false));
                Users.Add(new User("Amanda", "Jones", "amandajones22", "amandajones@amandajones.com", "amandajones123", false));
                Users.Add(new User("Admin", "Admin", "bigchungusadmin420", "admin@admin.com", "admin420", true));
            }
        }

        [HttpGet]
        public IEnumerable<User> Get(string? username, string? password)
        {
            if (username == null && password == null)
            {
                return Users;
            }
            else
            {
                foreach (User user in Users)
                {
                    if (user.Username == username && user.Password == password)
                    {
                        List<User> temp = new List<User>();
                        temp.Add(user);
                        return temp;
                    }
                }
                return null!; 
            }
        }

        [HttpPost]
        public void Post(User users)
        {
            Users.Add(users);
        }
    }
}