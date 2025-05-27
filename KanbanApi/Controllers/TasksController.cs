using KanbanApi.Data;
using KanbanApi.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly KanbanContext _context;

    public TasksController(KanbanContext context)
    {
        _context = context;
    }

    // GET: api/tasks
    [HttpGet]
    public ActionResult<IEnumerable<TaskModel>> GetTasks()
    {
        return _context.Tasks.ToList();
    }

    // GET: api/tasks/{id}
    [HttpGet("{id}")]
    public ActionResult<TaskModel> GetTask(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null)
        {
            return NotFound();
        }
        return task;
    }

    // POST: api/tasks
    [HttpPost]
    public ActionResult<TaskModel> CreateTask(TaskModel task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    // PUT: api/tasks/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, TaskModel updatedTask)
    {
        if (id != updatedTask.Id)
        {
            return BadRequest();
        }

        var task = _context.Tasks.Find(id);
        if (task == null)
        {
            return NotFound();
        }

        task.Billing = updatedTask.Billing;
        task.Status = updatedTask.Status;

        _context.Tasks.Update(task);
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/tasks/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null)
        {
            return NotFound();
        }

        _context.Tasks.Remove(task);
        _context.SaveChanges();

        return NoContent(); 
    }
}
