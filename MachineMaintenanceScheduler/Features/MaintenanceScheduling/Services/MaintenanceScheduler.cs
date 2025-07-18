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

            // Track each technician’s scheduled dates
            var technicianSchedule = new Dictionary<Guid, HashSet<DateTime>>();

            foreach (var machine in machines.OrderBy(x =>x.LastMaintenanceDate))
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

                // Get all technicians with the required skill
                var skilledTechnicians = technicians
                    .Where(t => t.SkillId == machine.RequiredSkillId)
                    .ToList();

                if (!skilledTechnicians.Any())
                    continue;

                bool scheduled = false;

                // Try to assign the first available technician
                while (!scheduled)
                {
                    foreach (var tech in skilledTechnicians)
                    {
                        if (!technicianSchedule.ContainsKey(tech.Id))
                            technicianSchedule[tech.Id] = new HashSet<DateTime>();

                        if (!technicianSchedule[tech.Id].Contains(scheduledDate))
                        {
                            technicianSchedule[tech.Id].Add(scheduledDate);

                            plannedTasks.Add(new PlannedMaintenanceTask
                            {
                                Id = Guid.NewGuid(),
                                MachineId = machine.Id,
                                Machine = machine,
                                TechnicianId = tech.Id,
                                Technician = tech,
                                MaintenanceScheduledDate = scheduledDate
                            });

                            scheduled = true;
                            break;
                        }
                    }

                    if (!scheduled)
                        scheduledDate = scheduledDate.AddDays(1); // all booked — try next day
                }
            }

            return plannedTasks;
        }

    }
}