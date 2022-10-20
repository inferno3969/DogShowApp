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

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;

            if (Events.Count == 0)
            {
                Events.Add(new Event("12/22/2022", "12:00 PM", "Dog Olympics", "Dogs will compete in a dog-styled olympics."));
                Events.Add(new Event("1/14/2023", "5:00 PM", "Who's The Best Dog?", "Dogs will compete over various events to find out who is the best dog!"));
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

        [HttpPut]
        public void Put(Tuple<Int32, Event> putStuff)
        {
            Events.RemoveAt(putStuff.Item1);
            Events.Insert(putStuff.Item1, putStuff.Item2);
        }
    }
}