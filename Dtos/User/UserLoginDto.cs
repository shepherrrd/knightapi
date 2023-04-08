using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webtesting.Dtos.User
{
    public class UserLoginDto
    {
           public string Username { get; set; } = String.Empty;
        public string password { get; set; } = String.Empty;
    }
}