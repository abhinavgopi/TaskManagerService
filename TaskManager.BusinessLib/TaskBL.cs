using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.DataLib;
using TaskManager.Entities;

namespace TaskManager.BusinessLib
{
    public class TaskBL
    {
        TaskManagerContext context = new TaskManagerContext();

        public List<Task> GetAll()
        {
            return context.Tasks.ToList();
        }

        public Task GetById(int TaskId)
        {
            return context.Tasks.FirstOrDefault(a => a.TaskId == TaskId);
        }

        public void AddTask(Task task)
        {
            context.Tasks.Add(task);
            context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            var Item = context.Tasks.FirstOrDefault(a => a.TaskId == task.TaskId);
            Item.TaskName = task.TaskName;
            Item.ParentTaskId = task.ParentTaskId;
            Item.Priority = task.Priority;
            Item.StartDate = task.StartDate;
            Item.EndDate = task.EndDate;
            context.SaveChanges();

        }

        public void End(int Id)
        {
            var Item = context.Tasks.FirstOrDefault(a => a.TaskId == Id);
            Item.IsEnded = true;
            context.SaveChanges();

        }
    }
}
