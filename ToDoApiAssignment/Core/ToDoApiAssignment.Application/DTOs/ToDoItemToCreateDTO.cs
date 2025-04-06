using System.ComponentModel.DataAnnotations;

namespace ToDoApiAssignment.Application.DTOs
{
    public class ToDoItemToCreateDTO
    {
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }

        public bool IsCompleted { get; set; }
    }
}
