using System;
using netboilerplate.Dtos.Character;
using netboilerplate.Models;

namespace netboilerplate.Services.CharacterService
{
	public interface ICharacterService
	{
		Task<ServiceResponse<List<GetCharacterDto>>>GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>>
            AddCharacter(AddCharacterDto newCharacter);


        Task<ServiceResponse<GetCharacterDto>>
            UpdateCharacter(UpdateCharacterDto updatedCharacter);

        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacterById(int id);


    }
}

