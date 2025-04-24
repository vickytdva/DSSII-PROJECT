using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Models;
using Todo.Domain.Repositories;

namespace Todo.Web.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListRepository _todoListRepository;

        public TodoListController(ITodoListRepository todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoList>> GetAll()
        {
            var todoLists = _todoListRepository.GetAll();
            return Ok(todoLists);
        }

        [HttpGet("{id}")]
        public ActionResult<TodoList> GetById(int id)
        {
            var todoList = _todoListRepository.GetById(id);
            if (todoList == null)
            {
                return NotFound();
            }
            return Ok(todoList);
        }

        [HttpPost]
        public ActionResult<TodoList> Create(TodoList todoList)
        {
            var id = _todoListRepository.Create(todoList);
            if (id == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetById), new { id = id }, todoList);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TodoList todoList)
        {
            if (id != todoList.Id)
            {
                return BadRequest();
            }

            _todoListRepository.Update(todoList);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todoList = _todoListRepository.GetById(id);
            if (todoList == null)
            {
                return NotFound();
            }

            _todoListRepository.Delete(todoList);
            return NoContent();
        }
    }
} 