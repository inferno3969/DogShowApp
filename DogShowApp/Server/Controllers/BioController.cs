using Microsoft.AspNetCore.Http;
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
                Bios.Add(new Bio("Sally", "Struthers", "Brutus", "https://www.quotationof.com/images/eric-wareheim-6.jpg", "https://www.quotationof.com/images/eric-wareheim-6.jpg"));
               // Bios.Add(new Bio("Cleetus McPaw", "German Shiza", "Rammstein von McBraun", "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi.pinimg.com%2F564x%2Fc6%2F60%2Ff9%2Fc660f9b3be0dba367ea009e192dbd24d.jpg&f=1&nofb=1&ipt=78421f4096cf7aefb6b2f0c474034a79e0000cde55070d10a141433114f2a607&ipo=images", "img/IMG_4018.jpg"));
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
