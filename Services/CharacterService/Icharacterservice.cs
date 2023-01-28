using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webtesting.Services.CharacterService
{
    public interface Icharacterservice
    {
        Task<ServiceResponse<List<user>>> GetUsers();

        Task<ServiceResponse<user>> GetuserbyId(int index);

        Task<ServiceResponse<List<user>>> AddCharacter(user newuser);
    }
}