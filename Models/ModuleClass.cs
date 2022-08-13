using System.ComponentModel.DataAnnotations;

namespace Institution.Models;

public class ModuleClass
{
    public ModuleClass()
    {
        Id = Guid.NewGuid();
        ClassDays = new List<ClassDay>();
        Students = new List<Student>();
    }

    public Guid Id { get; set; }

    [Required]
    [MaxLength(6)]
    public string Code { get; set; }

    public float Fee { get; set; }

    public virtual Guid ModuleId { get; set; }

    public virtual ICollection<ClassDay> ClassDays { get; set; }

    public virtual ICollection<Student> Students { get; set; }
}