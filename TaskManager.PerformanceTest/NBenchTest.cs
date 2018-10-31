using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.BusinessLib;
using TaskManager.Entities;
using NBench;
using NBench.Util;

namespace TaskManager.PerformanceTest
{
    public class NBenchTest
    {
        [PerfBenchmark(Description = "Test to ensure that a minimal throughput test can be rapidly executed.",
            NumberOfIterations = 1,
            RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 100,
            TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestCounter", MustBe.LessThan, 10000000.0d)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, 70000000)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.LessThanOrEqualTo, 4.0d)]
        public void BenchMarkAddUpdateEnd()
        {
            Task task = new Task();
            task.TaskName = "task10";
            task.Priority = 23;
            task.ParentTaskId = 4;
            task.StartDate = DateTime.Now;
            task.EndDate = DateTime.Now;
            task.IsEnded = false;
            TaskBL taskBL = new TaskBL();
            taskBL.AddTask(task);
            taskBL.UpdateTask(task);
            taskBL.End(task.TaskId);

        }

        [PerfBenchmark(Description = "Test to ensure that a minimal throughput test can be rapidly executed.",
            NumberOfIterations = 1,
            RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 100,
            TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestCounter", MustBe.LessThan, 10000000.0d)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, 70000000)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.LessThanOrEqualTo, 4.0d)]
        public void BenchmarkView()
        {
            TaskBL task = new TaskBL();
            task.GetAll();
        }

        [PerfBenchmark(Description = "Test to ensure that a minimal throughput test can be rapidly executed.",
            NumberOfIterations = 1,
            RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 100,
            TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestCounter", MustBe.LessThan, 10000000.0d)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, 70000000)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.LessThanOrEqualTo, 4.0d)]
        public void BenchmarkGetTaskByID()
        {
            TaskBL task = new TaskBL();
            task.GetById(1);
        }
        [PerfCleanup]
        public void Cleanup()
        {
            //nothing
        }
    }
}
