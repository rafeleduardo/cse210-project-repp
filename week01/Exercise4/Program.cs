using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int largestNumber = 0;
        int smallestPositive = 999;
        List<int> numberList = new List<int>();

        while (true)
        {
            Console.Write("Enter number: ");
            int numberInput = int.Parse(Console.ReadLine());

            if (numberInput == 0)
                break;
            
            numberList.Add(numberInput);
                
            if (numberInput > largestNumber)
                largestNumber = numberInput;
                
            if (numberInput > 0 && numberInput < smallestPositive)
                smallestPositive = numberInput;
        }

        int sum = 0;
        foreach (int v in numberList)
            sum += v;

        float average = 0;
        
        if (numberList.Count > 0)
            average = (float) sum / numberList.Count;
            
        
        Console.WriteLine("The sum is: {0}", sum);
        Console.WriteLine("The average is: {0}", average);
        if (numberList.Count > 0)
        {
            Console.WriteLine("The largest number is: {0}", largestNumber);
            Console.WriteLine("The smallest positive number is: {0}", smallestPositive);
            Console.WriteLine("The sorted list is: ");
            numberList.Sort();
            foreach (int v in numberList)
                Console.WriteLine(v);
        }
        else
        {
            Console.WriteLine("No positive numbers were provided.");
            Console.WriteLine("The list is empty.");
        }
    }
}