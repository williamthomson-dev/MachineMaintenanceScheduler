using MachineMaintenanceScheduler.Features.Skills.Interfaces;
using MachineMaintenanceScheduler.Features.Skills.Models;
using MachineMaintenanceScheduler.Features.Technicians.Interface;
using MachineMaintenanceScheduler.Features.Technicians.Models;

namespace MachineMaintenanceScheduler.Features.Technicians.Services
{
    public class TechnicianService : ITechnicianService
    {
        private readonly List<Technician> _technicians;
        private readonly ISkillService _skillService;

        public TechnicianService(ISkillService skillService)
        {
            _skillService = skillService;
            _technicians = new List<Technician>
            {
                new Technician
                {
                    Id = Guid.NewGuid(),
                    Forename = "Douglas",
                    Surname = "Butcher",
                    Number = "07987654321",
                    Skills = new List<Skill>
                    {
                        _skillService.GetSkillByName("Electrical")!,
                        _skillService.GetSkillByName("Mechanical")!
                    }
                },
                new Technician
                {
                    Id = Guid.NewGuid(),
                    Forename = "James",
                    Surname = "Walker",
                    Number = "071234567890",
                    Skills = new List<Skill>
                    {
                        _skillService.GetSkillByName("Hydraulic")!,
                        _skillService.GetSkillByName("Pneumatic")!
                    }
                }
            };
        }

        public List<Technician> GetTechnicians()
        {
            return _technicians;
        }

        public Technician? GetTechnicianById(Guid id)
        {
            Technician? technician = _technicians.FirstOrDefault(t => t.Id == id);
            if (technician == null)
                return null;
             
            return technician;
        }

        public void CreateTechnician(Technician technician)
        {
            _technicians.Add(technician);
        }

        public void UpdateTechnician(Technician technician)
        {
            Technician? existingTechnician = _technicians.FirstOrDefault(t => t.Id == technician.Id);
            if (existingTechnician != null)
            {
                existingTechnician.Forename = technician.Forename;
                existingTechnician.Surname = technician.Surname;
                existingTechnician.Number = technician.Number;
                existingTechnician.Skills = technician.Skills;
                existingTechnician.IsActive = technician.IsActive;
            }
            else
            {
                throw new KeyNotFoundException("Technician not found.");
            }
        }

        public void DeleteTechnician(Guid id)
        {
            Technician? technician = _technicians.FirstOrDefault(t => t.Id == id);
            if (technician != null)
            {
                _technicians.Remove(technician);
            }
        }

    }
}
