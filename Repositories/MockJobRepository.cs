using System.Collections.Generic;
using System.Linq;
using l07_assignment.Models;

namespace l07_assignment.Repositories;

public class MockJobRepository : IJobRepository
{
    private List<Job> mockJobs;
    public MockJobRepository() 
    {
        mockJobs = new List<Job> {
            new Job {
                JobId = 1,
                CompanyName = "ABC Corp.",
                JobTitle = "Junior Developer",
                JobDescription = "Created new features for web application and fixed bugs.",
                YearsWorked = 3
            },
            new Job {
                JobId = 2,
                CompanyName = "ACME LTD.",
                JobTitle = "Software Engineer",
                JobDescription = "Designed and developed full-stack web applications.",
                YearsWorked = 2
            }
        };
    }
    public Job CreateJob(Job job)
    {
        var maxId = mockJobs.Select(j => j.JobId)
            .DefaultIfEmpty()
            .Max();

        job.JobId = maxId + 1;

        mockJobs.Add(job);
        return job;
    }

    public void DeleteJobById(int jobId)
    {
        var jobToRemove = mockJobs.Find(j => j.JobId == jobId);
        if (jobToRemove != null) {
            mockJobs.Remove(jobToRemove);
        }
    }

    public IEnumerable<Job> GetAllJobs()
    {
        return mockJobs;
    }

    public Job? GetJobById(int jobId)
    {
        return mockJobs.Find(j => j.JobId == jobId);
    }

    public Job? UpdateJob(Job job)
    {
        var existingJob = mockJobs.Find(j => j.JobId == job.JobId);

        if (existingJob != null) {
            existingJob.CompanyName = job.CompanyName;
            existingJob.JobTitle = job.JobTitle;
            existingJob.JobDescription = job.JobDescription;
            existingJob.YearsWorked = job.YearsWorked;
        }
        return existingJob;
    }
}
