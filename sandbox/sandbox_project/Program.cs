using System;

public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        Console.WriteLine("Hello Sandbox World!");



        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        numbers.Insert(2, 322);
        Console.WriteLine(numbers[2]);
        Console.WriteLine($"The Count is:{numbers.Count}");

        //xD
        foreach (var item in numbers)
        {
            Console.WriteLine(item);
        }
    }
}

