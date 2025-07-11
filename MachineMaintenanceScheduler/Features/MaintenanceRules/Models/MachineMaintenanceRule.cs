using MachineMaintenanceScheduler.Features.Machines.Models;

namespace MachineMaintenanceScheduler.Features.MaintenanceRules.Models
{
    public class MachineMaintenanceRule
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public int IntervalValue { get; set; } // e.g. 100
        public MaintenanceIntervalType IntervalType { get; set; } // e.g. Daily, Hourly, Monthly etc
    }
}
