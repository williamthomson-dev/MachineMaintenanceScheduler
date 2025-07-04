using MachineMaintenanceScheduler.Features.Machines.Models;

namespace MachineMaintenanceScheduler.Features.Machines.Interfaces
{
    public interface IMachineService
    {
        Task<List<Machine>> GetAllMachinesAsync();
        Task<Machine?> GetMachineByIdAsync(Guid id);
        Task CreateMachineAsync(Machine machine);
        Task UpdateMachineAsync(Machine machine);
        Task DeleteMachineAsync(Guid id);
    }
}
