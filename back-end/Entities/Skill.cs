using System.ComponentModel.DataAnnotations;

namespace CareerPathRecommender.Entities;

public class Skill
{
    [Key]
    public int SkillId { get; set; }
    public string SkillName { get; set; } = null!;
}