using ToDoApiAssignment.Application.DTOs;
using ToDoApiAssignment.Domain.Entities;
using ToDoApiAssignment.Domain.Interfaces;

namespace ToDoApiAssignment.Application.Mappings
{
    public static class ToDoItemMapping
    {
        public static ToDoItemDTO ToItemDTO(this ToDoItem item)
        {
            return new ToDoItemDTO
            {
                Id = item.Id,
                Title = item.Title,
                IsCompleted = item.IsCompleted
            };
        }

        public static ToDoItem ToItem(this ToDoItemToCreateDTO item, int id)
        {
            return new ToDoItem
            {
                Id = id,
                Title = item.Title ?? string.Empty,
                IsCompleted = item.IsCompleted,
                CreatedAt = DateTime.Now
            };
        }
    }
}
