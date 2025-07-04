using MachineMaintenanceScheduler.Features.Skills.Models;
using MachineMaintenanceScheduler.Shared.Validators;

namespace MachineMaintenanceScheduler.Features.Skills.Interfaces
{
    public interface ISkillValidator
    {
        ValidationResult ValidateSkill(Skill skill);
    }
}
