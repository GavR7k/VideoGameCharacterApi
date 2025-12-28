using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.DTOs;

namespace VideoGameCharacterApi.Services
{
    public interface IVideoGameCharacterService
    {
        Task<List<GetCharacterDto>> GetAllAsync();
        
        Task<GetCharacterDto?> GetByIdAsync(int id);

        Task<GetCharacterDto> AddAsync(CreateCharacterDto character);

        Task<bool> UpdateAsync(int id, UpdateCharacterDto character);

        Task<bool> DeleteAsync(int id);
    }
}
