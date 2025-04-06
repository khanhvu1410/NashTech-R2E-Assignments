using Microsoft.AspNetCore.Mvc;
using ToDoApiAssignment.Application.DTOs;
using ToDoApiAssignment.Application.Interfaces;

namespace ToDoApiAssignment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoItemsController : CustomControllerBase
    {
        private readonly IToDoItemService _toDoItemService;

        public ToDoItemsController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ToDoItemDTO>> GetAllItems()
        {
            return SafeExecute(_toDoItemService.GetAllItems);
        }

        [HttpGet("{id}")]
        public ActionResult<ToDoItemDTO> GetItemById(int id)
        {
            return SafeExecute(() => _toDoItemService.GetItemById(id));
        }

        [HttpPost("[action]")]
        public ActionResult<ToDoItemDTO> CreateItem(ToDoItemToCreateDTO itemDto)
        {
            var item = _toDoItemService.CreateItem(itemDto);
            return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item);
        }

        [HttpPatch]
        public ActionResult<ToDoItemDTO> UpdateItem(ToDoItemDTO itemDto)
        {
            return SafeExecute(() => _toDoItemService.UpdateItem(itemDto));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            return SafeDeleteExecute(() => _toDoItemService.DeleteItem(id));
        }

        [HttpPost("[action]")]
        public ActionResult<IEnumerable<ToDoItemDTO>> CreateMultipleItems(IEnumerable<ToDoItemToCreateDTO> items)
        {
            var createdItems = _toDoItemService.CreateMultipleItems(items);
            return Ok(createdItems);
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteMultipleItems(IEnumerable<int> ids)
        {
            return SafeDeleteExecute(() => _toDoItemService.DeleteMultipleItems(ids));
        }
    }
}
