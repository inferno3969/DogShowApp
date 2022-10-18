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
                //Bios.Add(new Bio("Cleetus McPaw", "German Shiza", "Rammstein von McBraun", "http://mydogsimage.com/mydog.jpg", "http://mytrainersimage.com/mytrainer.jpg"));
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
