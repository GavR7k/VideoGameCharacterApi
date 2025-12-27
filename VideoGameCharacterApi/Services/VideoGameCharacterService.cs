using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Services
{
    public class VideoGameCharacterService : IVideoGameCharacterService
    {
        static List<Character> characters = new List<Character> {

            new Models.Character {Id = 1, Name = "Mario", Role ="Hero", Game = "Super Mario"},
            new Models.Character {Id = 2, Name = "Alice", Role ="Main Hero", Game = "Resident Evil"},
            new Models.Character {Id= 3, Name = "Price", Role="Captain", Game = " Call Of Duty"},

        };

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
            return await Task.FromResult(characters);
        }

        public async Task<Character?> GetByIdAsync(int id)
        {
            var character = characters.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(character);
        }

        public Task<bool> UpdateAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
