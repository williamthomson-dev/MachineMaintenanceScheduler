using MachineMaintenanceScheduler.Features.Machines.Interfaces;
using MachineMaintenanceScheduler.Features.Machines.Models;
using MachineMaintenanceScheduler.Features.Skills.Models;
using MachineMaintenanceScheduler.Shared.Validators;

namespace MachineMaintenanceScheduler.Features.Machines.Validators
{
    public class MachineValidator : IMachineValidator
    {
        public ValidationResult ValidateMachine(Machine machine)
        {
            if (machine == null)
                return ValidationResult.Fail("Machine cannot be null.");

            if (string.IsNullOrWhiteSpace(machine.Name))
                return ValidationResult.Fail("Machine name cannot be empty.");

            var errors = new List<string>();

            return errors.Any()
                ? ValidationResult.Fail(errors.ToArray())
                : ValidationResult.Success();
        }
    }
}
