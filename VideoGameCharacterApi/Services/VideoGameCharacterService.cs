using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Services
{
    public class VideoGameCharacterService : IVideoGameCharacterService
    {
        private readonly AppDbContext _db;
        public VideoGameCharacterService(AppDbContext db)
        {
            _db = db;
        }

        public Task<Character> AddAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Character>> GetAllAsync()
        {
            return await _db.Characters.ToListAsync();
        }

        public async Task<Character?> GetByIdAsync(int id)
        {
            var character = await _db.Characters.FirstOrDefaultAsync(c=>c.Id == id);
            return character;
        }

        public Task<bool> UpdateAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
