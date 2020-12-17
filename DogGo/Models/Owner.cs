using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public int NeighborhoodId { get; set; }

        [Required]
        public string Phone { get; set; }

        public Neighborhood Neighborhood { get; set; }

        public List<Owner> owner { get; set; }
    }
}