using MachineMaintenanceScheduler.Features.Skills.Interfaces;
using MachineMaintenanceScheduler.Features.Skills.Models;

namespace MachineMaintenanceScheduler.Features.Skills.Repositories
{
    public class InMemorySkillRepository : ISkillRepository
    {
        private readonly List<Skill> _skills = new();

        public InMemorySkillRepository()
        {
            _skills.AddRange(new List<Skill>
            {
                new Skill { Id = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), Name = "Electrical" },
                new Skill { Id = Guid.Parse("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), Name = "Mechanical" },
                new Skill { Id = Guid.Parse("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"), Name = "Hydraulic" },
                new Skill { Id = Guid.Parse("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f80"), Name = "Pneumatic" }
            });
        }

        public Task<List<Skill>> GetAllSkillsAsync()
        {
            return Task.FromResult(_skills);
        }

        public Task<Skill?> GetSkillByIdAsync(Guid id)
        {
            var skill = _skills.FirstOrDefault(s => s.Id == id);
            return Task.FromResult(skill);
        }

        public Task AddSkillAsync(Skill skill)
        {
            _skills.Add(skill);
            return Task.CompletedTask;
        }

        public Task UpdateSkillAsync(Skill skill)
        {
            var existing = _skills.FirstOrDefault(s => s.Id == skill.Id);
            if (existing == null) throw new KeyNotFoundException("Skill not found.");

            existing.Name = skill.Name;
            return Task.CompletedTask;
        }

        public Task DeleteSkillAsync(Guid id)
        {
            var skill = _skills.FirstOrDefault(s => s.Id == id);
            if (skill != null) _skills.Remove(skill);
            return Task.CompletedTask;
        }
    }
}
