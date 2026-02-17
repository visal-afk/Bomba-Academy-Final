namespace Bomba_Academy.DAL.Context;

using Bomba_Academy.Domain.Enteties;
using Microsoft.EntityFrameworkCore;
public class BombaAcademyDbContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-LJTCG3Q\\SQLEXPRESS;Initial Catalog=Bomba_Academy;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.Departament) 
            .WithMany(d => d.Teachers)
            .HasForeignKey(t => t.DepartamentId)
            .OnDelete(DeleteBehavior.Restrict); 

      
        modelBuilder.Entity<Group>()
            .HasOne(g => g.Departament)
            .WithMany(d => d.Groups)
            .HasForeignKey(g => g.DepartamentId)
            .OnDelete(DeleteBehavior.Restrict); 

        
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Group)
            .WithMany(g => g.Students)
            .HasForeignKey(s => s.GroupId)
            .OnDelete(DeleteBehavior.Restrict); 

        
        modelBuilder.Entity<Group>()
            .HasMany(g => g.Teachers)
            .WithMany(t => t.Groups)
            .UsingEntity<Dictionary<string, object>>(
                "GroupTeacher", 
                j => j.HasOne<Teacher>().WithMany().HasForeignKey("TeachersId").OnDelete(DeleteBehavior.Restrict),
                j => j.HasOne<Group>().WithMany().HasForeignKey("GroupsId").OnDelete(DeleteBehavior.Restrict)
            );

        
        modelBuilder.Entity<Subject>()
           .HasMany(s => s.Teachers)
           .WithMany(t => t.Subjects)
           .UsingEntity<Dictionary<string, object>>(
               "SubjectTeacher",
               j => j.HasOne<Teacher>().WithMany().HasForeignKey("TeachersId").OnDelete(DeleteBehavior.Restrict),
               j => j.HasOne<Subject>().WithMany().HasForeignKey("SubjectsId").OnDelete(DeleteBehavior.Restrict)
           );

        base.OnModelCreating(modelBuilder);
    }


    public DbSet<Auditorium> Auditoriums { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Departament> Departaments { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }



}
