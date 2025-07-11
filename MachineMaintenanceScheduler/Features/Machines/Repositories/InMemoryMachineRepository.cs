using MachineMaintenanceScheduler.Features.Machines.Interfaces;
using MachineMaintenanceScheduler.Features.Machines.Models;
using MachineMaintenanceScheduler.Features.Skills.Models;
using MachineMaintenanceScheduler.Features.Technicians.Models;

namespace MachineMaintenanceScheduler.Features.Machines.Repositories
{
    public class InMemoryMachineRepository : IMachineRepository
    {
        private readonly List<Machine> _machines = new();

        public InMemoryMachineRepository() 
        {
            _machines = new List<Machine>
            {
                new Machine
                {
                    Id = Guid.NewGuid(),
                    Name = "Lathe Machine",
                    SerialNumber = "LM-123456",
                    LastMaintenanceDate = DateTime.Now.AddMonths(-3),
                    SkillRequired = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d")
                },
                new Machine
                {
                    Id = Guid.NewGuid(),
                    Name = "Milling Machine",
                    SerialNumber = "MM-654321",
                    LastMaintenanceDate = DateTime.Now.AddMonths(-6),
                    SkillRequired = Guid.Parse("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f80")
                }
            };
        }

        public Task<List<Machine>> GetAllMachinesAsync()
        {
            return Task.FromResult(_machines);
        }

        public Task<Machine?> GetMachineByIdAsync(Guid id)
        {
            var machine = _machines.FirstOrDefault(m => m.Id == id);
            return Task.FromResult(machine);
        }

        public Task AddMachineAsync(Machine machine)
        {
            _machines.Add(machine);
            return Task.CompletedTask;
        }

        public Task UpdateMachineAsync(Machine machine)
        {
            var existing = _machines.FirstOrDefault(m => m.Id == machine.Id);

            if (existing == null) throw new KeyNotFoundException("Machine not found.");

            existing.Name = machine.Name;
            existing.SerialNumber = machine.SerialNumber;
            existing.LastMaintenanceDate = machine.LastMaintenanceDate;
            existing.SkillRequired = machine.SkillRequired;
            existing.MachineMaintenanceRuleId = machine.MachineMaintenanceRuleId;
            return Task.CompletedTask;
        }

        public Task DeleteMachineAsync(Guid id)
        {
            var machine = _machines.FirstOrDefault(m => m.Id == id);
            if (machine != null) 
                _machines.Remove(machine);

            return Task.CompletedTask;
        }
    }
}
