using MachineMaintenanceScheduler.Shared.Modals;

namespace MachineMaintenanceScheduler.Shared.Services
{
    public interface IToastService
    {
        event Action<string, ToastType>? OnShow;
        void ShowToastMessage(string message, ToastType type = ToastType.Info);
    }
}
