namespace DogShowApp.Shared.Data
{
    public class Event
    {
        public string? Date { get; set; }

        public string? Time { get; set; }

        public string? EventName { get; set; }

        public string? EventDescription { get; set; }

        public Event(string date, string time, string eventName, string eventDescription)
        {
            this.Date = date;
            this.Time = time;
            this.EventName = eventName;
            this.EventDescription = eventDescription;
        }

        public Event() { }
    }
}