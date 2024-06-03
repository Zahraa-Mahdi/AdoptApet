using System.ComponentModel.DataAnnotations;
namespace AdoptApet.Models;
public class Service
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }