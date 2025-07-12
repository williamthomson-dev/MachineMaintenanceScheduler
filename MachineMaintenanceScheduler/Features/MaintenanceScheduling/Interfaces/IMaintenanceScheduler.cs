using MachineMaintenanceScheduler.Features.MaintenanceScheduling.Models;

namespace MachineMaintenanceScheduler.Features.MaintenanceScheduling.Interfaces
{
    public interface IMaintenanceScheduler
    {
        Task<List<PlannedMaintenanceTask>> GeneratePlannedTasksAsync();
    }
}
