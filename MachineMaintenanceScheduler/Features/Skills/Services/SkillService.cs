using MachineMaintenanceScheduler.Features.Skills.Interfaces;
using MachineMaintenanceScheduler.Features.Skills.Models;

namespace MachineMaintenanceScheduler.Features.Skills.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<List<Skill>> GetAllSkillsAsync()
        {
            return await _skillRepository.GetAllSkillsAsync();
        }

        public async Task<Skill?> GetSkillByIdAsync(Guid Id)
        {
            return await _skillRepository.GetSkillByIdAsync(Id);
        }

        public async Task CreateSkillAsync(Skill skill)
        {
            await _skillRepository.AddSkillAsync(skill);
        }

        public async Task UpdateSkillAsync(Skill skill)
        {
            await _skillRepository.UpdateSkillAsync(skill);
        }

        public async Task DeleteSkillAsync(Guid id)
        {
            await _skillRepository.DeleteSkillAsync(id);
        }
    }
}
