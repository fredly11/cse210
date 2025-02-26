using Learning04;
using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Bob", "French");
        Console.WriteLine(assignment.GetSummary());
        MathAssignment math = new MathAssignment("Tim", "Math", "2.8", "12-15, 18, 20-24");
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());
        WritingAssignment writing = new WritingAssignment("Sally", "English", "Jane Austen's Approach");
        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());

    }
}