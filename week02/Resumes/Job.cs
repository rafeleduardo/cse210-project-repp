namespace Resumes;

public class Job
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    public void DisplayJobDetails()
    {
        Console.WriteLine("{0} ({1}) {2}-{3}", _jobTitle, _company, _startYear, _endYear);
    }
}