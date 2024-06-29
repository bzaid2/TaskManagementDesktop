
using LiteDB;

namespace TaskManagement.LiteDb
{
    public class TaskRepository : Interfaces.ITask
    {
        private string tableName = "tasks";
        private List<Models.Task> tasks = new List<Models.Task>();

        public List<Models.Task> All => tasks;

        public async Task<bool> AddAsync(Models.Task model)
        {
            using (var db = new LiteDatabase(LocalData.fileDb))
            {
                return await Task.Run(() =>
                {
                    var col = db.GetCollection<Models.Task>(tableName);
                    col.Insert(model);
                    return model.Id.ToString().Length > 0;
                });
            }
        }

        public async Task<bool> DeleteAsync(int _id)
        {
            using (var db = new LiteDatabase(LocalData.fileDb))
            {
                return await Task.Run(() =>
                {
                    var col = db.GetCollection<Models.Task>(tableName);
                    return col.Delete(_id);
                });
            }
        }

        public async Task<List<Models.Task>> FindAllAsync()
        {
            using (var db = new LiteDatabase(LocalData.fileDb))
            {
                return await Task.Run(() =>
                {
                    var col = db.GetCollection<Models.Task>(tableName);
                    tasks = col.FindAll().ToList();
                    return tasks;
                });
            }
        }

        public async Task<Models.Task> FindByIdAsync(int _id)
        {
            using (var db = new LiteDatabase(LocalData.fileDb))
            {
                return await Task.Run(() =>
                {
                    var col = db.GetCollection<Models.Task>(tableName);
                    return col.FindById(_id);
                });
            }
        }

        public async Task<bool> UpdateAsync(Models.Task model)
        {
            using (var db = new LiteDatabase(LocalData.fileDb))
            {
                return await Task.Run(() =>
                {
                    var col = db.GetCollection<Models.Task>(tableName);
                    return col.Update(model);
                });
            }
        }
    }
}
