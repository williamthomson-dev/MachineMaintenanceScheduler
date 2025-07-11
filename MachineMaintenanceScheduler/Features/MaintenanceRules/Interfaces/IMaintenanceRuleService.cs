using MachineMaintenanceScheduler.Features.MaintenanceRules.Models;

namespace MachineMaintenanceScheduler.Features.MaintenanceRules.Interfaces
{
    public interface IMaintenanceRuleService
    {
            
        Task<List<MachineMaintenanceRule>> GetAllRulesAsync();
        Task<MachineMaintenanceRule?> GetRuleByIdAsync(Guid id);
        Task CreateRuleAsync(MachineMaintenanceRule rule);
        Task UpdateRuleAsync(MachineMaintenanceRule rule);
        Task DeleteRuleAsync(Guid id);


    }
}
