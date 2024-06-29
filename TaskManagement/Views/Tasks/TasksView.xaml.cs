using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
using TaskManagement.ViewModels.Tasks;

namespace TaskManagement.Views.Tasks
{
    /// <summary>
    /// Lógica de interacción para TasksView.xaml
    /// </summary>
    public partial class TasksView : UserControl
    {
        public TasksView()
        {
            InitializeComponent();
            DataContext = App.Current.ServiceProvider.GetService<TasksViewModel>();

            WeakReferenceMessenger.Default.Register<Messenger.CloseRootDrawerhostChangedMessage>(this, (r, m) =>
            {
                if (m.Value)
                    drawerHost.IsRightDrawerOpen = false;
            });
        }

        private void btnAddTask_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            addview.DataContext = App.Current.ServiceProvider.GetService<AddTaskViewModel>();
            if (!drawerHost.IsRightDrawerOpen)
                drawerHost.IsRightDrawerOpen = true;
        }

        private void lsvTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dt = App.Current.ServiceProvider.GetService<UpdateTaskViewModel>();
            var selectedItem = lsvTasks.SelectedItem as Models.Task;
            if (selectedItem == null) return;
            dt.Task = selectedItem;
            dt.SelectedDate = selectedItem.ExpiryDate;
            addview.DataContext = dt;
            if (!drawerHost.IsRightDrawerOpen)
                drawerHost.IsRightDrawerOpen = true;
        }
    }
}
