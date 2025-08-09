using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<int> _usedPromptIndices;

    public ListingActivity() : base(
        "Listing", 
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _usedPromptIndices = new List<int>();
    }

    protected override void PerformActivity()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        Console.WriteLine($"--- {prompt} ---\n");
        Console.Write("You may begin in: ");
        ShowCountdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        List<string> items = new List<string>();

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
        ShowSpinner(3);
    }

    private string GetRandomPrompt()
    {
        if (_usedPromptIndices.Count == _prompts.Count)
        {
            _usedPromptIndices.Clear();
        }
        int index;
        do
        {
            index = _random.Next(_prompts.Count);
        } while (_usedPromptIndices.Contains(index));

        _usedPromptIndices.Add(index);
        return _prompts[index];
    }
}
