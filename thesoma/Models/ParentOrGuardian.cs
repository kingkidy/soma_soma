using System.ComponentModel.DataAnnotations;
namespace thesoma.Models;


public class ParentOrGuardian
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    public string Relationship { get; set; }

    [Required]
    [StringLength(10)]
    public string Sex { get; set; }

    [StringLength(100)]
    public string Occupation { get; set; }

    [Required]
    [StringLength(200)]
    public string Address { get; set; }

    [Required]
    [Phone]
    public string PhoneNumber { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
