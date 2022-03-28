using MenuApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _dbcontext;
        public MenuRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<SelectListItem> Userdata()
        {
            var username = _dbcontext.Users.Select(x => new SelectListItem()
            {
                Text = x.username,
                Value = x.userid.ToString()
            }).ToList();
            return username;
        }
        public List<SelectListItem> Itemdata()
        {
            var itemstore = _dbcontext.itemnames.Select(x => new SelectListItem()
            {
                Text = x.item,
                Value = x.id.ToString()
            }).ToList();
            return itemstore;
        }
        public IEnumerable<StoreData> GetData()
        {
            var queryresult = _dbcontext.storeDatas.Include("Itemname").Include("User").ToList();
            return queryresult;
        }

        public IEnumerable<StoreData> GetDetails(int id)
        {
            var queryresult = _dbcontext.storeDatas.Where(x => x.uid == id).Include("Itemname").Include("User").ToList();
            return queryresult;
        }
        public MenuModel createview(int? id)
        {
            var model = new MenuModel();
           
            if (id != null)
            {
                model.Username = (int)id;
                model.itemids = _dbcontext.storeDatas.Where(x => x.uid == id).GroupBy(x=> x.Itemid).Select(x=> x.Key).ToList();
            }
            return model;
        }

        public void Insert(int? id,List<string> selecteditem,int uid)
        {
           
            var demo = new List<StoreData>();
            foreach (var item in selecteditem)
            {
                demo.Add(new StoreData()
                {
                    uid = uid,
                    Itemid = int.Parse(item)
                });
            }
            if (id != null)
            {
                var result = _dbcontext.storeDatas.Where(x => x.uid == id);
                _dbcontext.RemoveRange(result);
            }
            _dbcontext.storeDatas.AddRange(demo);
            _dbcontext.SaveChanges();
        }

       
        public void DeleteData(int id)
        {
            var result = _dbcontext.storeDatas.Where(x => x.uid == id);
            _dbcontext.RemoveRange(result);
            _dbcontext.SaveChanges();
        }    
    }
}
