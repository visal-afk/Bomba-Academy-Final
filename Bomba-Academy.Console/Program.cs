using Bomba_Academy.Aplication.Concrete;
using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.UOW.Concrete;
using Bomba_Academy.Domain.Enteties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

Console.WriteLine("--- RUNNING IN SQL SERVER MODE ---");

var context = new BombaAcademyDbContext();

try
{
    // Initialize UnitOfWork and Services
    using (context)
    {
        // Ensure the database is created
        Console.WriteLine("Checking database connection...");
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Database created successfully.");
        }
        else
        {
            Console.WriteLine("Database already exists.");
        }

        var uow = new UnitOfWork(context);

        var studentService = new StudentService(uow);
        var teacherService = new TeacherService(uow);
        var groupService = new GroupService(uow);
        var departmentService = new DepartamentService(uow);

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n=========================================");
            Console.WriteLine("   Bomba Academy Management System");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Manage Students");
            Console.WriteLine("2. Manage Teachers");
            Console.WriteLine("3. Manage Groups");
            Console.WriteLine("4. Manage Departments");
            Console.WriteLine("0. Exit");
            Console.Write("\nSelect an option: ");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ManageStudents(studentService, groupService);
                    break;
                case "2":
                    ManageTeachers(teacherService, departmentService);
                    break;
                case "3":
                    ManageGroups(groupService, departmentService);
                    break;
                case "4":
                    ManageDepartments(departmentService);
                    break;
                case "0":
                    exit = true;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An critical error occurred: {ex.Message}");
    if (ex.InnerException != null)
    {
        Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
    }
}

