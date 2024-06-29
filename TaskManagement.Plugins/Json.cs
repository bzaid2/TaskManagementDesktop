using Newtonsoft.Json;
using TaskManagement.Interfaces;

namespace TaskManagement.Plugins
{
    public class Json : IJson
    {
        private readonly ILoggerManager loggerService;

        public Json(ILoggerManager _loggerService)
        {
            loggerService = _loggerService;
        }
        public T Deserialize<T>(string obj)
        {
            T result = default!;
            try
            {
                result = JsonConvert.DeserializeObject<T>(obj);
            }
            catch(Exception ex) 
            {
                loggerService.Error("Ocurrió un error al deserializar el objeto", ex);
            }
            return result;
        }
        public string Serialize<T>(T obj)
        {
            string result = string.Empty;
            try
            {
                result = JsonConvert.SerializeObject(obj, Formatting.Indented);
            }
            catch(Exception ex)
            {
                loggerService.Error("Ocurrió un error al serializar el objeto", ex);
            }
            return result;
        }
    }
}
