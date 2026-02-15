namespace Bomba_Academy.DAL.Context;

using Bomba_Academy.Domain.Enteties;
using Microsoft.EntityFrameworkCore;
public class BombaAcademyDbContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-LJTCG3Q\\SQLEXPRESS;Initial Catalog=Bomba_Academy;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
    }
    public DbSet<Auditorium> Auditoriums { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Departament> Departaments { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupTeacher> GroupTeachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<TeacherSubject> TeacherSubjects { get; set; }
    
    

}
