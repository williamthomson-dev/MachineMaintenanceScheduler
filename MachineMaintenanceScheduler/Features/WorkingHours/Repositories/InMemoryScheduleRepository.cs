using MachineMaintenanceScheduler.Features.WorkingHours.Interfaces;
using MachineMaintenanceScheduler.Features.WorkingHours.Models;

namespace MachineMaintenanceScheduler.Features.WorkingHours.Repositories
{
    public class InMemoryScheduleRepository : IScheduleRepository
    {
        private readonly List<Schedule> _schedules = new();

        public Task<List<Schedule>> GetAllAsync()
        {
            return Task.FromResult(_schedules.ToList());
        }

        public Task<Schedule?> GetByIdAsync(Guid id)
        {
            return Task.FromResult(_schedules.FirstOrDefault(s => s.Id == id));
        }

        public Task AddAsync(Schedule schedule)
        {
            schedule.Id = Guid.NewGuid();
            _schedules.Add(schedule);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Schedule schedule)
        {
            var existing = _schedules.FirstOrDefault(s => s.Id == schedule.Id);
            if (existing != null)
            {
                existing.Name = schedule.Name;
                existing.ScheduleBlocks = schedule.ScheduleBlocks;
            }
            return Task.CompletedTask; 
        }

        public Task DeleteAsync(Guid id)
        {
            var schedule = _schedules.FirstOrDefault(s => s.Id == id);
            if (schedule != null)
                _schedules.Remove(schedule);
            return Task.CompletedTask;
        }
    }
}