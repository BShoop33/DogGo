using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Models.ViewModels
{
    public class WalkerEditViewModel
    {
        public List<Neighborhood> Neighborhood { get; set; }

        public Owner Owner { get; set; }

        public List<Owner> Owners { get; set; }


        public Walker Walker { get; set; }

        public List<Walks> Walks { get; set; }

        public string ErrorMessage { get; set; }
    }
}
