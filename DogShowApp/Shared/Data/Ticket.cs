using System;
namespace DogShowApp.Shared.Data
{
    public class Ticket
    {
        public string regularTicket { get; set; } = "regular ticket";

        public string seasonTicket { get; set; } = "season ticket";

        public int? numOfRegularTickets { get; set; }

        public int? numOfSeasonTickets { get; set; }

        public static decimal regularTicketsPrice { get; set; } = 10.00m;

        public static decimal seasonTicketsPrice { get; set; } = 100.00m;

        public Ticket()
        {
        }
    }
}

