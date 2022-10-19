using System;
using System.ComponentModel.DataAnnotations;

namespace DogShowApp.Shared.Data
{
    public class Ticket
    {
        public string regularTicket { get; set; } = "regular ticket";

        public string seasonTicket { get; set; } = "season ticket";

        [MinLength(0, ErrorMessage = "You can't have negative amount of tickets.")]
        public int numOfRegularTickets { get; set; }

        [MinLength(0, ErrorMessage = "You can't have negative amount of tickets.")]
        public int numOfSeasonTickets { get; set; }

        public decimal regularTicketsPrice { get; set; } = 10.00m;

        public decimal seasonTicketsPrice { get; set; } = 100.00m;

        public Ticket()
        {
        }
    }
}

