﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DogShowApp.Shared.Data;
using System.Globalization;

namespace DogShowApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BioController : Controller
    {
        //MUST be static to persist
        private static List<Bio> Bios { get; set; } = new List<Bio>();

        private readonly ILogger<BioController> _logger;


        // Don't think I will need any static bruh
        //private static DateOnly dateOnly = new DateOnly(2020, 04, 20);

        //private static TimeOnly timeOnly = new TimeOnly(10, 30);

        public BioController(ILogger<BioController> logger)
        {
            _logger = logger;

            if (Bios.Count == 0)
            {
                Bios.Add(new Bio("Sally", "Hungarian Blue Ball", "Brutus", "https://i0.wp.com/voiceofoc.org/wp-content/uploads/archive/editorial/5/2d/52dea990-2085-11e3-8b31-0019bb2963f4/5239ded32a185.image.jpg?w=460&ssl=1", "A wonderful very playful and well trained Hungarian Blue Ball. "));
                Bios.Add(new Bio("Cleetus McPaw", "German Shiza", "Rammstein von McBraun", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.pinimg.com%2F564x%2Fc6%2F60%2Ff9%2Fc660f9b3be0dba367ea009e192dbd24d.jpg&f=1&nofb=1&ipt=78421f4096cf7aefb6b2f0c474034a79e0000cde55070d10a141433114f2a607&ipo=images", "Best Tricks include tear hands and tear face. "));
                Bios.Add(new Bio("Dwayne", "Dual Head German Shiza", "Bo Peep", "https://www.aidedd.org/dnd/images/death-dog.jpg", "This guy has double teeth for double violence"));
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

        [HttpDelete]

        public void DeleteLast(Bio _bio) { Bios.Remove(_bio); }

        public void Delete() { }
        /*  We no need Datetimes in hya
    
        public TimeSpan AMorPM(string time)
        {
            DateTime dateTime = DateTime.ParseExact(time,
                                    "hh:mm tt", CultureInfo.InvariantCulture);
            TimeSpan span = dateTime.TimeOfDay;

            return span;
        }

        */
    }
}