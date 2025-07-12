using MachineMaintenanceScheduler.Features.MaintenanceScheduling.Interfaces;
using MachineMaintenanceScheduler.Features.MaintenanceScheduling.Models;
using MachineMaintenanceScheduler.Features.Machines.Interfaces;
using MachineMaintenanceScheduler.Features.Technicians.Interfaces;

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

        /// <summary>
        /// Dummy implementation of a scheduling engine.
        /// Randomly assigns a technician to each machine and picks a maintenance date 1–14 days from today.
        /// This is a placeholder and should be replaced with real scheduling logic later.
        /// </summary>
        public async Task<List<PlannedMaintenanceTask>> GeneratePlannedTasksAsync()
        {
            var machines = await _machineService.GetMachinesWithMaintenanceRulesAsync();
            var technicians = await _technicianService.GetTechniciansWithSkillsAsync();

            var plannedTasks = new List<PlannedMaintenanceTask>();

            if (!technicians.Any() || !machines.Any())
                return plannedTasks;

            foreach (var machine in machines)
            {
                var technician = technicians[_random.Next(technicians.Count)];

                plannedTasks.Add(new PlannedMaintenanceTask
                {
                    Id = Guid.NewGuid(),
                    MachineId = machine.Id,
                    Machine = machine,
                    TechnicianId = technician.Id,
                    Technician = technician,
                    MaintenanceScheduledDate = DateTime.Today.AddDays(_random.Next(1, 15)) // 1–14 days from now
                });
            }

            return plannedTasks;
        }
    }
}
