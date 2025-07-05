using MachineMaintenanceScheduler.Features.Technicians.Models;
using MachineMaintenanceScheduler.Shared.Validators;

namespace MachineMaintenanceScheduler.Features.Technicians.Interfaces
{
    public interface ITechnicianValidator
    {
        ValidationResult ValidateTechnician(Technician technician);
    }
}
