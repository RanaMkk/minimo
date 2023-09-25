using static minimo.Models.Enums;
namespace minimo.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? startdate { get; set; }
        public DateTime enddate { get; set;}
        //The Id of the Owner who created the project
        public int UserId { get; set; }
        public Status Status { get; set; }
        public Note[]? Notes { get; set; }
        public Task[]? Tasks { get; set; }
    }
}
