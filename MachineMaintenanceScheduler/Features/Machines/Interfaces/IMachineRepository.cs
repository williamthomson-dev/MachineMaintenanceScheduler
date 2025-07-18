﻿using MachineMaintenanceScheduler.Features.Machines.Models;

namespace MachineMaintenanceScheduler.Features.Machines.Interfaces
{
    public interface IMachineRepository
    {
        Task<List<Machine>> GetAllMachinesAsync();
        Task<Machine?> GetMachineByIdAsync(Guid id);
        Task AddMachineAsync(Machine machine);
        Task UpdateMachineAsync(Machine machine);
        Task DeleteMachineAsync(Guid id);
        
    }
}
