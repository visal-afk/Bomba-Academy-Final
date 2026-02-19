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

        // Initialize all services
        var studentService = new StudentService(uow);
        var teacherService = new TeacherService(uow);
        var groupService = new GroupService(uow);
        var departmentService = new DepartamentService(uow);
        var auditoriumService = new AuditoriumService(uow);
        var courseService = new CourseService(uow);
        var subjectService = new SubjectService(uow);

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n=========================================");
            Console.WriteLine("   Bomba Academy Management System");
            Console.WriteLine("=========================================");
            Console.WriteLine(" Recommended Data Entry Order:");
            Console.WriteLine(" 1. Departments -> 2. Auditoriums -> 3. Courses -> 4. Subjects");
            Console.WriteLine(" 5. Teachers (requires Dept) -> 6. Groups (requires Dept, Aud, Course)");
            Console.WriteLine(" 7. Students (requires Group)");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1. Manage Departments (Step 1)");
            Console.WriteLine("2. Manage Auditoriums (Step 2)");
            Console.WriteLine("3. Manage Courses     (Step 3)");
            Console.WriteLine("4. Manage Subjects    (Step 4)");
            Console.WriteLine("5. Manage Teachers    (Step 5)");
            Console.WriteLine("6. Manage Groups      (Step 6)");
            Console.WriteLine("7. Manage Students    (Step 7)");
            Console.WriteLine("0. Exit");
            Console.Write("\nSelect an option: ");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ManageDepartments(departmentService);
                    break;
                case "2":
                    ManageAuditoriums(auditoriumService);
                    break;
                case "3":
                    ManageCourses(courseService);
                    break;
                case "4":
                    ManageSubjects(subjectService, courseService);
                    break;
                case "5":
                    ManageTeachers(teacherService, departmentService);
                    break;
                case "6":
                    ManageGroups(groupService, departmentService, auditoriumService, courseService);
                    break;
                case "7":
                    ManageStudents(studentService, groupService);
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
// 1. Department Management
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

// =================================================================================
// 2. Auditorium Management
// =================================================================================
static void ManageAuditoriums(AuditoriumService audService)
{
    while (true)
    {
        Console.WriteLine("\n--- Auditorium Management ---");
        Console.WriteLine("1. List All Auditoriums");
        Console.WriteLine("2. Add Auditorium");
        Console.WriteLine("0. Back to Main Menu");
        Console.Write("Select: ");

        var choice = Console.ReadLine();
        if (choice == "0") break;

        try
        {
            switch (choice)
            {
                case "1":
                    var auds = audService.GetAll();
                    Console.WriteLine("\nList of Auditoriums:");
                    foreach (var a in auds)
                    {
                        Console.WriteLine($"ID: {a.Id}, Name: {a.Name}, Capacity: {a.Capacity}");
                    }
                    break;
                case "2":
                     Console.Write("Enter Auditorium Name: ");
                     string name = Console.ReadLine() ?? "";
                     Console.Write("Enter Capacity: ");
                     if (!int.TryParse(Console.ReadLine(), out int capacity)) capacity = 0;

                     var newAud = new Auditorium
                     {
                         Name = name,
                         Capacity = capacity
                     };
                     audService.Create(newAud);
                     Console.WriteLine("Auditorium added successfully.");
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
// 3. Course Management
// =================================================================================
static void ManageCourses(CourseService courseService)
{
    while (true)
    {
        Console.WriteLine("\n--- Course Management ---");
        Console.WriteLine("1. List All Courses");
        Console.WriteLine("2. Add Course");
        Console.WriteLine("0. Back to Main Menu");
        Console.Write("Select: ");

        var choice = Console.ReadLine();
        if (choice == "0") break;

        try
        {
            switch (choice)
            {
                case "1":
                    var courses = courseService.GetAll();
                    Console.WriteLine("\nList of Courses:");
                    foreach (var c in courses)
                    {
                        Console.WriteLine($"ID: {c.Id}, Number: {c.CourseNumber}");
                    }
                    break;
                case "2":
                     Console.Write("Enter Course Number (e.g., 1, 2, 3): ");
                     if (!int.TryParse(Console.ReadLine(), out int num)) num = 0;

                     var newCourse = new Course
                     {
                         CourseNumber = num
                     };
                     courseService.Create(newCourse);
                     Console.WriteLine("Course added successfully.");
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
// 4. Subject Management
// =================================================================================
static void ManageSubjects(SubjectService subjectService, CourseService courseService)
{
    while (true)
    {
        Console.WriteLine("\n--- Subject Management ---");
        Console.WriteLine("1. List All Subjects");
        Console.WriteLine("2. Add Subject");
        Console.WriteLine("0. Back to Main Menu");
        Console.Write("Select: ");

        var choice = Console.ReadLine();
        if (choice == "0") break;

        try
        {
            switch (choice)
            {
                case "1":
                    var subjects = subjectService.GetAll();
                    Console.WriteLine("\nList of Subjects:");
                    foreach (var s in subjects)
                    {
                        Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, CourseID: {s.CourseId}");
                    }
                    break;
                case "2":
                     Console.Write("Enter Subject Name: ");
                     string name = Console.ReadLine() ?? "";

                     Console.WriteLine("Available Courses:");
                     foreach(var c in courseService.GetAll()) Console.WriteLine($"ID: {c.Id}, Number: {c.CourseNumber}");
                     Console.Write("Enter Course ID: ");
                     if (!int.TryParse(Console.ReadLine(), out int courseId)) courseId = 0;

                     var newSubject = new Subject
                     {
                         Name = name,
                         CourseId = courseId
                     };
                     subjectService.Create(newSubject);
                     Console.WriteLine("Subject added successfully.");
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
// 5. Teacher Management
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
// 6. Group Management
// =================================================================================
static void ManageGroups(GroupService groupService, DepartamentService deptService, AuditoriumService audService, CourseService courseService)
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
                         Console.WriteLine($"ID: {g.Id}, Name: {g.Name}, DeptID: {g.DepartamentId}, AudID: {g.AuditoriumId}, CourseID: {g.CourseId}");
                    }
                    break;
                case "2":
                    Console.Write("Enter Group Name: ");
                    string name = Console.ReadLine() ?? "";

                    Console.WriteLine("Available Departments:");
                    foreach(var d in deptService.GetAll()) Console.WriteLine($"ID: {d.Id}, Name: {d.Name}");
                    Console.Write("Enter Department ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int deptId)) deptId = 0;

                    Console.WriteLine("Available Auditoriums:");
                    foreach(var a in audService.GetAll()) Console.WriteLine($"ID: {a.Id}, Name: {a.Name}, Cap: {a.Capacity}");
                    Console.Write("Enter Auditorium ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int audId)) audId = 0;

                    Console.WriteLine("Available Courses:");
                    foreach(var c in courseService.GetAll()) Console.WriteLine($"ID: {c.Id}, Number: {c.CourseNumber}");
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
// 7. Student Management
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
