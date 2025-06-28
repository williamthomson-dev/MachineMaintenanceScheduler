using MachineMaintenanceScheduler.Shared.Modals;

namespace MachineMaintenanceScheduler.Shared.Services
{
    public class ToastService : IToastService
    {
        public event Action<string, ToastType>? OnShow;

        public void ShowToastMessage(string message, ToastType type = ToastType.Info)
        {
            OnShow?.Invoke(message, type); 
        }
    }
}
