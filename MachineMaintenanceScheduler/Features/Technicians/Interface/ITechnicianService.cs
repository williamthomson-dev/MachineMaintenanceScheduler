using MachineMaintenanceScheduler.Features.Technicians.Models;

namespace MachineMaintenanceScheduler.Features.Technicians.Interface
{
    public interface ITechnicianService
    {
        List<Technician> GetTechnicians();
        Technician? GetTechnicianById(Guid id);
        void CreateTechnician(Technician technician);
        void UpdateTechnician(Technician technician);
        void DeleteTechnician(Guid id);
    }
}
