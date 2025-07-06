using MachineMaintenanceScheduler.Features.WorkingHours.Models;
using MachineMaintenanceScheduler.Features.WorkingHours.Interfaces;

namespace MachineMaintenanceScheduler.Features.WorkingHours.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _repository;

        public ScheduleService(IScheduleRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Schedule>> GetAllSchedulesAsync()
        { 
            return _repository.GetAllAsync();
        }

        public Task<Schedule?> GetScheduleByIdAsync(Guid id)
        {    
            return _repository.GetByIdAsync(id);
        }
        public Task CreateScheduleAsync(Schedule schedule)
        { 
            return _repository.AddAsync(schedule); 
        }

        public Task UpdateScheduleAsync(Schedule schedule)
        {
            return _repository.UpdateAsync(schedule);
        }

        public Task DeleteScheduleAsync(Guid id)
        {
            return _repository.DeleteAsync(id);
        }
    }
}