using System.ComponentModel.DataAnnotations;

namespace l07_assignment.Models;

public class Job {
    public int JobId { get; set; }
    [Required]
    [Display(Name = "Job Title")]
    public string? JobTitle { get; set; }
    [Required]
    [Display(Name = "Job Description")]
    public string? JobDescription { get; set; }
    [Required]
    [Display(Name = "Company Name")]
    public string? CompanyName { get; set; }
    [Required, Range(0, 100)]
    [Display(Name = "Years Experience")]
    public int YearsWorked { get; set; }
}