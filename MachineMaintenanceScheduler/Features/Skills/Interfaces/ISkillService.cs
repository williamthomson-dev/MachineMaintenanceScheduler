using MachineMaintenanceScheduler.Features.Skills.Models;

namespace MachineMaintenanceScheduler.Features.Skills.Interfaces
{
    public interface ISkillService
    {
        List<Skill> GetAllSkills(); 
        Skill? GetSkillByName(string name); 
        Skill CreateSkill(string name); 
    }
}
