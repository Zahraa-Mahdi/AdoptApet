
using System.ComponentModel.DataAnnotations;
namespace AdoptApet.Models;
public class Adoption
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string AdopterName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string PetName { get; set; }

        [Required]
        public DateTime AdoptionDate { get; set; }

        [Required]
        [StringLength(500)]
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
