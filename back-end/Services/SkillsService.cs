using CareerPathRecommender.Repositories;
using System.Text.RegularExpressions;
using CareerPathRecommender.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace CareerPathRecommender.Services;

public class SkillsService
{
    private readonly SkillsRepository _repository;
    private readonly AiService _aiService;


    public SkillsService(SkillsRepository repository, AiService aiService)
    {
        _repository = repository;
        _aiService = aiService;
    }


    public async Task<List<string>> GetRequiredSkillsAsync(string jobName, int experience)
    {
        var jobId = await GetJobIdByName(jobName);

        if (jobId == -1)
        {
            await AddJobAsync(parseName(jobName));
            jobId = await GetJobIdByName(jobName);
            return await GenerateNewSkills(jobName, jobId, experience);
        }
              
        var skills = await _repository.GetSkillsForJobAsync(jobId, experience);            
        if (skills == null || skills.Count == 0) return await GenerateNewSkills(jobName, jobId, experience);     

        return skills.Select(s => s.SkillName).ToList();
    }


    public async Task AddJobAsync(string jobName)
    {
        var new_job = new Job { JobName = jobName };
        await _repository.AddJobAsync(new_job);
    }


    public async Task AddSkillsAsync(List<string> skills)
    {
        foreach (var skill in skills)
            if (await _repository.GetSkillByNameAsync(skill) == null)
            {
                var new_skill = new Skill { SkillName = skill };
                await _repository.AddSkillAsync(new_skill);
            }
    }

    public async Task AddRelationsAsync(int jobId, List<string> skills, int experience)
    {
        var index = 0;
        var usefulness = 2;

        foreach (var skill in skills)
        {
            index++;
            var current = await _repository.GetSkillByNameAsync(skill);
            if (current == null) continue;

            if (await _repository.GetRelationAsync(jobId, current.SkillId) == null)
            {
                if (index >= 9) usefulness = 0;
                else if (index >= 5) usefulness = 1;

                var new_relation = new Relation {JobId = jobId, SkillId = current.SkillId, Experience = experience, Usefulness = usefulness};
                await _repository.AddRelationAsync(new_relation);
            }
        }
    }


    public async Task<List<string>> GenerateNewSkills(string jobName, int jobId, int experience)
    {
        var experience_level = setExperience(experience);

        var skills = await _aiService.GetJobSkillsAsync(jobName, experience_level);        
        if (skills == null) return new List<string>();

        List<string> parsed_skills = skills.Split('~')
                                    .Select(word => word.Trim()) 
                                    .ToList();

        await AddSkillsAsync(parsed_skills);
        await AddRelationsAsync(jobId, parsed_skills, experience);

        return parsed_skills ?? new List<string>();
    }


    public async Task<int> GetJobIdByName(string jobName)
    {
        jobName = parseName(jobName);
        
        var job = await _repository.GetJobByNameAsync(jobName);

        if (job == null) return -1;
        return job.JobId;
    }

    public string setExperience(int experience)
    {
        if (experience == 0) return "Intern";
        else if (experience == 1) return "Junior";
        else if (experience == 2) return "Middle";
        else if (experience == 3) return "Senior";

        return "";
    }

    public string parseName(string name)
    {
        name = name.Trim().ToLower();
        name = Regex.Replace(name, @"\s+", " ");
        return name;
    }
}