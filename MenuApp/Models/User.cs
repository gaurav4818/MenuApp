using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MenuApp.Models
{
    public class User
    {
        [Key]
        public int userid { get; set; }
        public string username { get; set; }
    
    }
}
