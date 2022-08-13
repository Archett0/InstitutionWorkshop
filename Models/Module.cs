using System.ComponentModel.DataAnnotations;

namespace Institution.Models;

public class Module
{
    public Module()
    {
        Id = Guid.NewGuid();
        ModuleClasses = new List<ModuleClass>();
    }

    public Guid Id { get; set; }

    [Required]
    [MaxLength(6)]
    public string Code { get; set; }

    [Required]
    [MaxLength(48)]
    public string Title { get; set; }

    [Required]
    [MaxLength(512)]
    public string Description { get; set; }

    public virtual ICollection<ModuleClass> ModuleClasses { get; set; }
}