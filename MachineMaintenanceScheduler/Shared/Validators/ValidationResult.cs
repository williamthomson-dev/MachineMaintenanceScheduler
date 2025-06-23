namespace MachineMaintenanceScheduler.Shared.Validators
{
    public class ValidationResult
    {
        public bool IsValid { get; init; }
        public List<string> Errors { get; init; } = new();

        public static ValidationResult Success() => new() { IsValid = true };
        public static ValidationResult Fail(params string[] errors) => new() { IsValid = false, Errors = errors.ToList() };
        public string GetFormattedErrors(string separator = " ")
        {
            return string.Join(separator, Errors);
        }
    }
}
