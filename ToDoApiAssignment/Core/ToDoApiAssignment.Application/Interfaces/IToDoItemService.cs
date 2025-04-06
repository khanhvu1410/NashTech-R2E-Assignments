using ToDoApiAssignment.Application.DTOs;

namespace ToDoApiAssignment.Application.Interfaces
{
    public interface IToDoItemService
    {
        public ToDoItemDTO CreateItem(ToDoItemToCreateDTO itemDto);

        public IEnumerable<ToDoItemDTO> GetAllItems();

        public ToDoItemDTO GetItemById(int id);

        public ToDoItemDTO UpdateItem(ToDoItemDTO itemDto);

        public void DeleteItem(int id);

        public IEnumerable<ToDoItemDTO> CreateMultipleItems(IEnumerable<ToDoItemToCreateDTO> items);

        public void DeleteMultipleItems(IEnumerable<int> ids);
    }
}
