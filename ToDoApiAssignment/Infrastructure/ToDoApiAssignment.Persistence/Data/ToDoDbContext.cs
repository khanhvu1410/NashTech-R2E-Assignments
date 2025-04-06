using ToDoApiAssignment.Domain.Entities;
using ToDoApiAssignment.Persistence.Interfaces;

namespace ToDoApiAssignment.Persistence.Data
{
    public class ToDoDbContext : IToDoDbContext
    {
        private List<ToDoItem> _toDoItems = [
            new ToDoItem
            {
                Id = 1,
                Title = "Buy groceries",
                IsCompleted = false,
                CreatedAt = new DateTime(2025, 4, 4, 10, 0, 0),
                UpdatedAt = new DateTime(2025, 4, 4, 10, 0, 0)
            },
            new ToDoItem
            {
                Id = 2,
                Title = "Complete project report",
                IsCompleted = true,
                CreatedAt = new DateTime(2025, 4, 3, 14, 30, 0),
                UpdatedAt = new DateTime(2025, 4, 3, 18, 45, 0)
            },
            new ToDoItem
            {
                Id = 3,
                Title = "Exercise for 30 minutes",
                IsCompleted = false,
                CreatedAt = new DateTime(2025, 4, 2, 7, 0, 0),
                UpdatedAt = new DateTime(2025, 4, 2, 7, 15, 0)
            }
        ];

        public List<ToDoItem> ToDoItems { get => _toDoItems; }
    }
}
