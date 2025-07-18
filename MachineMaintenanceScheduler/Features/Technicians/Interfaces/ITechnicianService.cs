﻿using MachineMaintenanceScheduler.Features.Technicians.Models;
using MachineMaintenanceScheduler.Features.Technicians.ViewModels;

namespace MachineMaintenanceScheduler.Features.Technicians.Interfaces
{
    public interface ITechnicianService
    {
        Task<List<Technician>> GetAllTechniciansAsync();
        Task<Technician?> GetTechnicianByIdAsync(Guid id);
        Task CreateTechnicianAsync(Technician technician);
        Task UpdateTechnicianAsync(Technician technician);
        Task DeleteTechnicianAsync(Guid id);

        Task<List<Technician>> GetTechniciansWithSkillsAsync();
    }
}
