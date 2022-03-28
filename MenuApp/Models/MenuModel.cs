using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.Models
{
    public class MenuModel
    {
        public int Username { get; set; }
        public IList<SelectListItem> itemname { get; set; }
        public List<int> itemids { get; set; }
      
    
    }
}
