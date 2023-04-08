using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace webtesting.Services.CharacterService
{
    public class CharacterService : Icharacterservice
    {
         private static List<user> knight = new List<user>{
            new user(),
            new user(){
                Id = 1,
                name = "Bishop"
            }};
            private IMapper _mapper;
        public readonly DataContext _context;
            public CharacterService(IMapper mapper, DataContext context)

            {
             _context = context; 
                _mapper = mapper;
            }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newuser)
        { 
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<user>(newuser);
            
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            ServiceResponse.data = await _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            return ServiceResponse;
            
        }
        

       

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetUsers()
        {
             var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
             var dbCharacters = await _context.Characters.ToListAsync();
            ServiceResponse.data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return ServiceResponse;
        }

       public async Task<ServiceResponse<GetCharacterDto>> GetuserbyId(int index)
        {
             var ServiceResponse = new ServiceResponse<GetCharacterDto>();
             
            var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == index);
            ServiceResponse.data = _mapper.Map<GetCharacterDto>(dbCharacter);
           return ServiceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {var ServiceResponse = new ServiceResponse<GetCharacterDto>();
            try {
                
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);
            if(character is null)
            throw new Exception($"Character with Id {updatedCharacter.Id} is not found");
            character.name = updatedCharacter.name;
            character.Intelligence = updatedCharacter.Intelligence;
            character.Defence = updatedCharacter.Defence;
            character.Hp = updatedCharacter.Hp;
            character.Strength = updatedCharacter.Strength;
            character.Class = updatedCharacter.Class;
           await _context.SaveChangesAsync();
            ServiceResponse.data = _mapper.Map<GetCharacterDto>(character);
            } catch (Exception ex){
                ServiceResponse.Mymessage = ex.Message;
                ServiceResponse.status = false;
            }
           return ServiceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        { var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
        try   { 
         var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            if(character is null)
    
            throw new Exception($"Character with Id {id} is not found");

            _context.Remove(character);
            ServiceResponse.data = await _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            ServiceResponse.isDeleted = true;
            await _context.SaveChangesAsync();
            }
            catch(Exception ex){
                ServiceResponse.Mymessage = ex.Message;
            }
           return ServiceResponse;
        }
    }
}