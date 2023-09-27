namespace minimo.dtos
{
    public class ProjectTimelineProgressdto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double ProgressRatio { get; set; }
    }
}
