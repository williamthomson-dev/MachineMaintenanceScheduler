using MachineMaintenanceScheduler.Features.MaintenanceScheduling.Interfaces;
using MachineMaintenanceScheduler.Features.MaintenanceScheduling.Models;

namespace MachineMaintenanceScheduler.Features.MaintenanceScheduling.Services
{
    public class MaintenanceTaskCategorizer : IMaintenanceTaskCategorizer
    {
        public (Dictionary<DateTime, List<PlannedMaintenanceTask>> Overdue,
                Dictionary<DateTime, List<PlannedMaintenanceTask>> ThisWeek,
                Dictionary<DateTime, List<PlannedMaintenanceTask>> Later)
            Categorize(List<PlannedMaintenanceTask> tasks)
        {
            var today = DateTime.Today;
            var endOfWeek = today.AddDays(7);

            var overdue = tasks
                .Where(t => t.IsOverdue)
                .GroupBy(t => t.MaintenanceScheduledDate.Date)
                .ToDictionary(g => g.Key, g => g.ToList());

            var thisWeek = tasks
                .Where(t => !t.IsOverdue && t.MaintenanceScheduledDate.Date <= endOfWeek)
                .GroupBy(t => t.MaintenanceScheduledDate.Date)
                .ToDictionary(g => g.Key, g => g.ToList());

            var later = tasks
                .Where(t => !t.IsOverdue && t.MaintenanceScheduledDate.Date > endOfWeek)
                .GroupBy(t => t.MaintenanceScheduledDate.Date)
                .ToDictionary(g => g.Key, g => g.ToList());

            return (overdue, thisWeek, later);
        }
    }

}
