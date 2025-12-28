using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Services;
using VideoGameCharacterApi.DTOs;

namespace VideoGameCharacterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameCharactersController : ControllerBase
    {
        private readonly IVideoGameCharacterService _service;
        public VideoGameCharactersController(IVideoGameCharacterService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetCharacterDto>>> GetCharacters()
        {
            var characters = await _service.GetAllAsync();
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            var character = await _service.GetByIdAsync(id);
            if (character == null)
            {
                return NotFound("Character with specified id was not found");
            }
            else
            {
                return Ok(character);
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetCharacterDto>> CreateCharacter(CreateCharacterDto character)
        {
            var createdcharacter = await _service.AddAsync(character);
            return CreatedAtAction(nameof(GetCharacter), new { id = createdcharacter.Id}, createdcharacter);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCharacter(int id,UpdateCharacterDto character)
        {
            var updated = await _service.UpdateAsync(id, character);
            return updated ? NoContent() : NotFound("Character with specified id was not found");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound("Character with specified id was not found");
        }
    }
}
