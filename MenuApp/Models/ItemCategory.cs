using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MenuApp.Models
{
    public class ItemCategory
    {
        [Key]
        public int categoryid { get; set; }
        public string categoryname { get; set; }
      
    }
}
