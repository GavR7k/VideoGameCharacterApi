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
        

    }
}
