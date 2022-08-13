using System.Diagnostics;
using Institution.Models;

namespace Institution.Data;

public class DbOperations
{
    private InstitutionDbContext _context;

    public DbOperations(InstitutionDbContext context)
    {
        this._context = context;
    }

    public void SetDataForTables()
    {
        // Module
        var module1 = new Module
        {
            Code = "NETC",
            Title = "NET Core",
            Description = "Learn Web Development with .NET Core"
        };

        var module2 = new Module
        {
            Code = "MLPY",
            Title = "Machine Learning in Python",
            Description = "Learn ML Techniques with Python"
        };

        _context.Add(module1);
        _context.Add(module2);
        _context.SaveChanges();

        // Lecturer
        var lecturer1 = new Lecturer
        {
            Firstname = "Kim",
            Lastname = "Tan"
        };

        var lecturer2 = new Lecturer
        {
            Firstname = "Lynn",
            Lastname = "Wong"
        };

        _context.Add(lecturer1);
        _context.Add(lecturer2);
        _context.SaveChanges();

        // Student
        var student1 = new Student
        {
            Firstname = "Jean",
            Lastname = "Sim"
        };

        var student2 = new Student
        {
            Firstname = "Kate",
            Lastname = "Lim"
        };

        var student3 = new Student
        {
            Firstname = "Lynn",
            Lastname = "Ho"
        };

        var student4 = new Student
        {
            Firstname = "James",
            Lastname = "See"
        };

        _context.Add(student1);
        _context.Add(student2);
        _context.Add(student3);
        _context.Add(student4);
        _context.SaveChanges();

        // Class
        var module = _context.Module.FirstOrDefault(m => m.Code.Equals("NETC"));
        if (module != null)
        {
            var moduleClass1 = new ModuleClass
            {
                Code = "ISS001",
                Fee = 300,
                ModuleId = module.Id
            };

            var moduleClass2 = new ModuleClass
            {
                Code = "ISS002",
                Fee = 600,
                ModuleId = module.Id
            };
            _context.Add(moduleClass1);
            _context.Add(moduleClass2);
            module.ModuleClasses.Add(moduleClass1);
            module.ModuleClasses.Add(moduleClass2);
        }
        _context.SaveChanges();

        // Class day
        var lec1 = _context.Lecturer.FirstOrDefault(l => l.Firstname.Equals("Kim") && l.Lastname.Equals("Tan"));
        var lec2 = _context.Lecturer.FirstOrDefault(l => l.Firstname.Equals("Lynn") && l.Lastname.Equals("Wong"));

        var class1 = _context.ModuleClass.FirstOrDefault(c => c.Code.Equals("ISS001"));
        if (class1 != null)
        {
            var day1 = new ClassDay
            {
                Lecturer = lec1,
                ModuleClass = class1,
                RunDate = new DateTime(2021, 11, 1, 9, 0, 0)
            };

            _context.ClassDay.Add(day1);
        }

        var class2 = _context.ModuleClass.FirstOrDefault(c => c.Code.Equals("ISS002"));

        if (class2 != null)
        {
            var day1 = new ClassDay
            {
                Lecturer = lec1,
                ModuleClass = class2,
                RunDate = new DateTime(2021, 12, 1, 9, 0, 0)
            };

            var day2 = new ClassDay
            {
                Lecturer = lec2,
                ModuleClass = class2,
                RunDate = new DateTime(2021, 12, 2, 9, 0, 0)
            };

            _context.ClassDay.Add(day1);
            _context.ClassDay.Add(day2);
        }

        _context.SaveChanges();

        // Students enroll
        var class001 = _context.ModuleClass.FirstOrDefault(x => x.Code == "ISS001");

        if (class001 != null)
        {
            var student01 = _context.Student.FirstOrDefault(x =>
                x.Firstname == "James" && x.Lastname == "See"
            );
            var student02 = _context.Student.FirstOrDefault(x =>
                x.Firstname == "Jean" && x.Lastname == "Sim"
            );

            class001.Students.Add(student01);
            class001.Students.Add(student02);
        }

        _context.SaveChanges();

    }

    public void OperationA()
    {
        var lecturer = _context.Lecturer.FirstOrDefault(l => l.Firstname.Equals("Kim") && l.Lastname.Equals("Tan"));
        if(lecturer == null) return;
        
        var classDays = _context.ClassDay.Where(cd => cd.Lecturer.Equals(lecturer)).ToList();
        if (classDays.Count == 0)
        {
            Debug.WriteLine("No class found");
            return;
        }

        foreach (var classDay in classDays)
        {
            Debug.WriteLine(classDay.RunDate);
        }
    }
    public void OperationB()
    {
        var modules = _context.Module.Where(m => m.ModuleClasses.Count == 0).ToList();
        if (modules.Count == 0)
        {
            Debug.WriteLine("No module found");
            return;
        }
        foreach (var module in modules)
        {
            Debug.WriteLine(module.Title);
        }
    }
    public void OperationC()
    {
        var students = _context.Student.Where(s => s.ModuleClasses.Count >= 1).ToList();
        if (students.Count == 0)
        {
            Debug.WriteLine("No module found");
            return;
        }
        foreach (var student in students)
        {
            Debug.WriteLine(student.Firstname + " " + student.Lastname);
        }
    }
    public void OperationD()
    {
        var classes = _context.ModuleClass.Where(c => c.ClassDays.Count == 2).ToList();
        foreach (var classDay in classes)
        {
            classDay.Fee = 800;
        }

        _context.SaveChanges();
    }

    public void CallOperations()
    {
        OperationA();
        OperationB();
        OperationC();
        OperationD();
    }
}