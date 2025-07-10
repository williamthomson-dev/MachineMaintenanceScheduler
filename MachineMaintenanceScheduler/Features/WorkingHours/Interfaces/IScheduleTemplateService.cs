using MachineMaintenanceScheduler.Features.WorkingHours.Models;

namespace MachineMaintenanceScheduler.Features.WorkingHours.Interfaces
{
    public interface IScheduleTemplateService
    {
        IEnumerable<Schedule> GetAll();
        Schedule? GetByName(string name);
    }
}
