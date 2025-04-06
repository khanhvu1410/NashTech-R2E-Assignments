using ToDoApiAssignment.Domain.Entities;

namespace ToDoApiAssignment.Domain.Interfaces
{
    public interface IToDoItemRepository
    {
        public ToDoItem CreateItem(ToDoItem toDoItem);

        public IEnumerable<ToDoItem> GetAllItems();

        public ToDoItem? GetItemById(int id);
        
        public ToDoItem UpdateItem(ToDoItem toDoItem);

        public void DeleteItem(int id);
    }
}
