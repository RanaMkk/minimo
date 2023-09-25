namespace minimo.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }  //Commenter(Foreign Key relationship with User)
        public int TaskId { get; set; }  //Foreign Key relationship with Task
    }
}
