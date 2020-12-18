using System.Collections.Generic;

namespace DogGo.Models.ViewModels
{
    public class WalkerFormViewModel
    {
        public List<Neighborhood> Neighborhood { get; set; }

        public Owner Owner { get; set; }

        public List<Owner> Owners { get; set; }

        //public List<Walker> Walkers { get; set; }

        public Walker Walker { get; set; }

        //public Walker GetWalkerById { get; set; }

        public List<Walks> Walks { get; set; }

        public string ErrorMessage { get; set; }

        public List<Walker> Walkers { get; set; }
    }
}