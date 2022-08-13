using Institution.Models;
using Microsoft.EntityFrameworkCore;

namespace Institution.Data;

public class InstitutionDbContext: DbContext
{
    public InstitutionDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Module> Module { get; set; }
    public DbSet<Lecturer> Lecturer { get; set; }
    public DbSet<Student> Student { get; set; }
    public DbSet<ModuleClass> ModuleClass { get; set; }
    public DbSet<ClassDay> ClassDay { get; set; }
}