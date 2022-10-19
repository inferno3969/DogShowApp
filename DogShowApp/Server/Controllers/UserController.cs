using Microsoft.AspNetCore.Mvc;
using DogShowApp.Shared.Data;
using DogShowApp.Shared;
using UserNS = DogShowApp.Shared.Data;
using System.Text.Json;
using System.Reflection;
using Microsoft.Extensions.Hosting;

namespace DogShowApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        //MUST be static to persist
        private static List<UserNS.User> Users { get; set; } = new List<UserNS.User>();

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;

            if (Users.Count == 0)
            {
                Users.Add(new UserNS.User("Jim", "Bob", "jimbo123", "jimbob@jimbob.com", "jimbob123", false));
                Users.Add(new UserNS.User("Amanda", "Jones", "amandajones22", "amandajones@amandajones.com", "amandajones123", false));
                Users.Add(new UserNS.User("Admin", "Admin", "bigchungusadmin420", "admin@admin.com", "admin420", true));
            }
        }

        [HttpGet]
        public IEnumerable<UserNS.User> Get(string? username, string? password)
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

        [HttpPut]
        public void Put(Tuple<Int32, List<Object?>> properties)
        {
            User newUser = new User();
            PropertyInfo[] prop = newUser.GetType().GetProperties();

            for (int i = 0; i < properties.Item2.Count; i++)
            {
                if (properties.Item2[i] != null && properties.Item2[i].GetType() == typeof(JsonElement))
                {
                    if (prop[i].PropertyType == typeof(String))
                    {
                        prop[i].SetValue(newUser, properties.Item2[i].ToString());
                    }
                    else if (prop[i].PropertyType == typeof(Boolean))
                    {
                        prop[i].SetValue(newUser, Convert.ToBoolean(properties.Item2[i].ToString()));
                    }
                    else if (prop[i].PropertyType == typeof(Int32))
                    {
                        prop[i].SetValue(newUser, Convert.ToInt32(properties.Item2[i].ToString()));
                    }
                }
            }
            Users.RemoveAt(properties.Item1);
            Users.Insert(properties.Item1, newUser);
        }

        [HttpPost]
        public void Post(User users)
        {
            Users.Add(users);
        }

        [HttpDelete]
        public void Delete(String item)
        {
            Users.RemoveAt(Convert.ToInt32(item));
        }
    }
}