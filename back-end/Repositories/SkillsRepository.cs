using CareerPathRecommender.Entities;
using CareerPathRecommender.Data;
using Microsoft.EntityFrameworkCore;

namespace CareerPathRecommender.Repositories;

public class SkillsRepository
{
    private readonly AppDbContext _context;


    public SkillsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddJobAsync(Job job)
    {
        _context.Jobs.Add(job);
        await _context.SaveChangesAsync();
    }

    public async Task AddSkillAsync(Skill skill)
    {
        _context.Skills.Add(skill);
        await _context.SaveChangesAsync();
    }

    public async Task AddRelationAsync(Relation relation)
    {
        _context.Relations.Add(relation);
        await _context.SaveChangesAsync();
    }


    public async Task<List<string>> GetJobNamesAsync()
    {
        return await _context.Jobs.Select(j => j.JobName).ToListAsync();
    }


    public async Task<Job?> GetJobByNameAsync(string jobName)
    {
        return await _context.Jobs
                .FirstOrDefaultAsync(j => j.JobName.ToLower() == jobName.Trim().ToLower());
    }

    public async Task<Relation?> GetRelationAsync(int jobId, int skillId)
    {
        return await _context.Relations
                .FirstOrDefaultAsync(r => r.SkillId == skillId && r.JobId == jobId);
    }

    public async Task<Skill?> GetSkillByNameAsync(string skillName)
    {
        return await _context.Skills
                .FirstOrDefaultAsync(s => s.SkillName.ToLower() == skillName.Trim().ToLower());
    }

    public async Task<List<Skill>> GetSkillsForJobAsync(int jobId, int experience)
    {
        return await _context.Relations
        .Where(r => r.JobId == jobId && r.Experience == experience)
        .Join(_context.Skills,
              relation => relation.SkillId,
              skill => skill.SkillId,
              (relation, skill) => skill)
        .ToListAsync();
    }
}