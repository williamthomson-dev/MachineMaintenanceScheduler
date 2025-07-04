using MachineMaintenanceScheduler.Features.Machines.Interfaces;
using MachineMaintenanceScheduler.Features.Machines.Models;

namespace MachineMaintenanceScheduler.Features.Machines.Services
{
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository _machineRepository;
        public MachineService(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }
        public Task<List<Machine>> GetAllMachinesAsync()
        {
            return _machineRepository.GetAllMachinesAsync();
        }
        public Task<Machine?> GetMachineByIdAsync(Guid id)
        {
            return _machineRepository.GetMachineByIdAsync(id);
        }
        public Task CreateMachineAsync(Machine machine)
        {
            return _machineRepository.AddMachineAsync(machine);
        }
        public Task UpdateMachineAsync(Machine machine)
        {
            return _machineRepository.UpdateMachineAsync(machine);
        }
        public Task DeleteMachineAsync(Guid id)
        {
            return _machineRepository.DeleteMachineAsync(id);
        }
    }
}
