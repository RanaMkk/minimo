using Microsoft.AspNetCore.Mvc;
using minimo.dtos;
using minimo.Models;
using minimo.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class NoteController : ControllerBase
{
    private readonly NoteService _noteService;

    public NoteController(NoteService noteService)
    {
        _noteService = noteService;
    }

    [HttpPost("createNote")]
    public async Task<IActionResult> CreateNote([FromBody] notedto note)
    {
        try
        {
            var createdNote = await _noteService.CreateNoteAsync(note);
            return Ok(createdNote);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("updateNote")]
    public async Task<IActionResult> UpdateNote(int noteId, [FromBody] notedto updatedNote)
    {
        try
        {
            var updatedNoteResult = await _noteService.UpdateNoteAsync(noteId, updatedNote);
            return Ok(updatedNoteResult);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("getNotesByProjectId")]
    public async Task<IActionResult> GetNotesByProjectId(int projectId)
    {
        try
        {
            var notes = await _noteService.GetNotesByProjectIdAsync(projectId);
            return Ok(notes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("getNoteById")]
    public async Task<IActionResult> GetNoteById(int noteId)
    {
        try
        {
            var note = await _noteService.GetNoteByIdAsync(noteId);
            return Ok(note);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("deleteNote")]
    public async Task<IActionResult> DeleteNote(int noteId)
    {
        try
        {
            await _noteService.DeleteNoteAsync(noteId);
            return Ok("Notee deleted ");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
