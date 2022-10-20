using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DogShowApp.Shared.Data;
using System.Globalization;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text.Json;

namespace DogShowApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BioController : Controller
    {
        //MUST be static to persist
        private static List<Bio> Bios { get; set; } = new List<Bio>();

        private readonly ILogger<BioController> _logger;

        public BioController(ILogger<BioController> logger)
        {
            _logger = logger;

            if (Bios.Count == 0)
            {
                Bios.Add(new Bio("Brutus", "Hungarian Blue Ball", "Billy Jo Armstrong", "https://i0.wp.com/voiceofoc.org/wp-content/uploads/archive/editorial/5/2d/52dea990-2085-11e3-8b31-0019bb2963f4/5239ded32a185.image.jpg?w=460&ssl=1", "A wonderful very playful and well trained Hungarian Blue Ball. "));
                Bios.Add(new Bio("Cleetus McPaw", "German Shiza", "Rammstein von McBraun", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.pinimg.com%2F564x%2Fc6%2F60%2Ff9%2Fc660f9b3be0dba367ea009e192dbd24d.jpg&f=1&nofb=1&ipt=78421f4096cf7aefb6b2f0c474034a79e0000cde55070d10a141433114f2a607&ipo=images", "Best Tricks include tear hands and tear face. "));
                Bios.Add(new Bio("Dwayne", "Dual Headed Long Hair German Shiza", "Till Lunderson", "https://www.aidedd.org/dnd/images/death-dog.jpg", "This guy has double teeth for double violence"));
                Bios.Add(new Bio("Alvarez", "Little Shitzu", "Robert Kraft", "https://i.guim.co.uk/img/media/a10a67810303b0389ef6c75b2468156448377f16/0_30_6000_3600/master/6000.jpg?width=620&quality=85&dpr=1&s=none", "Don't judge a book by it's cover. This guy can consume flesh pound for pound at a higher rate than any other breed"));



            }
        }

        [HttpGet]
        public IEnumerable<Bio> Get()
        {
            return Bios;
        }

        [HttpPost]
        public void Post(Bio _bio)
        {
            Bios.Add(_bio);
        }

        [HttpPut]
        public void Put(string? item)
        { 
            Bio newBio = new Bio();
            int subscript = Convert.ToInt32(item); 
            
            Bios[subscript] = newBio;
        }
        [HttpDelete]
        public void Delete(string? item)
        {
       
        Bios.RemoveAt(Convert.ToInt32(item));
        }
    }
}

