using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace empty.Models
{
    [Table("todos")]
    public class Todo {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsFinished { get; set; }
    }
}
