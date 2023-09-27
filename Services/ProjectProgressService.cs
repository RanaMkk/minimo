using minimo.Context;
using static minimo.Models.Enums;

namespace minimo.Services
{
    public class ProjectProgressService
    {
        private readonly ApplicationDbContext _context;

        public ProjectProgressService(ApplicationDbContext context)
        {
            _context = context;
        }
        public double CalculateProgressRatio(int projectId)
        {
            var totalTasks = _context.Tasks.Count(task => task.ProjectId == projectId);
            var completedTasks = _context.Tasks.Count(task => task.ProjectId == projectId && task.Status == Status.Completed);

            if (totalTasks == 0)
            {
                return 0.0; // To avoid division by zero
            }

            return ((double)completedTasks / totalTasks)*100;
        }
    }
}
