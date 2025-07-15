using MachineMaintenanceScheduler.Features.MaintenanceScheduling.Interfaces;
using MachineMaintenanceScheduler.Features.MaintenanceScheduling.Models;
using MachineMaintenanceScheduler.Features.Machines.Interfaces;
using MachineMaintenanceScheduler.Features.Technicians.Interfaces;
using MachineMaintenanceScheduler.Features.MaintenanceRules.Models;

namespace MachineMaintenanceScheduler.Features.MaintenanceScheduling.Services
{
    public class MaintenanceScheduler : IMaintenanceScheduler
    {
        private readonly IMachineService _machineService;
        private readonly ITechnicianService _technicianService;
        private readonly Random _random = new();

        public MaintenanceScheduler(IMachineService machineService, ITechnicianService technicianService)
        {
            _machineService = machineService;
            _technicianService = technicianService;
        }

        public async Task<List<PlannedMaintenanceTask>> GeneratePlannedTasksAsync()
        {
            var machines = await _machineService.GetMachinesWithMaintenanceRulesAsync();
            var technicians = await _technicianService.GetTechniciansWithSkillsAsync();

            var plannedTasks = new List<PlannedMaintenanceTask>();

            if (!machines.Any() || !technicians.Any())
                return plannedTasks;

            foreach (var machine in machines)
            {
                // Skip machines currently under maintenance or missing maintenance rules
                if (machine.IsUnderMaintenance || machine.MachineMaintenanceRule == null)
                    continue;

                // Determine next maintenance date
                var lastDate = machine.LastMaintenanceDate ?? DateTime.Now;
                var rule = machine.MachineMaintenanceRule;
                var rawNextDate = rule.IntervalType switch
                {
                    MaintenanceIntervalType.Hours => lastDate.AddHours(rule.IntervalValue),
                    MaintenanceIntervalType.Days => lastDate.AddDays(rule.IntervalValue),
                    MaintenanceIntervalType.Weeks => lastDate.AddDays(7 * rule.IntervalValue),
                    MaintenanceIntervalType.Months => lastDate.AddMonths(rule.IntervalValue),
                    MaintenanceIntervalType.Years => lastDate.AddYears(rule.IntervalValue),
                    _ => lastDate
                };

                // Make sure maintenance is scheduled in the future
                var adjustedNextDate = rawNextDate <= DateTime.Now
                    ? DateTime.Today.AddDays(1)
                    : rawNextDate;

                var nextMaintenanceDate = adjustedNextDate.Date;

                // Match technician with exact skill
                var technician = technicians.FirstOrDefault(t => t.SkillId == machine.RequiredSkillId);

                if (technician == null)
                    continue; // No available technician with required skill

                plannedTasks.Add(new PlannedMaintenanceTask
                {
                    Id = Guid.NewGuid(),
                    MachineId = machine.Id,
                    Machine = machine,
                    TechnicianId = technician.Id,
                    Technician = technician,
                    MaintenanceScheduledDate = nextMaintenanceDate
                });
            }

            return plannedTasks;
        }


    }
}