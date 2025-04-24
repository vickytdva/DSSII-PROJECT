using System.Text.Json.Serialization;

namespace Todo.Domain.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        
        [JsonIgnore]
        public virtual List<TodoList> Todos { get; set; } = new();
    }
}
