
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Antiforgery;

namespace AdoptApet.Models;
public class pet
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    public string Breed { get; set; }
    public int Age { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public bool IsAdopted { get; set; }
    
    public virtual ICollection<Appointment> Appointments { get; set; }
}
