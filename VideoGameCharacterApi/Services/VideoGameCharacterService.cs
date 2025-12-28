using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.DTOs;

namespace VideoGameCharacterApi.Services
{
    public class VideoGameCharacterService : IVideoGameCharacterService
    {
        private readonly AppDbContext _db;
        public VideoGameCharacterService(AppDbContext db)
        {
            _db = db;
        }

        public Task<GetCharacterDto> AddAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetCharacterDto>> GetAllAsync()
        {
            return await _db.Characters
                .Select(c => new GetCharacterDto
                {
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role

                }).ToListAsync();
        }

        public async Task<GetCharacterDto?> GetByIdAsync(int id)
        {
            var character = await _db.Characters
                .Where(c => c.Id == id)
                .Select(c => new GetCharacterDto
                {
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role
                })
                .FirstOrDefaultAsync();
            return character;
        }

        public Task<bool> UpdateAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
