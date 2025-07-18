using MachineMaintenanceScheduler.Features.MaintenanceRules.Interfaces;
using MachineMaintenanceScheduler.Features.MaintenanceRules.Models;
using MachineMaintenanceScheduler.Features.Skills.Models;

namespace MachineMaintenanceScheduler.Features.MaintenanceRules.Repositories
{
    public class InMemoryMaintenanceRuleRepository : IMaintenanceRuleRepository
    {
        private readonly List<MachineMaintenanceRule> _machineMaintenanceRules = new();

        public InMemoryMaintenanceRuleRepository()
        {
            _machineMaintenanceRules.AddRange(new List<MachineMaintenanceRule>
            {
                new MachineMaintenanceRule
                {
                    Id = Guid.Parse("c85bff1d-2c41-4a4b-be63-960182d6401a"),
                    Name = "Every 100 Hours",
                    IntervalValue = 100,
                    IntervalType = MaintenanceIntervalType.Hours
                },
                new MachineMaintenanceRule
                {
                    Id = Guid.Parse("9b8f47f5-497d-446b-a981-3df82c6213ab"),
                    Name = "Every 30 Days",
                    IntervalValue = 30,
                    IntervalType = MaintenanceIntervalType.Days
                },
                new MachineMaintenanceRule
                {
                    Id = Guid.Parse("e863fd8a-155f-4d5b-933a-6649663e2bf2"),
                    Name = "Every 1 Year",
                    IntervalValue = 1,
                    IntervalType = MaintenanceIntervalType.Years
                }
            });

        }
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
