using ToDoApiAssignment.Domain.Entities;
using ToDoApiAssignment.Domain.Interfaces;
using ToDoApiAssignment.Persistence.Interfaces;

namespace ToDoApiAssignment.Persistence.Repositories
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly IToDoDbContext _context;

        public ToDoItemRepository(IToDoDbContext context)
        {
            _context = context;
        }

        public ToDoItem CreateItem(ToDoItem toDoItem)
        {
            _context.ToDoItems.Add(toDoItem);
            return toDoItem;
        }

        public void DeleteItem(int id)
        {
            var item = _context.ToDoItems.FirstOrDefault(i => i.Id == id);

            if (item != null)
            {
                _context.ToDoItems.Remove(item);
            }
        }

        public ToDoItem UpdateItem(ToDoItem toDoItem)
        {
            var item = _context.ToDoItems.FirstOrDefault(i => i.Id == toDoItem.Id);

            if (item != null)
            {
                item.Title = toDoItem.Title;
                item.IsCompleted = toDoItem.IsCompleted;
            }

            return toDoItem;
        }

        public IEnumerable<ToDoItem> GetAllItems()
        {
            return _context.ToDoItems;
        }

        public ToDoItem? GetItemById(int id)
        {
            return _context.ToDoItems.FirstOrDefault(i => i.Id == id);
        }
    }
}
