using MachineMaintenanceScheduler.Features.WorkingHours.Models;

namespace MachineMaintenanceScheduler.Features.WorkingHours.Interfaces
{
    public interface IScheduleService
    {
        Task<List<Schedule>> GetAllSchedulesAsync();
        Task<Schedule?> GetScheduleByIdAsync(Guid id);
        Task CreateScheduleAsync(Schedule schedule);
        Task UpdateScheduleAsync(Schedule schedule);
        Task DeleteScheduleAsync(Guid id);
    }
}