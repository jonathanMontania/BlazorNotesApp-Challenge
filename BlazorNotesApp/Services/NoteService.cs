using BlazorNotesApp.Models;
using BlazorNotesApp.Repositories.Interfaces;
using BlazorNotesApp.Services.Interfaces;

namespace BlazorNotesApp.Services
{
    public class NoteService : INoteService
    {

        private readonly INoteRepository _repository;
        public NoteService(INoteRepository noteRepository) 
        {
            this._repository = noteRepository;
        }

        public Task<List<Note>> GetAllNotesAsync() => _repository.GetAllAsync();
        public Task<Note> GetNoteById(Guid id) => _repository.GetByIdAsync(id);
        public Task CreateNoteAsync(Note note) => _repository.AddAsync(note);
        public Task UpdateNoteAsync(Note note) => _repository.UpdateAsync(note);
        public Task DeleteNoteAsync(Guid id) => _repository.DeleteAsync(id);
    }
}
