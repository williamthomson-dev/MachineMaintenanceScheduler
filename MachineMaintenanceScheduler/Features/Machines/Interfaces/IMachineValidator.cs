using MachineMaintenanceScheduler.Features.Machines.Models;
using MachineMaintenanceScheduler.Shared.Validators;

namespace MachineMaintenanceScheduler.Features.Machines.Interfaces
{
    public interface IMachineValidator
    {
        ValidationResult ValidateMachine(Machine machine);
    }
}
