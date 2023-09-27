using Microsoft.EntityFrameworkCore;
using minimo.Context;
using minimo.dtos;
using minimo.Models;
using System.Linq.Expressions;

public class NoteService
{
    private readonly ApplicationDbContext _context;

    public NoteService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Create a new note within a project
    public async Task<Note> CreateNoteAsync(notedto note)
    {

        var existingProject = await _context.Projects.SingleOrDefaultAsync
            (p => p.Id == note.ProjectId);

        if (existingProject == null)
        {
            throw new Exception("Project not found");
        }
        var newNote = new Note
        {
            Description = note.Description,
            ProjectId = note.ProjectId
        };
        _context.Notes.Add(newNote);
        await _context.SaveChangesAsync();
        return newNote;
    }

    // Update an existing note
    public async Task<Note> UpdateNoteAsync(int noteId, notedto updatedNote)
    {
        var existingProject = await _context.Projects.SingleOrDefaultAsync
           (p => p.Id == updatedNote.ProjectId);

        if (existingProject == null)
        {
            throw new Exception("Project not found");
        }
        var existingNote = await _context.Notes.FindAsync(noteId);

        if (existingNote == null)
        {
            throw new Exception("Note not found");
        }

        existingNote.Description = updatedNote.Description;

        await _context.SaveChangesAsync();

        return existingNote;
    }

    // Get all notes by project ID
    public async Task<List<Note>> GetNotesByProjectIdAsync(int projectId)
    {
        var existingProject = await _context.Projects.SingleOrDefaultAsync
           (p => p.Id == projectId);

        if (existingProject == null)
        {
            throw new Exception("Project not found");
        }
        return await _context.Notes
            .Where(note => note.ProjectId == projectId)
            .ToListAsync();
    }

    // Get a specific note by ID
    public async Task<Note> GetNoteByIdAsync(int noteId)
    {
        return await _context.Notes.SingleOrDefaultAsync(p => p.Id == noteId);
    }

    // Delete an existing note by ID
    public async System.Threading.Tasks.Task DeleteNoteAsync(int noteId)
    {
        var existingNote = await _context.Notes.FindAsync(noteId);

        if (existingNote == null)
        {
            throw new Exception("Note not found");
        }

        _context.Notes.Remove(existingNote);
        await _context.SaveChangesAsync();
    }
}
