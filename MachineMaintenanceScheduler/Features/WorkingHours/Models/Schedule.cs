namespace MachineMaintenanceScheduler.Features.WorkingHours.Models
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ScheduleBlock> ScheduleBlocks { get; set; } = new();
    }
}
    