using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webtesting.Data
{
    public interface IAuthRespository
    {
        Task<ServiceResponse<int>> Register(Users user , string password); 
        Task<ServiceResponse<string>> Login(string username, string passowrd);

        Task<bool> UserExists(string username); 
    }
}