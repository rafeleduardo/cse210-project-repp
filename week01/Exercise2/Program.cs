using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage (0-100)? ");
        string gradeString = Console.ReadLine();
        int grade = 0;
        string letter;
        string sign = "";
        

        if (gradeString != null)
        {
            grade = int.Parse(gradeString);
            if (grade is > 97 or < 60)
                sign = "";
            else if (grade % 10 >= 7)
                sign = "+";
            else if (grade % 10 < 3)
                sign = "-";
            else
                sign = "";
        }

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";;
        }
        else
        {
            letter = "F";
        }
        
        Console.WriteLine("Your grade is {0}{1}.", letter, sign);
        
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You approved the course!");
        }
        else
        {
            Console.WriteLine("Prepare yourself for the next course!");
        }
    }
}