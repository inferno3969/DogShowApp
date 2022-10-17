using Microsoft.AspNetCore.Mvc;
using DogShowApp.Shared.Data;
using System.Globalization;


namespace DogShowApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        //MUST be static to persist
        private static List<Event> Events { get; set; } = new List<Event>();

        private readonly ILogger<EventController> _logger;

        private static DateOnly dateOnly = new DateOnly(2020, 04, 20);

        private static TimeOnly timeOnly = new TimeOnly(10, 30);

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;

            if (Events.Count == 0)
            {
                Events.Add(new Event("12/22/2022", "12:00 PM", "Test", "Test"));
            }
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return Events;
        }

        [HttpPost]
        public void Post(Event _event)
        {
            Events.Add(_event);
        }

        public TimeSpan AMorPM(string time)
        {
            DateTime dateTime = DateTime.ParseExact(time,
                                    "hh:mm tt", CultureInfo.InvariantCulture);
            TimeSpan span = dateTime.TimeOfDay;

            return span;
        }
    }
}