using CommunityToolkit.Mvvm.Messaging;
using TaskManagement.Interfaces;
using TaskManagement.Messenger;

namespace TaskManagement.ViewModels.Tasks
{
    public partial class AddTaskViewModel : AddOrUpdateTaskViewModel
    {
        private readonly ITask taskservice;
        public AddTaskViewModel(ITask _taskservice)
        {
            SelectedDate = DateTime.Now;
            taskservice = _taskservice;
        }

        public async sealed override void MainAction()
        {
            await taskservice.AddAsync(Task);
            WeakReferenceMessenger.Default.Send(new CloseRootDrawerhostChangedMessage(true));
            WeakReferenceMessenger.Default.Send(new TaskListChangedMessage(true));
        }
    }
}
