using MachineMaintenanceScheduler.Features.MaintenanceRules.Interfaces;
using MachineMaintenanceScheduler.Features.MaintenanceRules.Models;
using MachineMaintenanceScheduler.Features.Skills.Models;

namespace MachineMaintenanceScheduler.Features.MaintenanceRules.Repositories
{
    public class InMemoryMaintenanceRuleRepository : IMaintenanceRuleRepository
    {
        private readonly List<MachineMaintenanceRule> _machineMaintenanceRules = new();

        public Task<List<MachineMaintenanceRule>> GetAllRulesAsync()
        {
            return Task.FromResult(_machineMaintenanceRules);
        }

        public Task<MachineMaintenanceRule?> GetRuleByIdAsync(Guid id)
        {
            var machineMaintenanceRule = _machineMaintenanceRules.FirstOrDefault(s => s.Id == id);
            return Task.FromResult(machineMaintenanceRule);
        }

        public Task AddRuleAsync(MachineMaintenanceRule rule)
        {
            _machineMaintenanceRules.Add(rule);
            return Task.CompletedTask;
        }
        public Task UpdateRuleAsync(MachineMaintenanceRule rule)
        {
            var existing = _machineMaintenanceRules.FirstOrDefault(s => s.Id == rule.Id);
            if (existing == null) throw new KeyNotFoundException("Maintenance Rule not found.");

            existing.Name = rule.Name;
            existing.IntervalValue = rule.IntervalValue;
            existing.IntervalType = rule.IntervalType;
            return Task.CompletedTask;
        }

        public Task DeleteRuleAsync(Guid id)
        {
            var machineMaintenanceRule = _machineMaintenanceRules.FirstOrDefault(s => s.Id == id);
            if (machineMaintenanceRule != null) _machineMaintenanceRules.Remove(machineMaintenanceRule);
            return Task.CompletedTask;
        }
    }
}
