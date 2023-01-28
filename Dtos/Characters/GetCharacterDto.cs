using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webtesting.Dtos.Characters
{
    public class GetCharacterDto
    {
        public int Id { get; set; } 
        public int character { get; set; }
        public string name { get; set; } = "Freddo";
        public int Hp{ get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defence { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        
        public rpgClass Class {get; set;} = rpgClass.knight; 
    }
    }
