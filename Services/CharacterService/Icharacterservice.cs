using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webtesting.Dtos.Characters;

namespace webtesting.Services.CharacterService
{
    public interface Icharacterservice
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetUsers();

        Task<ServiceResponse<GetCharacterDto>> GetuserbyId(int index);

        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newuser);
    }
}