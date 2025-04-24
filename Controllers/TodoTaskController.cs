using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Models;
using Todo.Domain.Repositories;

namespace Todo.Web.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TodoTaskController : ControllerBase
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public TodoTaskController(ITodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoTask>> GetAll()
        {
            var tasks = _todoTaskRepository.GetAll();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<TodoTask> GetById(int id)
        {
            var task = _todoTaskRepository.GetById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public ActionResult<TodoTask> Create(TodoTask task)
        {
            var id = _todoTaskRepository.Create(task);
            if (id == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetById), new { id = id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TodoTask task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _todoTaskRepository.Update(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = _todoTaskRepository.GetById(id);
            if (task == null)
            {
                return NotFound();
            }

            _todoTaskRepository.Delete(task);
            return NoContent();
        }
    }
} 