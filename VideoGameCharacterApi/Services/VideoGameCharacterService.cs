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

        public async Task<GetCharacterDto> AddAsync(CreateCharacterDto character)
        {
            var newcharacter = new Character
            {
                Name = character.Name,
                Role = character.Role,
                Game = character.Game,
            };

            await _db.Characters.AddAsync(newcharacter);
            await _db.SaveChangesAsync();

            return new GetCharacterDto
            {
                Id = newcharacter.Id,
                Name = newcharacter.Name,
                Role = newcharacter.Role,
                Game = newcharacter.Game,
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingCharachter = await _db.Characters.FirstOrDefaultAsync(c => c.Id == id);

            if (existingCharachter == null)
            {
                return false;
            }

            _db.Characters.Remove(existingCharachter);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<List<GetCharacterDto>> GetAllAsync()
        {
            return await _db.Characters
                .Select(c => new GetCharacterDto
                {
                    Id = c.Id,
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
                    Id = c.Id,
                    Name = c.Name,
                    Game = c.Game,
                    Role = c.Role
                })
                .FirstOrDefaultAsync();
            return character;
        }

        public async Task<bool> UpdateAsync(int id, UpdateCharacterDto character)
        {
            var existingCharachter = await _db.Characters.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCharachter == null)
            {
                return false;
            }
            existingCharachter.Name = character.Name;
            existingCharachter.Role = character.Role;
            existingCharachter.Game = character.Game;

            await _db.SaveChangesAsync();
            return true;

        }
    }
}
