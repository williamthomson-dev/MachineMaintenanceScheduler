using MachineMaintenanceScheduler.Features.Skills.Models;

namespace MachineMaintenanceScheduler.Features.Technicians.ViewModels
{
    public class TechnicianWithSkillsViewModel
    {
        public Guid Id { get; set; }
        public string Forename { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string FullName => $"{Forename} {Surname}";
        public string Number { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public List<Guid> SelectedSkillIds { get; set; } = new();
    }
}
