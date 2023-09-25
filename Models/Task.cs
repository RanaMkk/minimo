using static minimo.Models.Enums;

namespace minimo.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public int ProjectId { get; set; }         //Foreign Key relationship with Project
        public Comment[]? Comments { get; set; }    //One-to-Many relationship with Comment

    }
}
