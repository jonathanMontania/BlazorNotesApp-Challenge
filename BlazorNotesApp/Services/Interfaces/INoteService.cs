using BlazorNotesApp.Models;

namespace BlazorNotesApp.Services.Interfaces
{
    public interface INoteService
    {
        Task<List<Note>> GetAllNotesAsync();
        Task<Note> GetNoteById(Guid id);
        Task CreateNoteAsync(Note note);
        Task DeleteNoteAsync(Guid id);
        Task UpdateNoteAsync(Note note);
    }
}
