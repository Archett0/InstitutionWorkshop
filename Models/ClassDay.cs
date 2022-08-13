namespace Institution.Models;

public class ClassDay
{
    public ClassDay()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }

    public DateTime RunDate { get; set; }

    public virtual ModuleClass ModuleClass { get; set; }

    public virtual Lecturer Lecturer { get; set; }
}