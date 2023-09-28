namespace minimo.Models
{
    public class Enums
    {
        public enum Status
        {
            initiated = 1,
            InProgress = 2,
            Completed = 3,
            Paused = 4,
            Declined = 5,
            Postponed = 6
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
