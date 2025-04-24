using System.Text.Json.Serialization;

namespace Todo.Domain.Models
{
    public class TodoTask
    {
        public int? Id { get; set; }
        public string? Description { get; set; }
        public int? TodoId { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
        
        [JsonIgnore]
        public TodoList? Holder { get; set; }
    }
}
