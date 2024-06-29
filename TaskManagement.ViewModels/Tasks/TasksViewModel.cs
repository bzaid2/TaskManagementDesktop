using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using TaskManagement.Interfaces;

namespace TaskManagement.ViewModels.Tasks
{
    public partial class TasksViewModel : ObservableObject
    {
        private readonly ITask taskService;

        [ObservableProperty]
        private List<Models.Task> _tasks;
        [ObservableProperty]
        private string _taskTitleMessage;

        public TasksViewModel(ITask _taskService)
        {
            taskService = _taskService;
            GetTasks();
            WeakReferenceMessenger.Default.Register<Messenger.TaskListChangedMessage>(
                this, (r, m) =>
                {
                    GetTasks();
                });
        }

        private void GetTasks()
        {
            Task.Run(async () =>
            {
                await taskService.FindAllAsync();
                Tasks = new List<Models.Task>();
                Tasks = taskService.All;
                SetTaskTitleMessage();
            });
        }
        private void SetTaskTitleMessage()
        {
            var pendingTaskCounter = Tasks.Where(x => x.IsChecked == false).ToList().Count();
            TaskTitleMessage = pendingTaskCounter > 0 ? $"{pendingTaskCounter} tarea(s) pendiente(s)" : "No hay tareas pendientes";
        }
    }
}
