using System.Text;

namespace Core.Models;

public class Group
{
    public required string Name { get; set; }
    public required Specific Specific { get; set; }
    public List<Student> Students { get; set; } = [];

    public Group()
    {
        Name = "New empty group";
        Specific = Specific.None;
        Students = [];
    }

    public Group CopyWithNewName(string name)
    {
        var group = (Group)MemberwiseClone();
        group.Name = name;
        group.Students = [.. Students.Select(s => s.Copy())];

        return group;
    }

    public string GetStudentsDisplayString()
    {
        var builder = new StringBuilder();
        builder.Append($"Group: {Name}\nSpecific:{Specific}\n");
        
        Students
            .OrderBy(x => x.FullName)
            .ToList()
            .ForEach(x => builder.Append($"\t{x.FullName}"));

        return builder.ToString();
    }

    public bool AddStudents(Student[] students)
    {
        var newStudents = students
            .Where(x => !Students.Select(s => s.Id).Contains(x.Id));
        
        Students.AddRange(newStudents);

        return true;
    }

    public bool DeleteStudents(Student[] students)
    {
        Students.RemoveAll(x => students.Select(s => s.Id).Contains(x.Id));
        
        return true;
    }

    public bool MoveStudent(Group targetGroup, Guid studentId)
    {
        var student = Students.FirstOrDefault(x => x.Id == studentId) ?? throw new Exception("Not found");
        
        targetGroup.AddStudents([student]);
        DeleteStudents([student]);

        return true;
    }

    public Student[] GetFailedStudent()
    {
        return [.. Students.Where(x => x.Subjects.Any(s => s.ExamResult == ExamResult.Fail))];
    }

    public bool KickTheWorst()
    {
        var worst = GetTheWorst();
        
        return DeleteStudents([worst]);
    }
    
    private Student GetTheWorst()
    {
        var worst = Students
            .Select(x => (Student: x, LooseCount: x.Subjects.Count(s => s.ExamResult == ExamResult.Fail)))
            .MaxBy(x => x.LooseCount);
        
        return worst.Student;
    }
}