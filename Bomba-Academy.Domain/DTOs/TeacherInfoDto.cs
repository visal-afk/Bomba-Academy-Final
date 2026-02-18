namespace Bomba_Academy.Domain.DTOs;

public class TeacherInfoDto
{
    public int Id { get; set; }
    public string TeacherName { get; set; }
    public List<string> SubjectNames { get; set; }
}
