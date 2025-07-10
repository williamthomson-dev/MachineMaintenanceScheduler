using MachineMaintenanceScheduler.Features.WorkingHours.Interfaces;
using MachineMaintenanceScheduler.Features.WorkingHours.Models;

namespace MachineMaintenanceScheduler.Features.WorkingHours.Services
{
    public class ScheduleTemplateService : IScheduleTemplateService
    {
        private readonly List<Schedule> _templates;

        public ScheduleTemplateService()
        {
            _templates = CreateTemplates();
        }

        private static List<Schedule> CreateTemplates()
        {
            return new List<Schedule>
            {
                new()
                {                        
                    Id = Guid.NewGuid(),
                    Name = "Day Shift",
                    ScheduleBlocks = Enumerable.Range(1, 5) // Mon–Fri
                        .Select(d => new ScheduleBlock
                        {
                            Id = Guid.NewGuid(),
                            DayOfWeek = (DayOfWeek)d,
                            StartTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + d).AddHours(9),
                            EndTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + d).AddHours(17),
                        }).ToList()
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Weekend Shift",
                    ScheduleBlocks = new List<ScheduleBlock>
                    {
                        new()
                        {
                            Id = Guid.NewGuid(),
                            DayOfWeek = DayOfWeek.Saturday,
                            StartTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 6).AddHours(9),
                            EndTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 6).AddHours(17),
                        },
                        new()
                        {
                            Id = Guid.NewGuid(),
                            DayOfWeek = DayOfWeek.Sunday,
                            StartTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 7).AddHours(9),
                            EndTime = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 7).AddHours(17),
                        }
                    }
                }
            };
        }

        public IEnumerable<Schedule> GetAll() => _templates;

        public Schedule? GetByName(string name) =>
            _templates.FirstOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

}
