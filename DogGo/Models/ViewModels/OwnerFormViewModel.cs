using System.Collections.Generic;

namespace DogGo.Models.ViewModels
{
    public class OwnerFormViewModel
    {
        public Dog dog { get; set; }

        public List<Dog> Dog { get; set; }

        public List<Neighborhood> Neighborhood { get; set; }

        public List<Walker> Walkers { get; set; }

        public Owner Owner { get; set; }

        public string ErrorMessage { get; set; }
    }
}