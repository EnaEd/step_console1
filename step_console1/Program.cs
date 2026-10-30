using Core.Models;

{
    try
    {
        var student = new Student("Jhon", "Doe");
        var group = new Group
        {
            Name = "test",
            Specific = Specific.Some,
        };
        var groupNew = group.CopyWithNewName("test2");

        group.AddStudents([student]);
        Console.WriteLine(group.GetStudentsDisplayString());
        Console.WriteLine(groupNew.GetStudentsDisplayString());

        Console.WriteLine("move");
        group.MoveStudent(groupNew, student.Id);
        Console.WriteLine(group.GetStudentsDisplayString());
        Console.WriteLine(groupNew.GetStudentsDisplayString());

        Console.WriteLine("add worst");
        groupNew.AddStudents([
            new Student("test", "test")
            {
                Subjects = new() { new Subject("Sub", 3, ExamResult.Fail) }
            }
        ]);
        Console.WriteLine(group.GetStudentsDisplayString());
        Console.WriteLine(groupNew.GetStudentsDisplayString());

        Console.WriteLine("kick worst");
        groupNew.KickTheWorst();
        Console.WriteLine(group.GetStudentsDisplayString());
        Console.WriteLine(groupNew.GetStudentsDisplayString());
    }
    //just for fun
    catch (Exception e) when (e.Message == "Not found")
    {
        Console.WriteLine("Was entered bad data");
        throw;
    }
}
