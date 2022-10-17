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
                Users.Add(new User("Jim", "Bob", "jimbob@jimbob.com", "jimbob123"));
                Users.Add(new User("Amanda", "Jones", "amandajones@amandajones.com", "amandajones123"));
            }
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Users;
        }

        [HttpPost]
        public void Post(User users)
        {
            Users.Add(users);
        }
    }
}