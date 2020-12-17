using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Dog
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "If you're unsure of the dog's breed you may list the Breed as \"mixed\".")]
        public string Breed { get; set; }

        public string Notes { get; set; }

        public string ImageURL { get; set; }
    }
}