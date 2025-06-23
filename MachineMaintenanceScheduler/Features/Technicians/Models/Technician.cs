using MachineMaintenanceScheduler.Features.Skills.Models;

namespace MachineMaintenanceScheduler.Features.Technicians.Models
{
    public class Technician
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Forename { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string FullName => $"{Forename} {Surname}";
        public List<Skill> Skills { get; set; } = new();
        public bool IsActive { get; set; } = true;
    }
}
