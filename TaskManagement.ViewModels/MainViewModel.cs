using CommunityToolkit.Mvvm.ComponentModel;

namespace TaskManagement.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _title;

        public MainViewModel()
        {
            Title = "Gestor de tareas";
        }
    }
}
