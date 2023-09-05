using System;
using Microsoft.AspNetCore.Mvc;
using netboilerplate.Models;

namespace netboilerplate.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CharacterController: ControllerBase
	{
		
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
		public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetCharacters()
		{
			return Ok(await _characterService.GetAllCharacters());
		}

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetCharacter(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
		public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>>
            AddCharacter(AddCharacterDto newcharacter)
		{
            return Ok(await _characterService.AddCharacter(newcharacter));

        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>>
          UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var characterResponse = await
                _characterService.UpdateCharacter(updatedCharacter);

            if(characterResponse.Data is null)
            {
                return NotFound(characterResponse);
            }
            return Ok(characterResponse);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> DeleteCharacter(int id)
        {
            var characterResponse = await _characterService.DeleteCharacterById(id);
            if (characterResponse.Data is null)
            {
                return NotFound(characterResponse);
            }
            return Ok(characterResponse);
        }

    }
	
}

