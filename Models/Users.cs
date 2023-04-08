using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webtesting.Models
{
    public class Users
    {
     public int Id { get; set; }   
     public string Username { get; set; } = String.Empty;

     public byte[] passwordHash {get; set;} = new byte[0];
     public byte[] passwordSalt {get; set;} = new byte[0];

     public List<user>? Characters { get; set; }

    }
}