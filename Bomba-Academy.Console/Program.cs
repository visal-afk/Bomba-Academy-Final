using Bomba_Academy.Aplication.Concrete;
using Bomba_Academy.DAL.Context;
using Bomba_Academy.DAL.UOW.Concrete;
using Bomba_Academy.DAL.UOW.Abstract;
using Bomba_Academy.Domain.Enteties;

var context = new BombaAcademyDbContext();
IUnitOfWork uow = new UnitOfWork(context);

var departmentService = new DepartamentService(uow);
var courseService = new CourseService(uow);
var groupService = new GroupService(uow);
var subjectService = new SubjectService(uow);
var teacherService = new TeacherService(uow);
var studentService = new StudentService(uow);
var auditoriumService = new AuditoriumService(uow);

while (true)
{
    Console.WriteLine("Recommended Data Entry Order:");
    Console.WriteLine("--------------------------------");
    Console.WriteLine("First you need to create a department");
    Console.WriteLine("Then you need to create a course");
    Console.WriteLine("Then you need to create a group");
    Console.WriteLine("Then you need to create a subject");
    Console.WriteLine("Then you need to create a teacher");
    Console.WriteLine("Then you need to create a student");
    Console.WriteLine("Then you need to create an auditorium");
    Console.WriteLine("--------------------------------");
    Console.WriteLine("1. Departments");
    Console.WriteLine("2. Courses");
    Console.WriteLine("3. Groups");
    Console.WriteLine("4. Subjects");
    Console.WriteLine("5. Teachers");
    Console.WriteLine("6. Students");
    Console.WriteLine("7. Auditoriums");
    Console.WriteLine("8. Exit");
    Console.Write("Choice: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            {
                Console.WriteLine("1. Create Department");
                Console.WriteLine("2. Get All Departments");
                Console.WriteLine("3. Get Department by Id");
                Console.WriteLine("4. Update Department");
                Console.WriteLine("5. Delete Department");
                Console.WriteLine("6. Get All Departments with Courses and Groups");
                var departmentChoice = Console.ReadLine();

                switch (departmentChoice)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter the name of the department");
                            var depName = Console.ReadLine();
                            var department = new Departament { Name = depName };
                            departmentService.Create(department);
                            Console.WriteLine("Department created.");
                            break;
                        }
                    case "2":
                        {
                            var departments = departmentService.GetAll();
                            foreach (var dep in departments)
                            {
                                Console.WriteLine($"Department: {dep.Name}");
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Enter the id of the department");
                            var idText = Console.ReadLine();
                            var dep = departmentService.GetById(int.Parse(idText));
                            Console.WriteLine($"Department: {dep.Name}");
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Enter the id of the department");
                            var id = Console.ReadLine();
                            departmentService.Update(int.Parse(id));
                            Console.WriteLine("Department updated successfully");
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Enter the id of the department");
                            var idText = Console.ReadLine();
                            departmentService.Delete(int.Parse(idText));
                            Console.WriteLine("Department deleted successfully");
                            break;
                        }
                    case "6":
                        var departmentInfos = departmentService.GetAllWithCoursesAndGroups();
                        foreach (var info in departmentInfos)
                        {
                            Console.WriteLine($"Department: {info.DepartamentName}, Course: {info.CourseNumber}, Group: {info.GroupName}");
                        }
                        break;
                }

                break;
            }

        case "2":
            {
                Console.WriteLine("1. Create Course");
                Console.WriteLine("2. Get All Courses");
                Console.WriteLine("3. Get Course by Id");
                Console.WriteLine("4. Update Course");
                Console.WriteLine("5. Delete Course");
                Console.WriteLine("6. Get All Courses with Groups");
                var courseChoice = Console.ReadLine();

                switch (courseChoice)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter the number of the course");
                            var numberText = Console.ReadLine();
                            var course = new Course { CourseNumber = int.Parse(numberText) };
                            courseService.Create(course);
                            Console.WriteLine("Course created.");
                            break;
                        }
                    case "2":
                        {
                            var courses = courseService.GetAll();
                            foreach (var c in courses)
                            {
                                Console.WriteLine($"Course: {c.CourseNumber}");
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Enter the id of the course");
                            var idText = Console.ReadLine();
                            var course = courseService.GetById(int.Parse(idText));
                            Console.WriteLine($"Course: {course.CourseNumber}");
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Enter the id of the course");
                            var id = Console.ReadLine();
                            courseService.Update(int.Parse(id));
                            Console.WriteLine("Course updated successfully");
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Enter the id of the course");
                            var idText = Console.ReadLine();
                            courseService.Delete(int.Parse(idText));
                            Console.WriteLine("Course deleted successfully");
                            break;
                        }
                    case "6":
                        {
                            var courseInfos = courseService.GetAllWithGroups();
                            foreach (var info in courseInfos)
                            {
                                Console.WriteLine($"Course: {info.CourseNumber}, Group: {info.GroupName}");
                            }
                            break;
                        }
                }

                break;
            }

        case "3":
            {
                Console.WriteLine("1. Create Group");
                Console.WriteLine("2. Get All Groups");
                Console.WriteLine("3. Get Group by Id");
                Console.WriteLine("4. Update Group");
                Console.WriteLine("5. Delete Group");
                Console.WriteLine("6. Get All Groups with Courses and Auditoriums");
                var groupChoice = Console.ReadLine();

                switch (groupChoice)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter the name of the group");
                            var groupName = Console.ReadLine();

                            Console.WriteLine("Enter Course Id for this group");
                            var courseIdText = Console.ReadLine();

                            Console.WriteLine("Enter Departament Id for this group");
                            var depIdText = Console.ReadLine();

                            Console.WriteLine("Enter Auditorium Id for this group");
                            var audIdText = Console.ReadLine();

                            var group = new Group
                            {
                                Name = groupName,
                                CourseId = int.Parse(courseIdText),
                                DepartamentId = int.Parse(depIdText),
                                AuditoriumId = int.Parse(audIdText)
                            };

                            groupService.Create(group);
                            Console.WriteLine("Group created.");
                            break;
                        }
                    case "2":
                        {
                            var groups = groupService.GetAll();
                            foreach (var g in groups)
                            {
                                Console.WriteLine($"Group: {g.Id} - {g.Name}");
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Enter the id of the group");
                            var idText = Console.ReadLine();
                            var groupById = groupService.GetById(int.Parse(idText));
                            Console.WriteLine($"Group: {groupById.Id} - {groupById.Name}");
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Enter the id of the group");
                            var id = Console.ReadLine();
                            groupService.Update(int.Parse(id));
                            Console.WriteLine("Group updated successfully");
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Enter the id of the group");
                            var idText = Console.ReadLine();
                            groupService.Delete(int.Parse(idText));
                            Console.WriteLine("Group deleted successfully");
                            break;
                        }
                    case "6":
                        {
                            var groupInfos = groupService.GetAllWithCoursesAndAuditoriums();
                            foreach (var info in groupInfos)
                            {
                                Console.WriteLine($"Group: {info.GroupName}, Course: {info.CourseNumber}, Auditorium: {info.AuditorimName}");
                            }
                            break;
                        }
                }

                break;
            }

        case "4":
            {
                Console.WriteLine("1. Create Subject");
                Console.WriteLine("2. Get All Subjects");
                Console.WriteLine("3. Get Subject by Id");
                Console.WriteLine("4. Update Subject");
                Console.WriteLine("5. Delete Subject");
                var subjectChoice = Console.ReadLine();

                switch (subjectChoice)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter the name of the subject");
                            var subjectName = Console.ReadLine();

                            Console.WriteLine("Enter Course Id for this subject");
                            var courseIdText = Console.ReadLine();

                            var subject = new Subject
                            {
                                Name = subjectName,
                                CourseId = int.Parse(courseIdText)
                            };

                            subjectService.Create(subject);
                            Console.WriteLine("Subject created.");
                            break;
                        }
                    case "2":
                        {
                            var subjects = subjectService.GetAll();
                            foreach (var s in subjects)
                            {
                                Console.WriteLine($"Subject: {s.Name}");
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Enter the id of the subject");
                            var idText = Console.ReadLine();
                            var subject = subjectService.GetById(int.Parse(idText));
                            Console.WriteLine($"Subject: {subject.Name}");
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Enter the id of the subject");
                            var id = Console.ReadLine();
                            subjectService.Update(int.Parse(id));
                            Console.WriteLine("Subject updated successfully");
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Enter the id of the subject");
                            var idText = Console.ReadLine();
                            subjectService.Delete(int.Parse(idText));
                            Console.WriteLine("Subject deleted successfully");
                            break;
                        }
                }

                break;
            }

        case "5":
            {
                Console.WriteLine("1. Create Teacher");
                Console.WriteLine("2. Get All Teachers");
                Console.WriteLine("3. Get Teacher by Id");
                Console.WriteLine("4. Update Teacher");
                Console.WriteLine("5. Delete Teacher");
                Console.WriteLine("6. Get All Teachers with Subjects");
                var teacherChoice = Console.ReadLine();

                switch (teacherChoice)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter the name of the teacher");
                            var tName = Console.ReadLine();
                            Console.WriteLine("Enter the surname of the teacher");
                            var tSurname = Console.ReadLine();
                            Console.WriteLine("Enter the email of the teacher");
                            var tEmail = Console.ReadLine();
                            Console.WriteLine("Enter the phone number of the teacher");
                            var tPhone = Console.ReadLine();
                            Console.WriteLine("Enter Departament Id for this teacher");
                            var tDepIdText = Console.ReadLine();

                            var teacher = new Teacher
                            {
                                Name = tName,
                                Surname = tSurname,
                                Email = tEmail,
                                PhoneNumber = tPhone,
                                DepartamentId = int.Parse(tDepIdText)
                            };

                            teacherService.Create(teacher);
                            Console.WriteLine("Teacher created.");
                            break;
                        }
                    case "2":
                        {
                            var teachers = teacherService.GetAll();
                            foreach (var t in teachers)
                            {
                                Console.WriteLine($"Teacher: {t.Name} {t.Surname}");
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Enter the id of the teacher");
                            var idText = Console.ReadLine();
                            var teacher = teacherService.GetById(int.Parse(idText));
                            Console.WriteLine($"Teacher: {teacher.Name} {teacher.Surname}");
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Enter the id of the teacher");
                            var id = Console.ReadLine();
                            teacherService.Update(int.Parse(id));
                            Console.WriteLine("Teacher updated successfully");
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Enter the id of the teacher");
                            var idText = Console.ReadLine();
                            teacherService.Delete(int.Parse(idText));
                            Console.WriteLine("Teacher deleted successfully");
                            break;
                        }
                    case "6":
                        {
                            var teacherInfos = teacherService.GetAllWithSubjects();
                            foreach (var info in teacherInfos)
                            {
                                var subjects = info.SubjectNames != null
                                    ? string.Join(", ", info.SubjectNames)
                                    : "No subjects";

                                Console.WriteLine($"Teacher: {info.TeacherName}, Subjects: {subjects}");
                            }
                            break;
                        }
                }

                break;
            }

        case "6":
            {
                Console.WriteLine("1. Create Student");
                Console.WriteLine("2. Get All Students");
                Console.WriteLine("3. Get Student by Id");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Get All Students with Groups");
                var studentChoice = Console.ReadLine();

                switch (studentChoice)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter the name of the student");
                            var sName = Console.ReadLine();
                            Console.WriteLine("Enter the surname of the student");
                            var sSurname = Console.ReadLine();
                            Console.WriteLine("Enter the email of the student");
                            var sEmail = Console.ReadLine();
                            Console.WriteLine("Enter the phone number of the student");
                            var sPhone = Console.ReadLine();
                            Console.WriteLine("Enter the pin of the student");
                            var sPin = Console.ReadLine();
                            Console.WriteLine("Enter the gpa of the student");
                            var sGpaText = Console.ReadLine();
                            Console.WriteLine("Enter Group Id for this student");
                            var sGroupIdText = Console.ReadLine();

                            var student = new Student
                            {
                                Name = sName,
                                Surname = sSurname,
                                Email = sEmail,
                                PhoneNumber = sPhone,
                                Pin = sPin,
                                Gpa = decimal.Parse(sGpaText),
                                GroupId = int.Parse(sGroupIdText)
                            };

                            studentService.Create(student);
                            Console.WriteLine("Student created.");
                            break;
                        }
                    case "2":
                        {
                            var students = studentService.GetAll();
                            foreach (var s in students)
                            {
                                Console.WriteLine($"Student: {s.Name} {s.Surname}");
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Enter the id of the student");
                            var idText = Console.ReadLine();
                            var student = studentService.GetById(int.Parse(idText));
                            Console.WriteLine($"Student: {student.Name} {student.Surname}");
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Enter the id of the student");
                            var id = Console.ReadLine();
                            studentService.Update(int.Parse(id));
                            Console.WriteLine("Student updated successfully");
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Enter the id of the student");
                            var idText = Console.ReadLine();
                            studentService.Delete(int.Parse(idText));
                            Console.WriteLine("Student deleted successfully");
                            break;
                        }
                    case "6":
                        {
                            var studentInfos = studentService.GetAllWithGroups();
                            foreach (var info in studentInfos)
                            {
                                Console.WriteLine($"Student: {info.FirstName} {info.LastName}, Group: {info.GroupName}");
                            }
                            break;
                        }
                }

                break;
            }

        case "7":
            {
                Console.WriteLine("1. Create Auditorium");
                Console.WriteLine("2. Get All Auditoriums");
                Console.WriteLine("3. Get Auditorium by Id");
                Console.WriteLine("4. Update Auditorium");
                Console.WriteLine("5. Delete Auditorium");
                var auditoriumChoice = Console.ReadLine();

                switch (auditoriumChoice)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter the name of the auditorium");
                            var audName = Console.ReadLine();
                            Console.WriteLine("Enter capacity of the auditorium");
                            var audCapacityText = Console.ReadLine();

                            var auditorium = new Auditorium
                            {
                                Name = audName,
                                Capacity = int.Parse(audCapacityText)
                            };

                            auditoriumService.Create(auditorium);
                            Console.WriteLine("Auditorium created.");
                            break;
                        }
                    case "2":
                        {
                            var auditoriums = auditoriumService.GetAll();
                            foreach (var a in auditoriums)
                            {
                                Console.WriteLine($"Auditorium: {a.Name}");
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Enter the id of the auditorium");
                            var idText = Console.ReadLine();
                            var auditorium = auditoriumService.GetById(int.Parse(idText));
                            Console.WriteLine($"Auditorium: {auditorium.Name}");
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Enter the id of the auditorium");
                            var id = Console.ReadLine();
                            auditoriumService.Update(int.Parse(id));
                            Console.WriteLine("Auditorium updated successfully");
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Enter the id of the auditorium");
                            var idText = Console.ReadLine();
                            auditoriumService.Delete(int.Parse(idText));
                            Console.WriteLine("Auditorium deleted successfully");
                            break;
                        }
                }

                break;
            }

        case "8":
            {
                Console.WriteLine("Exiting...");
                return; 
            }

        default:
            {
                Console.WriteLine("Invalid choice");
                break;
            }
    }

    Console.WriteLine();
}