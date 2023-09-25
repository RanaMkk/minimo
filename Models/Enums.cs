namespace minimo.Models
{
    public class Enums
    {
        public enum Status
        {
            initiated,
            InProgress,
            Completed,
            Paused,
            Declined,
            Postponed
        }
        public enum Priority
        {
            lowest = 1,
            low = 2,
            high = 3,
            highest = 4
        }
    }
}
