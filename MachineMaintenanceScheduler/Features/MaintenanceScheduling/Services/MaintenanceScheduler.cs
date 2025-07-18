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

            // Track booked dates per technician
            var technicianSchedule = new Dictionary<Guid, HashSet<DateTime>>();

            foreach (var machine in machines)
            {
                if (machine.IsUnderMaintenance || machine.MachineMaintenanceRule == null)
                    continue;

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

                var scheduledDate = rawNextDate <= DateTime.Now
                    ? DateTime.Today.AddDays(1)
                    : rawNextDate.Date;

                // Find technician with the exact skill
                var technician = technicians.FirstOrDefault(t => t.SkillId == machine.RequiredSkillId);
                if (technician == null)
                    continue;

                // Ensure dictionary entry
                if (!technicianSchedule.ContainsKey(technician.Id))
                    technicianSchedule[technician.Id] = new HashSet<DateTime>();

                // Find next available date for this technician
                while (technicianSchedule[technician.Id].Contains(scheduledDate))
                {
                    scheduledDate = scheduledDate.AddDays(1);
                }

                // Schedule and track it
                technicianSchedule[technician.Id].Add(scheduledDate);

                plannedTasks.Add(new PlannedMaintenanceTask
                {
                    Id = Guid.NewGuid(),
                    MachineId = machine.Id,
                    Machine = machine,
                    TechnicianId = technician.Id,
                    Technician = technician,
                    MaintenanceScheduledDate = scheduledDate
                });
            }

            return plannedTasks;
        }

    }
}