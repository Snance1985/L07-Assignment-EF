using l07_assignment.Models;
using l07_ef.Migrations;

namespace l07_assignment.Repositories;

public class EFJobRepository : IJobRepository
{
    private readonly JobDbContext _context;

    public EFJobRepository(JobDbContext context)
    {
        _context = context;
    }

    Job IJobRepository.CreateJob(Job newJob)
    {
        _context.Job.Add(newJob);
        _context.SaveChanges();
        return newJob;
    }

    void IJobRepository.DeleteJobById(int jobId)
    {
        var job = _context.Job.Find(jobId);
        if (job != null)
        {
            _context.Job.Remove(job);
            _context.SaveChanges();
        }
    }

    IEnumerable<Job> IJobRepository.GetAllJobs()
    {
        return _context.Job.ToList();
    }

    Job? IJobRepository.GetJobById(int jobId)
    {
        return _context.Job.SingleOrDefault(c => c.JobId == jobId);
    }

    Job? IJobRepository.UpdateJob(Job newJob)
    {
        var originalJob = _context.Job.Find(newJob.JobId);
        if (originalJob != null)
        {
            originalJob.JobTitle = newJob.JobTitle;
            originalJob.JobDescription = newJob.JobDescription;
            originalJob.CompanyName = newJob.CompanyName;
            originalJob.YearsWorked = newJob.YearsWorked;
            _context.SaveChanges();
        }
        return originalJob;
    }
}