// =================================================================================
// Student Management
// =================================================================================
static void ManageStudents(StudentService studentService, GroupService groupService)
{
    while (true)
    {
        Console.WriteLine("\n--- Student Management ---");
        Console.WriteLine("1. List All Students");
        Console.WriteLine("2. Add Student");
        Console.WriteLine("3. Update Student");
        Console.WriteLine("4. Delete Student");
        Console.WriteLine("0. Back to Main Menu");
        Console.Write("Select: ");

        var choice = Console.ReadLine();
        if (choice == "0") break;

        try
        {
            switch (choice)
            {
                case "1":
                    var students = studentService.GetAll();
                    Console.WriteLine("\nList of Students:");
                    foreach (var s in students)
                    {
                        Console.WriteLine($"ID: {s.Id}, Name: {s.Name} {s.Surname}, Email: {s.Email}, GroupID: {s.GroupId}");
                    }
                    break;
                case "2":
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine() ?? "";
                    Console.Write("Enter Surname: ");
                    string surname = Console.ReadLine() ?? "";
                    Console.Write("Enter Email: ");
                    string email = Console.ReadLine() ?? "";
                    Console.Write("Enter Phone: ");
                    string phone = Console.ReadLine() ?? "";
                    Console.Write("Enter PIN: ");
                    string pin = Console.ReadLine() ?? "";
                    Console.Write("Enter GPA: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal gpa)) gpa = 0;

                    Console.WriteLine("Available Groups:");
                    foreach(var g in groupService.GetAll()) Console.WriteLine($"ID: {g.Id}, Name: {g.Name}");
                    Console.Write("Enter Group ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int groupId)) groupId = 0;

                    var newStudent = new Student
                    {
                        Name = name,
                        Surname = surname,
                        Email = email,
                        PhoneNumber = phone,
                        Pin = pin,
                        Gpa = gpa,
                        GroupId = groupId
                    };
                    studentService.Create(newStudent);
                    Console.WriteLine("Student added successfully.");
                    break;
                case "3":
                    Console.Write("Enter Student ID to update: ");
                    if (int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        var student = studentService.GetById(updateId);
                        if (student != null)
                        {
                            Console.WriteLine($"Updating Student: {student.Name} {student.Surname}");
                            Console.Write("Enter New Name (leave empty to keep current): ");
                            string? n = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(n)) student.Name = n;

                            Console.Write("Enter New Surname (leave empty to keep current): ");
                            string? s = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(s)) student.Surname = s;

                            Console.Write("Enter New Email (leave empty to keep current): ");
                            string? e = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(e)) student.Email = e;

                            // We call Update(id) on service, which calls Update(id) on repo.
                            // Since we modified the entity directly (which is tracked), SaveChanges in Update(id) *should* persist it.
                            studentService.Update(updateId);
                            Console.WriteLine("Student updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                    }
                    break;
                case "4":
                    Console.Write("Enter Student ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        studentService.Delete(deleteId);
                        Console.WriteLine("Student deleted successfully.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// =================================================================================
// Teacher Management
// =================================================================================
static void ManageTeachers(TeacherService teacherService, DepartamentService deptService)
{
    while (true)
    {
        Console.WriteLine("\n--- Teacher Management ---");
        Console.WriteLine("1. List All Teachers");
        Console.WriteLine("2. Add Teacher");
        Console.WriteLine("3. Update Teacher");
        Console.WriteLine("4. Delete Teacher");
        Console.WriteLine("0. Back to Main Menu");
        Console.Write("Select: ");

        var choice = Console.ReadLine();
        if (choice == "0") break;

        try
        {
            switch (choice)
            {
                case "1":
                    var teachers = teacherService.GetAll();
                    Console.WriteLine("\nList of Teachers:");
                    foreach (var t in teachers)
                    {
                        Console.WriteLine($"ID: {t.Id}, Name: {t.Name} {t.Surname}, Email: {t.Email}, DeptID: {t.DepartamentId}");
                    }
                    break;
                case "2":
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine() ?? "";
                    Console.Write("Enter Surname: ");
                    string surname = Console.ReadLine() ?? "";
                    Console.Write("Enter Email: ");
                    string email = Console.ReadLine() ?? "";
                    Console.Write("Enter Phone: ");
                    string phone = Console.ReadLine() ?? "";

                    Console.WriteLine("Available Departments:");
                    foreach(var d in deptService.GetAll()) Console.WriteLine($"ID: {d.Id}, Name: {d.Name}");
                    Console.Write("Enter Department ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int deptId)) deptId = 0;

                    var newTeacher = new Teacher
                    {
                        Name = name,
                        Surname = surname,
                        Email = email,
                        PhoneNumber = phone,
                        DepartamentId = deptId
                    };
                    teacherService.Create(newTeacher);
                    Console.WriteLine("Teacher added successfully.");
                    break;
                case "3":
                    Console.Write("Enter Teacher ID to update: ");
                    if (int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        var teacher = teacherService.GetById(updateId);
                        if (teacher != null)
                        {
                             Console.WriteLine($"Updating Teacher: {teacher.Name} {teacher.Surname}");
                             Console.Write("Enter New Name (leave empty to keep current): ");
                             string? n = Console.ReadLine();
                             if (!string.IsNullOrWhiteSpace(n)) teacher.Name = n;

                             Console.Write("Enter New Surname (leave empty to keep current): ");
                             string? s = Console.ReadLine();
                             if (!string.IsNullOrWhiteSpace(s)) teacher.Surname = s;

                             teacherService.Update(updateId);
                             Console.WriteLine("Teacher updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Teacher not found.");
                        }
                    }
                    break;
                case "4":
                    Console.Write("Enter Teacher ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        teacherService.Delete(deleteId);
                        Console.WriteLine("Teacher deleted successfully.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        catch (Exception ex)
        {
             Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// =================================================================================
// Group Management
// =================================================================================
static void ManageGroups(GroupService groupService, DepartamentService deptService)
{
    while (true)
    {
        Console.WriteLine("\n--- Group Management ---");
        Console.WriteLine("1. List All Groups");
        Console.WriteLine("2. Add Group");
        Console.WriteLine("0. Back to Main Menu");
        Console.Write("Select: ");

        var choice = Console.ReadLine();
        if (choice == "0") break;

        try
        {
            switch (choice)
            {
                case "1":
                    var groups = groupService.GetAll();
                    Console.WriteLine("\nList of Groups:");
                    foreach (var g in groups)
                    {
                         Console.WriteLine($"ID: {g.Id}, Name: {g.Name}, DeptID: {g.DepartamentId}");
                    }
                    break;
                case "2":
                    Console.Write("Enter Group Name: ");
                    string name = Console.ReadLine() ?? "";

                    Console.WriteLine("Available Departments:");
                    foreach(var d in deptService.GetAll()) Console.WriteLine($"ID: {d.Id}, Name: {d.Name}");
                    Console.Write("Enter Department ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int deptId)) deptId = 0;

                    Console.Write("Enter Auditorium ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int audId)) audId = 0;

                    Console.Write("Enter Course ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int courseId)) courseId = 0;

                    var newGroup = new Group
                    {
                        Name = name,
                        DepartamentId = deptId,
                        AuditoriumId = audId,
                        CourseId = courseId
                    };
                    groupService.Create(newGroup);
                    Console.WriteLine("Group added successfully.");
                    break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {
             Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// =================================================================================
// Department Management
// =================================================================================
static void ManageDepartments(DepartamentService deptService)
{
    while (true)
    {
        Console.WriteLine("\n--- Department Management ---");
        Console.WriteLine("1. List All Departments");
        Console.WriteLine("2. Add Department");
        Console.WriteLine("0. Back to Main Menu");
        Console.Write("Select: ");

        var choice = Console.ReadLine();
        if (choice == "0") break;

        try
        {
            switch (choice)
            {
                case "1":
                    var depts = deptService.GetAll();
                    Console.WriteLine("\nList of Departments:");
                    foreach (var d in depts)
                    {
                        Console.WriteLine($"ID: {d.Id}, Name: {d.Name}");
                    }
                    break;
                case "2":
                     Console.Write("Enter Department Name: ");
                     string name = Console.ReadLine() ?? "";

                     var newDept = new Departament
                     {
                         Name = name
                     };
                     deptService.Create(newDept);
                     Console.WriteLine("Department added successfully.");
                     break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {
             Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
