using Microsoft.EntityFrameworkCore;
using minimo.Context;
using minimo.dtos;
using static minimo.Models.Enums;

namespace minimo.Services
{
    public class TaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Creating a new task and assigning it to the project
        public async Task<Models.Task> AddTaskAsync(taskdto taskdto)
        {
            var existingProject = await _context.Projects
                .SingleOrDefaultAsync(p => p.Id == taskdto.ProjectId);

            if (existingProject == null)
            {
                throw new Exception("Project not found");
            }

            // Create a new task
            var task = new Models.Task
            {
                Title = taskdto.Title,
                Description = taskdto.Description,
                DueDate = taskdto.DueDate,
                Status = taskdto.Status,
                Priority = taskdto.Priority,
                ProjectId = taskdto.ProjectId
            };


            // Add the task to the Tasks DbSet
            _context.Tasks.Add(task);

            await _context.SaveChangesAsync();

            return task;
        }
        // Retrieve tasks within a project by project ID
        public async Task<List<Models.Task>> GetTasksByProjectIdAsync(int projectId)
        {
            var existingProject = await _context.Projects
                .SingleOrDefaultAsync(p => p.Id == projectId);

            if (existingProject == null)
            {
                throw new Exception("Project not found");
            }

            var tasks = await _context.Tasks.
                Where(task => task.ProjectId == projectId).
                ToListAsync();
            if(tasks.Count == 0)
            {
                throw new Exception("No Tasks in this project yet");
            }
            else
            {
                return tasks;
            }
        }
        // Show task details by ID 
        public async Task<Models.Task> GetTaskAsync (int taskId)
        {
            var existingTask  = await _context.Tasks
                .SingleOrDefaultAsync(t=>t.Id == taskId);
            if(existingTask == null)
            {
                throw new Exception("Task not found");
            }
            return existingTask;
        }
        // Update task details by task ID
        public async Task<Models.Task> UpdateTaskAsync(int taskId, taskdto updatedTask)
        {
            var existingProject = await _context.Projects
                .SingleOrDefaultAsync(p => p.Id == updatedTask.ProjectId);

            if (existingProject == null)
            {
                throw new Exception("Project not found");
            }
            var existingTask = await _context.Tasks.FindAsync(taskId);

            if (existingTask == null)
            {
                throw new Exception("Task not found");
            }

            // Update task properties
            existingTask.Title = updatedTask.Title;
            existingTask.Description = updatedTask.Description;
            existingTask.DueDate = updatedTask.DueDate;
            existingTask.Status = updatedTask.Status;
            existingTask.Priority = updatedTask.Priority;

            await _context.SaveChangesAsync();

            return existingTask;
        }
        public async Task<Models.Task> ChangeTaskStatusAsync(int taskId, int newStatus)
        {
            var existingTask = await _context.Tasks.FindAsync(taskId);

            if (existingTask == null)
            {
                throw new Exception("Task not found");
            }
            if (newStatus < 1 || newStatus > 6)
            {
                throw new Exception("Status out of range!");
            }
            // Update task status
            existingTask.Status = (Status)newStatus;

            await _context.SaveChangesAsync();

            return existingTask;
        }
        public async Task<Models.Task> ChangeTaskPriorityAsync(int taskId, int newPriority)
        {
            var existingTask = await _context.Tasks.FindAsync(taskId);

            if (existingTask == null)
            {
                throw new Exception("Task not found");
            }
            if (newPriority < 1 || newPriority > 4)
            {
                throw new Exception("Status out of range!");
            }
            // Update task Priority
            existingTask.Priority = (Priority)newPriority;

            await _context.SaveChangesAsync();

            return existingTask;
        }
        // Delete a task by task ID
        public async Task DeleteTaskAsync(int taskId)
        {
            var existingTask = await _context.Tasks.FindAsync(taskId);

            if (existingTask == null)
            {
                throw new Exception("Task not found");
            }

            _context.Tasks.Remove(existingTask);
            await _context.SaveChangesAsync();
        }

    }
}
