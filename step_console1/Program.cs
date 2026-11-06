using Core.Models;
using Core.Models.Students;

{
    try
    {
        var subjectBase = new Subject("Math", 90, ExamResult.Pass);
        var student = Student
            .Create("John", "Doe", DateOnly.FromDateTime(DateTime.Now.AddYears(-20)))
            .WithSubjects(
                subjectBase,
                subjectBase with { Title = "English", Mark = 45 },
                subjectBase with { Title = "History", Mark = 45 });

        Console.WriteLine($"s1:{student}");

        var student2 = Student
            .Create("Johan", "Doe", DateOnly.FromDateTime(DateTime.Now.AddYears(-20)))
            .WithPhone("123-456-7890")
            .WithSubjects(
                subjectBase with { Mark = 70 },
                subjectBase with { Title = "English", Mark = 50 },
                subjectBase with { Title = "History", Mark = 35 });
        
        Console.WriteLine($"s2:{student2}");

        Console.WriteLine(student.CalculateGPA());//60
        Console.WriteLine(student.HasPassedSession());//true
        Console.WriteLine(student2.CalculateGPA());//51.66
        
        Console.WriteLine(student == student2);//false 60-> 51.66
        Console.WriteLine(student != student2);//true  60-> 51.66
        
        Console.WriteLine(student > student2);//true  60-> 51.66
        Console.WriteLine(student < student2);//false  60-> 51.66
        
        var group = new Group
        {
            Name = "Group 1",
            Specific = Specific.Some,
            Students = [student, student2]
        };

        Console.WriteLine(group["Doe"]?.ToString() ?? "Not found");
    }
    //just for fun
    catch (Exception e) when (e.Message == "Not found")
    {
        Console.WriteLine("Was entered bad data");
        throw;
    }
}
