
using l07_assignment.Models;

namespace l07_assignment.Repositories;
public interface IJobRepository {
    IEnumerable<Job> GetAllJobs();
    Job? GetJobById(int jobId);
    Job CreateJob(Job job);
    Job? UpdateJob(Job job);
    void DeleteJobById(int jobId);
}
