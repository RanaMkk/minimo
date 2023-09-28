using Microsoft.EntityFrameworkCore;
using minimo.Context;
using minimo.dtos;

public class SearchService : ISearchService
{
    private readonly ApplicationDbContext _context;

    public SearchService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SearchResult>> SearchAsync(searchdto search)
    {
        string category = search.Category;
        string key = search.Key;
        // Create a list to store search results
        var results = new List<SearchResult>();

        // Search for items based on the specified category
        if (category.Equals("projects", StringComparison.OrdinalIgnoreCase))
        {
            var projects = await _context.Projects
                .Where(p => p.Name.Contains(key))
                .ToListAsync();

            // Add project search results to the list
            results.AddRange(projects.Select(project => new SearchResult
            {
                Category = "Project",
                Name = project.Name,
                Description = project.Description
            }));
        }
        else if (category.Equals("tasks", StringComparison.OrdinalIgnoreCase))
        {
            var tasks = await _context.Tasks
                .Where(task => task.Title.Contains(key) || task.Description.Contains(key))
                .ToListAsync();

            // Add task search results to the list
            results.AddRange(tasks.Select(task => new SearchResult
            {
                Category = "Task",
                Name = task.Title,
                Description = task.Description
            }));
        }
        else if (category.Equals("notes", StringComparison.OrdinalIgnoreCase))
        {
            var notes = await _context.Notes
                .Where(note => note.Description.Contains(key))
                .ToListAsync();

            // Add note search results to the list
            results.AddRange(notes.Select(note => new SearchResult
            {
                Category = "Note",
                Name = note.Description
            }));
        }

        return results;
    }
}
