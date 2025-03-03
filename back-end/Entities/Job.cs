using System.ComponentModel.DataAnnotations;

namespace CareerPathRecommender.Entities;

public class Job
{
    [Key]
    public int JobId { get; set; }
    public string JobName { get; set; } = null!;
}
