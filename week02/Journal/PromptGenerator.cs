namespace Journal;

public class PromptGenerator
{
    List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What was the most interesting thing that happened today?",
        "Was there any opportunity for service? What did I do? Why?",
        "What is one thing you're grateful about? Why?",
        "What is something that made you smile today?",
        "What is a small victory you had today?",
        "Who did you serve today, and how did it make you feel?",
        "What scripture or quote brought you peace or insight today?"
    };
    private Random _random = new Random();
    
    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        string prompt = _prompts[index];
        
        return prompt;
    }
}