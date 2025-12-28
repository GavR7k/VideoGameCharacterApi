using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.DTOs;

namespace VideoGameCharacterApi.Services
{
    public interface IVideoGameCharacterService
    {
        Task<List<GetCharacterDto>> GetAllAsync();
        
        Task<GetCharacterDto?> GetByIdAsync(int id);

        Task<GetCharacterDto> AddAsync(Character character);

        Task<bool> UpdateAsync(int id, Character character);

        Task<bool> DeleteAsync(int id);
    }
}
