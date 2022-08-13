using System.ComponentModel.DataAnnotations;

namespace Institution.Models;

public class Student
{
    public Student()
    {
        Id = Guid.NewGuid();
        ModuleClasses = new List<ModuleClass>();
    }

    public Guid Id { get; set; }

    [Required]
    [MaxLength(36)]
    public string Firstname { get; set; }

    [Required]
    [MaxLength(36)]
    public string Lastname { get; set; }

    public virtual ICollection<ModuleClass> ModuleClasses { get; set; }
}