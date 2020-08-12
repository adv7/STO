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
        private List<Task> _complitedTasksList;

        public DbTaskListController(string dbPath)
        {
            db_tasks = new SQLiteAsyncConnection(dbPath);
            db_tasks.CreateTableAsync<Task>().Wait();
            _complitedTasksList = db_tasks.Table<Task>().Where(task => task._isCompleted == true).ToListAsync().Result;
        }

        public Task<List<Task>> GetUnfinishedTasksAsync()
        {
            return db_tasks.Table<Task>().Where(task => task._isCompleted == false).ToListAsync();
        }

        public int GetNumberOfFinishedTaskInDate(DateTime date)
        {
            var complitedTasksInDate = new List<Task>();

            foreach (var task in _complitedTasksList)
            {
                if (task._completedDate != null)
                {
                    if (DateTime.Compare(task._completedDate.Date, date.Date) == 0)
                    {
                        complitedTasksInDate.Add(task);
                    }
                }
            }
            return complitedTasksInDate.Count;
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

        // Clearing tasks table
        public async Task<int> ClearTableAsync()
        {
            return await db_tasks.DeleteAllAsync<Task>();
        }
    }
}
