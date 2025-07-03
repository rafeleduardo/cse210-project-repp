using System;
using Resumes;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Architect";
        job1._company = "Microsoft";
        job1._startYear = 2021;
        job1._endYear = 2023;
        
        Job job2 = new Job();
        job2._jobTitle = "Software Engineer";
        job2._company = "Intel";
        job2._startYear = 2018;
        job2._endYear = 2021;

        Resume resume1 = new Resume();
        resume1._name = "Rafael Parra";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
        
        resume1.DisplayResume();
    }
}