using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TaskManager.DataLib;
using TaskManager.Api.Controllers;
using TaskManager.Entities;

namespace TaskManager.Test
{
    [TestFixture]
    public class TaskManagerServiceTest
    {
        TaskManagerContext context = new TaskManagerContext();

        [Test]
        public void GetAllTasks()
        {
            TaskController controller = new TaskController();
            dynamic result = controller.GetAllTask();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
        }

        [Test]
        public void GetTaskByID()
        {
            TaskController controller = new TaskController();
            dynamic result = controller.GetTaskById(2);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(2, result.Content.TaskId);
        }

        [Test]
        public void AddTask()
        {            
            var task = new Entities.Task() { TaskName = "Test Task", Priority = 20, StartDate = new DateTime(2018, 10, 1), EndDate = new DateTime(2018, 12, 1) };
            var controller = new TaskController();
            dynamic result = controller.Post(task);
            Assert.IsNotNull(result);            
        }

        [Test]
        public void UpdateTask()
        {
            var task = new Task() { TaskId = 1, TaskName = "Test Task", Priority = 20, StartDate = new DateTime(2018, 10, 1), EndDate = new DateTime(2018, 12, 1) };
            var controller = new TaskController();
            dynamic result = controller.UpdateTask(task);
            Assert.IsNotNull(result);
            Assert.AreEqual(task.TaskId, context.Tasks.Find(1).TaskId);
        }
        [Test]
        public void EndTask()
        {
            var task = new Task() { TaskId = 4 };
            var controller = new TaskController();
            dynamic result = controller.EndTask(task.TaskId);
            bool expected = true;
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, context.Tasks.Find(4).IsEnded);
        }
        
    }
}
