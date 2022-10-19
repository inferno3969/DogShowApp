using System;
using System.ComponentModel.DataAnnotations;

namespace DogShowApp.Shared.Data
{
    public class Ticket
    {

        [MinLength(0, ErrorMessage = "You can't have negative amount of tickets.")]
        public int numOfEventTickets { get; set; }

        [MinLength(0, ErrorMessage = "You can't have negative amount of tickets.")]
        public int numOfSeasonTickets { get; set; }

        public decimal eventTicketsPrice { get; set; } = 10.00m;

        public decimal seasonTicketsPrice { get; set; } = 100.00m;

        public Ticket()
        {
        }
    }
}

