using Microsoft.AspNetCore.Mvc;
using CareerPathRecommender.Services;

namespace CareerPathRecommender.API.Controllers;

[ApiController]
[Route("api")]
public class SkillsController : ControllerBase
{
    private readonly SkillsService _cvService;

    public SkillsController(SkillsService cvService)
    {
        _cvService = cvService;
    }

    [HttpGet("skills/filter")]
    public async Task<IActionResult> GetSkills([FromQuery] string jobTitle, [FromQuery] int experience)
    {
        var skills = await _cvService.GetRequiredSkillsAsync(jobTitle, experience);
        if (skills.Count == 0) return Ok("Oh.. It seems like there is not a skill..");
        return Ok(skills);
    }
}
