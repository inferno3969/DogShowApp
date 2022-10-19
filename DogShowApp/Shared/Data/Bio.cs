using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogShowApp.Shared.Data
{
    public class Bio
    {
        public string? DogName { get; set; }
        public string? DogDescription { get; set; }
        public string? TrainerName { get; set; }
        public string? DogImageURL { get; set; }
        public string? TrainerImageURL { get; set; }

        public Bio(string? dogName, string? dogDescription, string? trainerName, string? dogImageURL, string? trainerImageURL)
        {
            this.DogName = dogName;
            this.DogDescription = dogDescription;
            this.TrainerName = trainerName;
            this.DogImageURL = dogImageURL;
            this.TrainerImageURL = trainerImageURL;
        }

        public Bio() { }

        public string? GetDogImageURL()
        {
            return DogImageURL;
        }
    }
}
