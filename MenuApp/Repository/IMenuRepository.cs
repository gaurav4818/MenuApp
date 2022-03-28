using MenuApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.Repository
{
    public interface IMenuRepository
    {
        List<SelectListItem> Userdata();
        List<SelectListItem> Itemdata();
        IEnumerable<StoreData> GetData();
        MenuModel createview(int? id);
        IEnumerable<StoreData> GetDetails(int id);
        void DeleteData(int id);
        void Insert(int? id,List<string> m,int uid);
    }
}
