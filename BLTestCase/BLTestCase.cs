using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.BusinessLib;
using TaskManager.Entities;

namespace TaskManager.BLTestCase
{
    [TestFixture]
    public class BLTestCase
    {

        [Test]
        public void TestGetAllTask()
        {
            TaskBL task = new TaskBL();
            int count = task.GetAll().Count;
            Assert.Greater(count, 0);
        }

        [Test]
        public void TestAddTask()
        {
            TaskBL task = new TaskBL();
            task.AddTask(new Task() { TaskId = 10, TaskName = "Task 10", Priority = 17, StartDate = DateTime.Now, EndDate = DateTime.Now });
            string expected = "Test Task";
            string actual = task.GetById(1).TaskName;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestUpdateTask()
        {
            TaskBL task = new TaskBL();
            task.UpdateTask(new Task() { TaskId = 4, TaskName = "Task_4", Priority = 13, StartDate = DateTime.Now, EndDate = DateTime.Now });
            string expected = "Task_4";
            string actual = task.GetById(4).TaskName;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestEndTask()
        {
            TaskBL task = new TaskBL();
            task.End(6);
            bool expected = true;
            bool actual = task.GetById(6).IsEnded;
            Assert.AreEqual(expected, actual);
        }
    }
}
