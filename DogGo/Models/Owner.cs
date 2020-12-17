﻿using System.Collections.Generic;

namespace DogGo.Models
{
    public class Owner
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int NeighborhoodId { get; set; }

        public string Phone { get; set; }

        public Neighborhood Neighborhood { get; set; }

        //public List<Neighborhood> neighborhoods {get;set;}

        public List<Owner> owner { get; set; }

        
    }
}