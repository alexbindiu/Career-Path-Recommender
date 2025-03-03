using System.ComponentModel.DataAnnotations;

namespace CareerPathRecommender.Entities;

public class Relation
{
    [Key]
    public int RelationId { get; set; }

    [Required]
    public int JobId { get; set; }

    [Required]
    public int SkillId { get; set; }

    [Required]
    public int Experience {  get; set; }

    [Required]
    public int Usefulness { get; set; }

}
