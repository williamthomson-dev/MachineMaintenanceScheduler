using MachineMaintenanceScheduler.Features.Machines.Models;
using MachineMaintenanceScheduler.Features.Technicians.Models;

namespace MachineMaintenanceScheduler.Features.MaintenanceScheduling.Models
{
    public class PlannedMaintenanceTask
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime MaintenanceScheduledDate { get; set; }
        public Guid MachineId { get; set; }
        public Machine Machine { get; set; } = default!;
        public Guid TechnicianId { get; set; } 
        public Technician Technician { get; set; } = default!;
    }
}
