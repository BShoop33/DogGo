using System.Collections.Generic;

namespace DogGo.Models.ViewModels
{
    public class OwnerFormViewModel
    {
        public Owner Owner { get; set; }
        public List<Neighborhood> Neighborhood { get; set; }

        public List<Dog> Dog { get; set; }
        public List<Walker> Walkers { get; set; }

        public Dog dog { get; set; }

        //public List<Neighborhood> NeighborhoodOptions {get;set;}
        //public Neighborhood neighborhood { get; set; }
        public string ErrorMessage { get; set; }
    }
}