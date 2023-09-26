using System;
using Microsoft.AspNetCore.Mvc;
using minimo.Models;
using minimo.Services;
using System.Threading.Tasks;
using minimo.dtos;

namespace minimo.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddProject([FromBody] projectdto project)
        {
            try
            {
                var addedProject = await _projectService.AddProjectAsync(project);
                return Ok(addedProject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllProjects()
        {
            try
            {
                var projects = await _projectService.GetAllProjectsAsync();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetProject(int id) {
            try
            {
                var project = await _projectService.GetProjectByID(id);
                return Ok(project);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] projectdto updatedProject)
        {
            try
            {
                var updated = await _projectService.UpdateProjectAsync(id, updatedProject);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            try
            {
                await _projectService.DeleteProjectAsync(id);
                return Ok("Project deleted"); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
