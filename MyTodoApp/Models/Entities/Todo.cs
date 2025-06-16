using System.ComponentModel.DataAnnotations;

namespace MyTodoApp.Models.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
