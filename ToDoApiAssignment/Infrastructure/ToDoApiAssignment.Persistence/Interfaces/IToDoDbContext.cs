using ToDoApiAssignment.Domain.Entities;

namespace ToDoApiAssignment.Persistence.Interfaces
{
    public interface IToDoDbContext
    {
        public List<ToDoItem> ToDoItems { get; }
    }
}
