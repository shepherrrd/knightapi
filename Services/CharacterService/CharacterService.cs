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
        public async Task<ServiceResponse<List<user>>> AddCharacter(user newuser)
        { 
            var ServiceResponse = new ServiceResponse<List<user>>();
            knight.Add(newuser);
            ServiceResponse.data = knight;
            return ServiceResponse;
        }

       

        public async Task<ServiceResponse<List<user>>> GetUsers()
        {
             var ServiceResponse = new ServiceResponse<List<user>>();
            ServiceResponse.data = knight;
            return ServiceResponse;
        }

       public async Task<ServiceResponse<user>> GetuserbyId(int index)
        {
             var ServiceResponse = new ServiceResponse<user>();
             
            var character = knight.FirstOrDefault(c => c.Id == index);
            ServiceResponse.data = character;
           return ServiceResponse;
        }
    }
}