using System;
using minimo.Models;
using minimo.Context;
using System.Threading.Tasks;
using minimo.dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Task = System.Threading.Tasks.Task;

namespace minimo.Services
{
    public class ProjectService
    {
        private readonly ApplicationDbContext _context; 

        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }
        //creating a new project
        public async Task<Project> AddProjectAsync(projectdto projectdto)
        {
            var project = new Project
            {
                Name = projectdto.Name,
                Description = projectdto.Description,
                startdate = projectdto.startdate,
                enddate = projectdto.enddate,
                UserId = projectdto.UserId,
                Status = projectdto.Status
            };
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }
        //listing all projects
        public async Task<List<Project>> GetAllProjectsAsync()
        {
            var projects = await _context.Projects.ToListAsync();
            return  projects;
        }
        // Show project details by ID
        public async Task<Project?> GetProjectByID(int id)
        {
            var project = await _context.Projects.SingleOrDefaultAsync
                (p => p.Id == id);
            return project;
        }
        // Update an existing project details
        public async Task<Project> UpdateProjectAsync(int projectId, projectdto updatedProject)
        {
            var existingProject = await _context.Projects.SingleOrDefaultAsync
                (p => p.Id == projectId);

            if (existingProject == null)
            {
                throw new Exception("Project not found");
            }

            // Update project details based on the updatedProject object
            existingProject.Name = updatedProject.Name;
            existingProject.Description = updatedProject.Description;
            existingProject.startdate = updatedProject.startdate;
            existingProject.enddate = updatedProject.enddate;
            existingProject.Status = updatedProject.Status;

            await _context.SaveChangesAsync();

            return existingProject;
        }
        //Delete an existing project
        public async Task DeleteProjectAsync(int projectId)
        {
            var projectToDelete = await _context.Projects.SingleOrDefaultAsync(p => p.Id == projectId);

            if (projectToDelete == null)
            {
                throw new Exception("Project not found");
            }

            _context.Projects.Remove(projectToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
