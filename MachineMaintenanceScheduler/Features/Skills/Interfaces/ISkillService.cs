using MachineMaintenanceScheduler.Features.Skills.Models;

namespace MachineMaintenanceScheduler.Features.Skills.Interfaces
{
    public interface ISkillService
    {
        Task<List<Skill>> GetAllSkillsAsync(); 
        Task<Skill?> GetSkillByIdAsync(Guid Id); 
        Task CreateSkillAsync(Skill skill);
        Task UpdateSkillAsync(Skill skill);
        Task DeleteSkillAsync(Guid id);
    }
}
