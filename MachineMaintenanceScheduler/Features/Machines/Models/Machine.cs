using MachineMaintenanceScheduler.Features.MaintenanceRules.Models;
using MachineMaintenanceScheduler.Features.Skills.Models;

namespace MachineMaintenanceScheduler.Features.Machines.Models
{
    public class Machine
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public DateTime? LastMaintenanceDate { get; set; }
        public bool IsUnderMaintenance { get; set; } = false;
        public DateTime? ScheduledDate { get; set; }
        public Guid RequiredSkillId { get; set; } = Guid.NewGuid(); // Skill required for maintenance
        public Skill? RequiredSkill { get; set; } 

        public Guid MachineMaintenanceRuleId { get; set; }
        public MachineMaintenanceRule? MachineMaintenanceRule { get; set; } 
    }
}
