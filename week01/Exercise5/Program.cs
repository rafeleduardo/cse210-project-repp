using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        var name = PromptUserName();
        var number = PromptUserNumber();
        var square = SquareNumber(number);
        DisplayResult(name, square);
    }
    
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string number = Console.ReadLine();
        return int.Parse(number);
    }
    
    static int SquareNumber(int x)
    {
        return x * x;
    }
    
    static void DisplayResult(string name, int number)
    {
        Console.WriteLine("{0}, the square of your number is {1}", name, number);
    }
}