public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<int> _usedPromptIndices;
    private List<int> _usedQuestionIndices;

    public ReflectionActivity() : base(
        "Reflection", 
        "This activity will help you reflect on times in your life when you have shown strength and resilience." +
        "\nThis will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you overcame a personal fear."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        _usedPromptIndices = new List<int>();
        _usedQuestionIndices = new List<int>();
    }

    protected override void PerformActivity()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($"--- {prompt} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.Clear();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.Write($"> {question} ");
            ShowSpinner(10);
            Console.WriteLine();
        }
        Console.WriteLine();
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

    private string GetRandomQuestion()
    {
        if (_usedQuestionIndices.Count == _questions.Count)
        {
            _usedQuestionIndices.Clear();
        }
        int index;
        do
        {
            index = _random.Next(_questions.Count);
        } while (_usedQuestionIndices.Contains(index));

        _usedQuestionIndices.Add(index);
        return _questions[index];
    }
}
