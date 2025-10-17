using BlazorNotesApp.Data;
using BlazorNotesApp.Models;
using BlazorNotesApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorNotesApp.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public NoteRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddAsync(Note note)
        {
            _dbContext.Notes.Add(note);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task<List<Note>> GetAllAsync()
        {
            return await _dbContext.Notes.OrderByDescending(note => note.UpdatedAt).ToListAsync();
        }

        public async Task<Note> GetByIdAsync(Guid id)
        {
            return await _dbContext.Notes.FindAsync(id);
        }

        public async Task UpdateAsync(Note note)
        {
            note.UpdatedAt = DateTime.UtcNow;
            _dbContext.Notes.Update(note);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var noteExists = GetByIdAsync(id);

            if (noteExists != null)
            {
                _dbContext.Notes.Remove(noteExists.Result);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
