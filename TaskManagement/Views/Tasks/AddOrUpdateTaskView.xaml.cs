using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
using TaskManagement.ViewModels;
using TaskManagement.ViewModels.Tasks;

namespace TaskManagement.Views.Tasks
{
    /// <summary>
    /// Lógica de interacción para AddTaskView.xaml
    /// </summary>
    public partial class AddOrUpdateTaskView : UserControl
    {
        public AddOrUpdateTaskView()
        {
            InitializeComponent();
            DataContext = App.Current.ServiceProvider.GetService<AddTaskViewModel>();
        }
    }
}
