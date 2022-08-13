using System.ComponentModel.DataAnnotations;

namespace Institution.Models;

public class Lecturer
{
    public Lecturer()
    {
        Id = Guid.NewGuid();
        ClassDays = new List<ClassDay>();
    }

    public Guid Id { get; set; }

    [Required]
    [MaxLength(36)]
    public string Firstname { get; set; }

    [Required]
    [MaxLength(36)]
    public string Lastname { get; set; }

    public virtual ICollection<ClassDay> ClassDays { get; set; }
}