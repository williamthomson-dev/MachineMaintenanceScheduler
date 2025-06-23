using MachineMaintenanceScheduler.Features.Skills.Interfaces;
using MachineMaintenanceScheduler.Features.Skills.Models;

namespace MachineMaintenanceScheduler.Features.Skills.Services
{
    public class SkillService : ISkillService
    {
        private readonly List<Skill> _skills;
        public SkillService()
        {
            // Initialize with some default skills for demonstration purposes
            _skills = new List<Skill>
            {
                new Skill { Id = Guid.NewGuid(), Name = "Electrical" },
                new Skill { Id = Guid.NewGuid(), Name = "Mechanical" },
                new Skill { Id = Guid.NewGuid(), Name = "Hydraulic" },
                new Skill { Id = Guid.NewGuid(), Name = "Pneumatic" }
            };
        }
        public List<Skill> GetAllSkills()
        {
            return _skills;
        }

        public Skill? GetSkillByName(string name)
        {
            return _skills.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public Skill CreateSkill(string name)
        {
            var skill = new Skill 
            { 
                Id = Guid.NewGuid(), 
                Name = name 
            };

            _skills.Add(skill);
            return skill;
        }

    }
}
