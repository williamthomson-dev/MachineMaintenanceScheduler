using MachineMaintenanceScheduler.Features.MaintenanceRules.Models;

namespace MachineMaintenanceScheduler.Features.MaintenanceRules.Interfaces
{
    public interface IMaintenanceRuleRepository
    {
        Task<List<MachineMaintenanceRule>> GetAllRulesAsync();
        Task<MachineMaintenanceRule?> GetRuleByIdAsync(Guid id);
        Task AddRuleAsync(MachineMaintenanceRule rule);
        Task UpdateRuleAsync(MachineMaintenanceRule rule);
        Task DeleteRuleAsync(Guid id);
    }
}
