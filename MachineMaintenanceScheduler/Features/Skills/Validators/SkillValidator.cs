using MachineMaintenanceScheduler.Features.Skills.Interfaces;
using MachineMaintenanceScheduler.Features.Skills.Models;
using MachineMaintenanceScheduler.Shared.Validators;

namespace MachineMaintenanceScheduler.Features.Skills.Validators
{
    public class SkillValidator : ISkillValidator
    {
        public ValidationResult ValidateSkill(Skill skill)
        {
            if (skill == null)
                return ValidationResult.Fail("Skill cannot be null.");

            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(skill.Name))
                errors.Add("Name cannot be empty.");

            return errors.Any()
                ? ValidationResult.Fail(errors.ToArray())
                : ValidationResult.Success();
        }
    }
}
