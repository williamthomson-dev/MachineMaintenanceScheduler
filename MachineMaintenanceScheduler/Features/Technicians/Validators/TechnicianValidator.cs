﻿using MachineMaintenanceScheduler.Features.Technicians.Interfaces;
using MachineMaintenanceScheduler.Features.Technicians.Models;
using MachineMaintenanceScheduler.Shared.Validators;

namespace MachineMaintenanceScheduler.Features.Technicians.Validators
{
    public class TechnicianValidator : ITechnicianValidator
    {
        public ValidationResult ValidateTechnician(Technician technician)
        {
            if (technician == null)
                return ValidationResult.Fail("Technician cannot be null.");

            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(technician.Forename))
                errors.Add("Forename cannot be empty.");

            if (string.IsNullOrWhiteSpace(technician.Surname))
                errors.Add("Surname cannot be empty.");

            if (string.IsNullOrWhiteSpace(technician.Number))
                errors.Add("Contact number cannot be empty.");

            if (technician.SkillId == Guid.Empty)
                errors.Add("Technician must have a skill.");

            return errors.Any()
                ? ValidationResult.Fail(errors.ToArray())
                : ValidationResult.Success();
        }
    }
}
