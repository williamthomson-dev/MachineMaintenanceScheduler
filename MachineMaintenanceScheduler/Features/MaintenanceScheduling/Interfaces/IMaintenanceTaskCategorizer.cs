using MachineMaintenanceScheduler.Features.MaintenanceScheduling.Models;

namespace MachineMaintenanceScheduler.Features.MaintenanceScheduling.Interfaces
{
    public interface IMaintenanceTaskCategorizer
    {
        (Dictionary<DateTime, List<PlannedMaintenanceTask>> Overdue, Dictionary<DateTime, 
            List<PlannedMaintenanceTask>> ThisWeek, Dictionary<DateTime, List<PlannedMaintenanceTask>> Later) 
            Categorize(List<PlannedMaintenanceTask> tasks);
    }
}
