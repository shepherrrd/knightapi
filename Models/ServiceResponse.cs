using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webtesting.Models
{
    
public class ServiceResponse <T>
    {
        public T? data { get; set; }
        public bool status { get; set; } = true;

        public string Mymessage {get; set;} = string.Empty;

        public bool isDeleted {get; set;} = false;

    }
}