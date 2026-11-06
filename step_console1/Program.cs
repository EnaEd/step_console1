using Core.Models;
using Core.Models.Students;

{
    try
    {
        var student = Student
            .Create("John", "Doe", DateOnly.FromDateTime(DateTime.Now.AddYears(-20)))
            .WithSubjects(
                new Subject("Math", 90, ExamResult.Pass),
                new Subject("English", 45, ExamResult.Pass),
                new Subject("History", 45, ExamResult.Pass));
        
        Console.WriteLine($"s1:{student}");
        
        var student2 = Student
            .Create("Johan", "Doe", DateOnly.FromDateTime(DateTime.Now.AddYears(-20)))
            .WithPhone("123-456-7890")
            .WithSubjects(
            new Subject("Math", 70, ExamResult.Pass),
            new Subject("English", 45, ExamResult.Pass),
            new Subject("History", 45, ExamResult.Pass));
        
        Console.WriteLine($"s2:{student2}");

        Console.WriteLine(student.CalculateGPA());
        Console.WriteLine(student.HasPassedSession());
        Console.WriteLine(student == student2);
        Console.WriteLine(student != student2);
        Console.WriteLine(student > student2);
        Console.WriteLine(student < student2);
        
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
