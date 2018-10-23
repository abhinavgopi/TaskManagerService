using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaskManager.BusinessLib;
using TaskManager.Entities;

namespace TaskManager.BLTestCase
{
    [TestClass]
    public class BusinessLayerTestCase
    {
        [TestMethod]
        public void TestGetAllTask()
        {
            TaskBL taskBL = new TaskBL();
            int count = taskBL.GetAll().Count;
            Assert(count, 0);
        }

        [TestMethod]
        public void TestAddTask()
        {
            TaskBL taskBL = new TaskBL();
            taskBL.AddTask(new Task() { TaskId = 7, TaskName = "Task10", Priority = 17, StartDate = DateTime.Now, EndDate = DateTime.Now)
        }
    }
}
