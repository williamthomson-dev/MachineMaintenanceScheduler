using MachineMaintenanceScheduler.Features.MaintenanceRules.Interfaces;
using MachineMaintenanceScheduler.Features.MaintenanceRules.Models;
using MachineMaintenanceScheduler.Features.Skills.Interfaces;

namespace MachineMaintenanceScheduler.Features.MaintenanceRules.Services
{
    public class MaintenanceRuleService : IMaintenanceRuleService
    {
        private readonly IMaintenanceRuleRepository _maintenanceRuleRepository;

        public MaintenanceRuleService(IMaintenanceRuleRepository maintenanceRuleRepository)
        {
            _maintenanceRuleRepository = maintenanceRuleRepository;
        }
        public async Task<List<MachineMaintenanceRule>> GetAllRulesAsync()
        {
            return await _maintenanceRuleRepository.GetAllRulesAsync();
        }

        public async Task<MachineMaintenanceRule?> GetRuleByIdAsync(Guid id)
        {
            return await _maintenanceRuleRepository.GetRuleByIdAsync(id);
        }

        public async Task CreateRuleAsync(MachineMaintenanceRule rule)
        {
            await _maintenanceRuleRepository.AddRuleAsync(rule);
        }

        public async Task UpdateRuleAsync(MachineMaintenanceRule rule)
        {
            await _maintenanceRuleRepository.UpdateRuleAsync(rule);
        }

        public async Task DeleteRuleAsync(Guid id)
        {
            await _maintenanceRuleRepository.DeleteRuleAsync(id);
        }
    }
}
