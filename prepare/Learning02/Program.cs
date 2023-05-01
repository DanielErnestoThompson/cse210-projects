using System;
using System.Collections.Generic;

public class Job
{
    private string _company;
    private string _jobTitle;
    private int _startYear;
    private int _endYear;

    public Job(string company, string jobTitle, int startYear, int endYear)
    {
        _company = company;
        _jobTitle = jobTitle;
        _startYear = startYear;
        _endYear = endYear;
    }

    public string GetJobInfo()
    {
        return $"{_jobTitle} ({_company}) {_startYear}-{_endYear}";
    }
}

public class Resume
{
    private string _name;
    private List<Job> _jobs;

    public Resume(string name, List<Job> jobs)
    {
        _name = name;
        _jobs = jobs;
    }

    public void DisplayResume()
    {
        Console.WriteLine($"Name: {_name}\n");
        Console.WriteLine("Work Experience:\n");
        foreach (Job job in _jobs)
        {
            Console.WriteLine(job.GetJobInfo());
        }
    }
}

public class Program
{
    public static void Main()
    {
        List<Job> jobs = new List<Job>();
        Job job1 = new Job("Microsoft", "Software Engineer", 2019, 2022);
        Job job2 = new Job("Apple", "iOS Developer", 2017, 2019);
        jobs.Add(job1);
        jobs.Add(job2);

        Resume resume = new Resume("Daniel Thompson", jobs);
        resume.DisplayResume();
    }
}
