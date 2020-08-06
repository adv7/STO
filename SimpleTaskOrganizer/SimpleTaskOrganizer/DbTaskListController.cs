using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskOrganizer
{
    // this class controlls task list database

    public class DbTaskListController
    {
        readonly SQLiteAsyncConnection db_tasks;

        public DbTaskListController(string dbPath)
        {
            db_tasks = new SQLiteAsyncConnection(dbPath);
            db_tasks.CreateTableAsync<Task>().Wait();
        }

        public Task<List<Task>> GetTasksAsync()
        {
            return db_tasks.Table<Task>().ToListAsync();
        }

        public Task<int> SaveTaskAsync(Task task)
        {
            return db_tasks.InsertAsync(task);
        }

        public Task<int> UpdateTaskAsync(Task task)
        {
            return db_tasks.UpdateAsync(task);
        }

        public Task<int> RemoveTaskAsync(Task task)
        {
            return db_tasks.DeleteAsync(task);
        }
    }
}
