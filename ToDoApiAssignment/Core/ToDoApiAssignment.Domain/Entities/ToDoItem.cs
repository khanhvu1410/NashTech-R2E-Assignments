namespace ToDoApiAssignment.Domain.Entities
{
    public class ToDoItem
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public bool IsCompleted { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
