﻿using MachineMaintenanceScheduler.Features.Skills.Models;
using MachineMaintenanceScheduler.Features.Technicians.Interfaces;
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
                    Id = Guid.Parse("6d2c35b0-7b4f-4a3e-a7ff-59f4e2c8e65b"),
                    Forename = "Douglas",
                    Surname = "Butcher",
                    Number = "07987654321",
                    SkillId = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d")
                },
                new Technician
                {
                    Id = Guid.Parse("8d2c35b0-7b4f-4a3e-a7ff-59f4e2c8e65b"),
                    Forename = "James",
                    Surname = "Walker",
                    Number = "07123456789",
                    SkillId = Guid.Parse("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e")
                },
                new Technician
                {
                    Id = Guid.Parse("6d2c35b0-7b4f-4a3e-a7ff-59f4e2c8e65b"),
                    Forename = "Robert",
                    Surname = "Walker",
                    Number = "07918273645",
                    SkillId = Guid.Parse("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f")
                },
                new Technician
                {
                    Id = Guid.Parse("8d2c35b0-7b4f-4a3e-a7ff-59f4e2c8e65b"),
                    Forename = "Betty",
                    Surname = "Walker",
                    Number = "07654321987",
                    SkillId = Guid.Parse("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f80")
                },
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
