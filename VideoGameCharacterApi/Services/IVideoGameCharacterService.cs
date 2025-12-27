using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Services
{
    public interface IVideoGameCharacterService
    {
        Task<List<Character>> GetAllAsync();
        
        Task<Character?> GetByIdAsync(int id);

        Task<Character> AddAsync(Character character);

        Task<bool> UpdateAsync(int id, Character character);

        Task<bool> DeleteAsync(int id);
    }
}
