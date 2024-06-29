using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using TaskManagement.Interfaces;
using TaskManagement.Messenger;

namespace TaskManagement.ViewModels.Tasks
{
    public class UpdateTaskViewModel : AddOrUpdateTaskViewModel
    {
        private readonly ITask taskservice;

        public UpdateTaskViewModel(ITask _taskservice)
        {
            taskservice = _taskservice;
        }

        public ICommand DeleteCommand => new RelayCommand(Delete);

        private async void Delete()
        {
            await taskservice.DeleteAsync(Task.Id);
            WeakReferenceMessenger.Default.Send(new CloseRootDrawerhostChangedMessage(true));
            WeakReferenceMessenger.Default.Send(new TaskListChangedMessage(true));
        }

        public async sealed override void MainAction()
        {
            await taskservice.UpdateAsync(Task);
            WeakReferenceMessenger.Default.Send(new CloseRootDrawerhostChangedMessage(true));
            WeakReferenceMessenger.Default.Send(new TaskListChangedMessage(true));
        }
    }
}