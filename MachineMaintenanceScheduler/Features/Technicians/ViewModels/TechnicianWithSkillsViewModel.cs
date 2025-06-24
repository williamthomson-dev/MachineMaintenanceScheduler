namespace MachineMaintenanceScheduler.Features.Technicians.ViewModels
{
    public class TechnicianWithSkillsViewModel
    {
        public Guid Id { get; set; }
        public string Forename { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public List<string> SkillNames { get; set; } = new();
    }
}
