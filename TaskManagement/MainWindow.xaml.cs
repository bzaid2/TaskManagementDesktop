using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using TaskManagement.ViewModels;

namespace TaskManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.Current.ServiceProvider.GetService<MainViewModel>();
        }
    }
}