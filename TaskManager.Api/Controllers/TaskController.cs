using System.Web.Http;
using System.Web.Http.Cors;
using TaskManager.BusinessLib;
using TaskManager.Entities;

namespace TaskManager.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TaskController : ApiController
    {
        [Route("api/Task")]
        [HttpGet]
        public IHttpActionResult GetAllTask()
        {
            TaskBL taskBL = new TaskBL();
            return Ok(taskBL.GetAll());
        }

        [Route("api/Task/{Id}")]
        [HttpGet]
        public IHttpActionResult GetTaskById(int Id)
        {
            TaskBL taskBL = new TaskBL();

            var task = taskBL.GetById(Id);
            return Ok(task);
        }

        [Route("api/Task/AddTask")]
        [HttpPost]
        public IHttpActionResult Post(Task task)
        {
            TaskBL taskBL = new TaskBL();
            taskBL.AddTask(task);
            return Ok("Task added Successfully");
        }

        [Route("api/Task/UpdateTask")]
        [HttpPut]
        public IHttpActionResult UpdateTask(Task task)
        {
            TaskBL taskBL = new TaskBL();
            taskBL.UpdateTask(task);
            return Ok();
        }

        [Route("api/Task/Delete/{taskId}")]
        [HttpDelete]
        public IHttpActionResult EndTask(int taskId)
        {
            TaskBL taskBL = new TaskBL();
            taskBL.End(taskId);
            return Ok();
        }
    }
}

