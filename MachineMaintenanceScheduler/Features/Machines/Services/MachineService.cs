using MachineMaintenanceScheduler.Features.Machines.Interfaces;
using MachineMaintenanceScheduler.Features.Machines.Models;
using MachineMaintenanceScheduler.Features.MaintenanceRules.Interfaces;
using MachineMaintenanceScheduler.Features.Skills.Interfaces;
using MachineMaintenanceScheduler.Features.Technicians.Interfaces;
using MachineMaintenanceScheduler.Features.Technicians.Models;

namespace MachineMaintenanceScheduler.Features.Machines.Services
{
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository _machineRepository;
        private readonly IMaintenanceRuleRepository _maintenanceRuleRepository;

        public MachineService(IMachineRepository machineRepository, IMaintenanceRuleRepository maintenanceRuleRepository)
        {
            _machineRepository = machineRepository;
            _maintenanceRuleRepository = maintenanceRuleRepository;
        }

        public async Task<List<Machine>> GetMachinesWithMaintenanceRulesAsync()
        {
            var machines = await _machineRepository.GetAllMachinesAsync();
            var maintenanceRules = await _maintenanceRuleRepository.GetAllRulesAsync();

            var result = machines.Select(t => new Machine
            {
                Id = t.Id,
                Name = t.Name,
                SerialNumber = t.SerialNumber,
                SkillRequired = t.SkillRequired,
                MachineMaintenanceRuleId = t.MachineMaintenanceRuleId,
                MachineMaintenanceRule = maintenanceRules.FirstOrDefault(s => s.Id == t.MachineMaintenanceRuleId)
            }).ToList();

            return result;
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
