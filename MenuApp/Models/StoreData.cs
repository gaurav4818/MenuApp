using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.Models
{
    public class StoreData
    {
        [Key]
        public int id { get; set; }
        
        [ForeignKey("User")]
        public int uid { get; set; }
        
        public User User { get; set; }
        [ForeignKey("Itemname")]
        public int Itemid { get; set; }
        
        public Itemname Itemname { get; set; }



     

    }
}
