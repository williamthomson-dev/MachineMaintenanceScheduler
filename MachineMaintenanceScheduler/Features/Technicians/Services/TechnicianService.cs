using MachineMaintenanceScheduler.Features.Skills.Interfaces;
using MachineMaintenanceScheduler.Features.Skills.Models;
using MachineMaintenanceScheduler.Features.Technicians.Interface;
using MachineMaintenanceScheduler.Features.Technicians.Models;
using MachineMaintenanceScheduler.Features.Technicians.ViewModels;

namespace MachineMaintenanceScheduler.Features.Technicians.Services
{
    public class TechnicianService : ITechnicianService
    {
        private readonly ITechnicianRepository _technicianRepository;
        private readonly ISkillRepository _skillRepository;

        public TechnicianService(ITechnicianRepository technicianRepository, ISkillRepository skillRepository)
        {
            _technicianRepository = technicianRepository;
            _skillRepository = skillRepository;
        }

        public async Task<List<TechnicianWithSkillsViewModel>> GetTechniciansWithSkillsAsync()
        {
            var technicians = await _technicianRepository.GetAllAsync();
            var skills = await _skillRepository.GetAllSkillsAsync();

            var result = technicians.Select(t => new TechnicianWithSkillsViewModel
            {
                Id = t.Id,
                Forename = t.Forename,
                Surname = t.Surname,
                Number = t.Number,
                IsActive = t.IsActive,
                SkillNames = skills
                    .Where(s => t.SkillIds.Contains(s.Id))
                    .Select(s => s.Name)
                    .ToList()
            }).ToList();

            return result;
        }

        public async Task<List<Technician>> GetAllTechniciansAsync()
        {
            return await _technicianRepository.GetAllAsync();
        }

        public async Task<Technician?> GetTechnicianByIdAsync(Guid id)
        {
            return await _technicianRepository.GetByIdAsync(id);
        }

        public async Task CreateTechnicianAsync(Technician technician)
        {
            await _technicianRepository.AddAsync(technician);
        }

        public async Task UpdateTechnicianAsync(Technician technician)
        {
            await _technicianRepository.UpdateAsync(technician);
        }

        public async Task DeleteTechnicianAsync(Guid id)
        {
            await _technicianRepository.DeleteAsync(id);
        }

    }
}
