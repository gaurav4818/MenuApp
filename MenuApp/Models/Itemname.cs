using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MenuApp.Models
{
    public class Itemname
    {
        [Key]
        public int id { get; set; }
        public string item { get; set; }

       

    }
}
