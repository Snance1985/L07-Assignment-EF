using l07_assignment.Repositories;
using l07_assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace l07_assignment.Controllers;

public class JobController : Controller
{
    private readonly ILogger<JobController> _logger;
    private readonly IJobRepository _jobRepository;

    public JobController(ILogger<JobController> logger, IJobRepository repository)
    {
        _logger = logger;
        _jobRepository = repository;
    }

    public IActionResult List()
    {
        return View(_jobRepository.GetAllJobs());
    }

    public IActionResult Detail(int id) 
    {
        var job = _jobRepository.GetJobById(id);

        if (job == null) {
            return RedirectToAction("List");
        }

        return View(job);
    }

    [HttpPost]
    public IActionResult Detail(Job job) 
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        
        _jobRepository.UpdateJob(job);
        
        return RedirectToAction("List");
    }

    [HttpGet]
    public IActionResult Add() 
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Job job) 
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        
        _jobRepository.CreateJob(job);

        return RedirectToAction("List");
    }

    public IActionResult Delete(int id) 
    {
        _jobRepository.DeleteJobById(id);
        
        return RedirectToAction("List");
    }
}
