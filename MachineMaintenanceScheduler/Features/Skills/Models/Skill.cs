﻿namespace MachineMaintenanceScheduler.Features.Skills.Models
{
    public class Skill
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
    }

}
