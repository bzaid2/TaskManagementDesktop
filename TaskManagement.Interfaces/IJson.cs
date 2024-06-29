namespace TaskManagement.Interfaces
{
    public interface IJson
    {
        T Deserialize<T>(string obj);
        string Serialize<T>(T obj);
    }
}
