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
                    Id = Guid.Parse("216a9be1-e0d1-4851-a4be-6fdf55b233a2"),
                    Name = "Hydraulic Press",
                    SerialNumber = "HP-200",
                    LastMaintenanceDate = DateTime.Now.AddHours(-156),
                    IsUnderMaintenance = false,
                    RequiredSkillId = Guid.Parse("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"),
                    MachineMaintenanceRuleId = Guid.Parse("c85bff1d-2c41-4a4b-be63-960182d6401a")
                },
                new Machine
                {
                    Id = Guid.Parse("597294eb-fb5d-4356-80f2-a1b58b046b2d"),
                    Name = "CNC Milling Machine",
                    SerialNumber = "CNC-400",
                    LastMaintenanceDate = DateTime.Now.AddHours(-310),
                    IsUnderMaintenance = false,
                    RequiredSkillId = Guid.Parse("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"),
                    MachineMaintenanceRuleId = Guid.Parse("9b8f47f5-497d-446b-a981-3df82c6213ab")
                },
                new Machine
                {
                    Id = Guid.Parse("ec39e9d6-190e-448f-8d6b-a2966e4985d9"),
                    Name = "Air Compressor",
                    SerialNumber = "AC-150",
                    LastMaintenanceDate = DateTime.Now.AddHours(-267),
                    IsUnderMaintenance = false,
                    RequiredSkillId = Guid.Parse("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f80"),
                    MachineMaintenanceRuleId = Guid.Parse("e863fd8a-155f-4d5b-933a-6649663e2bf2")
                },
                new Machine
                {
                    Id = Guid.Parse("77a3d4d5-df32-404c-a455-4790fbe9c8a9"),
                    Name = "Welding Station",
                    SerialNumber = "WS-90",
                    LastMaintenanceDate = DateTime.Now.AddHours(-360),
                    IsUnderMaintenance = false,
                    RequiredSkillId = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"),
                    MachineMaintenanceRuleId = Guid.Parse("c85bff1d-2c41-4a4b-be63-960182d6401a")
                },
                new Machine
                {
                    Id = Guid.Parse("570c90d5-850e-43a4-a2eb-3e567080ab0d"),
                    Name = "Hydraulic Bender",
                    SerialNumber = "HB-330",
                    LastMaintenanceDate = DateTime.Now.AddHours(-389),
                    IsUnderMaintenance = false,
                    RequiredSkillId = Guid.Parse("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"),
                    MachineMaintenanceRuleId = Guid.Parse("9b8f47f5-497d-446b-a981-3df82c6213ab")
                },
                new Machine
                {
                    Id = Guid.Parse("a725f100-ef30-4a25-8285-7b6adbb3f9e8"),
                    Name = "Lathe Machine XL",
                    SerialNumber = "LMX-88",
                    LastMaintenanceDate = DateTime.Now.AddHours(-196),
                    IsUnderMaintenance = false,
                    RequiredSkillId = Guid.Parse("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"),
                    MachineMaintenanceRuleId = Guid.Parse("e863fd8a-155f-4d5b-933a-6649663e2bf2")
                },
                new Machine
                {
                    Id = Guid.Parse("ab6d7d4a-4514-4ef0-95ab-125427eba4db"),
                    Name = "Control Panel Unit",
                    SerialNumber = "CPU-77",
                    LastMaintenanceDate = DateTime.Now.AddHours(-187),
                    IsUnderMaintenance = false,
                    RequiredSkillId = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"),
                    MachineMaintenanceRuleId = Guid.Parse("c85bff1d-2c41-4a4b-be63-960182d6401a")
                },
                new Machine
                {
                    Id = Guid.Parse("b24a692e-e71d-479c-b12b-44790e6dd5b6"),
                    Name = "Pneumatic Cutter",
                    SerialNumber = "PC-55",
                    LastMaintenanceDate = DateTime.Now.AddHours(-166),
                    IsUnderMaintenance = false,
                    RequiredSkillId = Guid.Parse("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f80"),
                    MachineMaintenanceRuleId = Guid.Parse("9b8f47f5-497d-446b-a981-3df82c6213ab")
                },
                new Machine
                {
                    Id = Guid.Parse("d5351f65-3cb8-4e8e-beb4-f52545f48877"),
                    Name = "Hydraulic Shear",
                    SerialNumber = "HS-600",
                    LastMaintenanceDate = DateTime.Now.AddHours(-150),
                    IsUnderMaintenance = false,
                    RequiredSkillId = Guid.Parse("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"),
                    MachineMaintenanceRuleId = Guid.Parse("e863fd8a-155f-4d5b-933a-6649663e2bf2")
                },
                new Machine
                {
                    Id = Guid.Parse("773d60cd-0468-4c25-9950-b36e4254ebdf"),
                    Name = "Industrial Fan",
                    SerialNumber = "IF-120",
                    LastMaintenanceDate = DateTime.Now.AddHours(-211),
                    IsUnderMaintenance = false,
                    RequiredSkillId = Guid.Parse("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"),
                    MachineMaintenanceRuleId = Guid.Parse("c85bff1d-2c41-4a4b-be63-960182d6401a")
                },



            };
        }

        public Task<List<Machine>> GetAllMachinesAsync()
        {
            return Task.FromResult(_machines.OrderBy(x => x.Name).ToList());
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
            existing.IsUnderMaintenance = machine.IsUnderMaintenance;
            existing.RequiredSkillId = machine.RequiredSkillId;
            existing.RequiredSkill = machine.RequiredSkill;
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
