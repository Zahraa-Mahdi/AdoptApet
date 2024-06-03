using System.ComponentModel.DataAnnotations;

namespace AdoptApet.Models;
public class Appointment
{
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(500)]
    public string Message { get; set; }


    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public virtual pet Pet { get; set; }
    public virtual Service Service { get; set; }

}