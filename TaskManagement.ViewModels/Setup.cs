using Microsoft.Extensions.DependencyInjection;

namespace TaskManagement.ViewModels
{
    public class Setup
    {
        public static IServiceProvider ConfigureServices()
        {
            var sc = new ServiceCollection();

            // Services
            sc.AddSingleton<Interfaces.ILoggerManager, Plugins.LoggerManager>();
            sc.AddSingleton<Interfaces.IJson, Plugins.Json>();

            // Reemplazar por servicio si se requiere probar el api de tareas
            sc.AddSingleton<Interfaces.ITask, LiteDb.TaskRepository>();

            // ViewModels
            sc.AddSingleton<MainViewModel>();
            sc.AddTransient<Tasks.AddTaskViewModel>();
            sc.AddScoped<Tasks.TasksViewModel>();
            sc.AddTransient<Tasks.UpdateTaskViewModel>();

            return sc.BuildServiceProvider();
        }
    }
}
