global using AutoMapper;

namespace netboilerplate.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{Id=1, Name = "Faiq", Intelligence=100, Defence=20,
                Class=RpgClass.Mage}
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>>
            AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            var characterAdded = _context.Characters.Add(character);
            _context.SaveChanges();
            var dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c =>
            _mapper.Map<GetCharacterDto>(c)).ToList();

            return serviceResponse;
        }


        public async Task<ServiceResponse<GetCharacterDto>>
           UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            { 
                var character = characters.FirstOrDefault(
                    c => c.Id == updatedCharacter.Id);
                if (character is null)
                {
                    throw new Exception($"Character with Id " +
                        $"'{updatedCharacter.Id}' not found");
                }
               
                character.Name = updatedCharacter.Name;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Defence = updatedCharacter.Defence;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Class = updatedCharacter.Class;

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c =>
            _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacters = await _context.Characters.ToListAsync();
            var character = dbCharacters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                var character = characters.FirstOrDefault(
                    c => c.Id == id);
                if (character is null)
                    throw new Exception($"Character with Id " +
                        $"'{id}' not found");
                characters.Remove(character);
                serviceResponse.Data = characters.Select(c =>
                _mapper.Map<GetCharacterDto>(c)).ToList();
                
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }
    }
}

