using System;
using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Walks
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public int WalkerId { get; set; }

        [Required]
        public int DogId { get; set; }
    }
}