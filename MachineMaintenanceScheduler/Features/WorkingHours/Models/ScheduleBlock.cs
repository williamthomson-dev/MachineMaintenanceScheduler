namespace MachineMaintenanceScheduler.Features.WorkingHours.Models
{
    public class ScheduleBlock
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; } = "";

        public Guid ScheduleId { get; set; }
        public Schedule? Schedule { get; set; } // Navigation property for the parent schedule
    }
}
