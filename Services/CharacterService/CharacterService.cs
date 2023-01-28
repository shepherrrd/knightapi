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
            public CharacterService(IMapper mapper)
            {
                _mapper = mapper;
            }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newuser)
        { 
            var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
            knight.Add(_mapper.Map<user>(newuser));
            ServiceResponse.data = knight.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return ServiceResponse;
        }

       

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetUsers()
        {
             var ServiceResponse = new ServiceResponse<List<GetCharacterDto>>();
            ServiceResponse.data = knight.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return ServiceResponse;
        }

       public async Task<ServiceResponse<GetCharacterDto>> GetuserbyId(int index)
        {
             var ServiceResponse = new ServiceResponse<GetCharacterDto>();
             
            var character = knight.FirstOrDefault(c => c.Id == index);
            ServiceResponse.data = _mapper.Map<GetCharacterDto>(character);
           return ServiceResponse;
        }
    }
}