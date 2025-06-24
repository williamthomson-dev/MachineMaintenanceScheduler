using MachineMaintenanceScheduler.Features.Technicians.Models;

namespace MachineMaintenanceScheduler.Features.Technicians.Interface
{
    public interface ITechnicianRepository
    {
        Task<List<Technician>> GetAllAsync();
        Task<Technician?> GetByIdAsync(Guid id);
        Task AddAsync(Technician technician);
        Task UpdateAsync(Technician technician);
        Task DeleteAsync(Guid id);



    }
}
