using MachineMaintenanceScheduler.Features.Skills.Models;
using MachineMaintenanceScheduler.Features.Technicians.Interface;
using MachineMaintenanceScheduler.Features.Technicians.Models;

namespace MachineMaintenanceScheduler.Features.Technicians.Repositories
{
    public class InMemoryTechnicianRepository : ITechnicianRepository
    {
        private readonly List<Technician> _technicians = new();

        public InMemoryTechnicianRepository()
        {
            _technicians = new List<Technician>
            {
                new Technician
                {
                    Id = Guid.NewGuid(),
                    Forename = "Douglas",
                    Surname = "Butcher",
                    Number = "07987654321",
                    SkillId = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d")
                },
                new Technician
                {
                    Id = Guid.NewGuid(),
                    Forename = "James",
                    Surname = "Walker",
                    Number = "07123456789",
                    SkillId = Guid.Parse("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f80")
                }
            };
        }

        public Task<List<Technician>> GetAllAsync()
        {
            return Task.FromResult(_technicians);
        }

        public Task<Technician?> GetByIdAsync(Guid id)
        {
            var tech = _technicians.FirstOrDefault(t => t.Id == id);
            return Task.FromResult(tech);
        }

        public Task AddAsync(Technician technician)
        {
            _technicians.Add(technician);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Technician technician)
        {
            var existing = _technicians.FirstOrDefault(t => t.Id == technician.Id);
            if (existing == null) throw new KeyNotFoundException("Technician not found.");

            existing.Forename = technician.Forename;
            existing.Surname = technician.Surname;
            existing.Number = technician.Number;
            existing.SkillId = technician.SkillId;
            existing.Skill = technician.Skill;
            existing.IsActive = technician.IsActive;

            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            var tech = _technicians.FirstOrDefault(t => t.Id == id);
            if (tech != null) _technicians.Remove(tech);
            return Task.CompletedTask;
        }

    }
}
