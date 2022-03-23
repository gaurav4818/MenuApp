using MenuApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MenuApp.Controllers
{
    public class RestaurantController : Controller
    {
        private AppDbContext _dbcontext;
        public RestaurantController(AppDbContext context)
        {
            _dbcontext = context;
        }
        public IActionResult Index()
        
        
        {

            List<User> users = _dbcontext.Users.ToList();
            List<Itemname> itemnames = _dbcontext.itemnames.ToList();
            List<StoreData> storeDatas = _dbcontext.storeDatas.ToList();
            var queryresult = (from st in storeDatas
                               join
         u in users on st.uid equals u.userid into table1
                               from u in table1.ToList()
                               join i in itemnames on st.Itemid equals i.id into table2
                               from i in table2.ToList()
                               select new ItemViewModel
                               {
                                   itemname = i,
                                   user = u,
                                   count = _dbcontext.storeDatas.Where(x => x.uid == u.userid).Count()
                               }).GroupBy(x=> x.user.userid).Select(x=> x.FirstOrDefault()).OrderBy(x=> x.user.username);
            

          

            return View(queryresult);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.username = _dbcontext.Users.Select(x => new SelectListItem()
            {
                Text = x.username,
                Value=x.userid.ToString()
            }).ToList();

            var itemstore = _dbcontext.itemnames.Select(x => new SelectListItem()
            {
                Text = x.item,
                Value = x.id.ToString()
            }
            ).ToList();
            var model = new MenuModel()
            {
                itemname = itemstore
            };
            
            return View(model);

          
        }
        [HttpPost]
        public IActionResult Create(MenuModel obj)
        {
            if (ModelState.IsValid)
            {
                // StoreData sd = new StoreData();
                var selecteditem = obj.itemname.Where(x => x.Selected).Select(y => y.Value).ToList();
                var demo = new List<StoreData>();
                foreach (var item in selecteditem)
                {

                    demo.Add(new StoreData()
                    {
                        uid = obj.Username,
                        Itemid = int.Parse(item)
                    });


                }
                _dbcontext.storeDatas.AddRange(demo);
                _dbcontext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Details(int id)
        {
            List<User> users = _dbcontext.Users.ToList();
            List<Itemname> itemnames = _dbcontext.itemnames.ToList();
            List<StoreData> storeDatas = _dbcontext.storeDatas.ToList();
            var ans = (from st in storeDatas.Where(x=> x.uid==id)
                               join
         u in users on st.uid equals u.userid into table1
                               from u in table1.ToList()
                               join i in itemnames on st.Itemid equals i.id into table2
                               from i in table2.ToList()
                               select new ItemViewModel
                               {
                                   itemname = i,
                                   user = u,   
                               });
            return View(ans);
        }
        public IActionResult Delete(int id)
        {
            var result=_dbcontext.storeDatas.Where(x=> x.uid==id);
            _dbcontext.RemoveRange(result);
           // _dbcontext.Entry(st).State = EntityState.Deleted;
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new MenuModel();
            List<int> itemids = new List<int>();
            var user = _dbcontext.storeDatas.Where(x => x.uid == id).Select(x=> x.Itemid);

            foreach (var item in user)
            {
               itemids.Add(item);
            }
            ViewBag.username = _dbcontext.Users.Select(x => new SelectListItem()
            {
                Text = x.username,
                Value = x.userid.ToString()
                
               
            }).ToList();
           
           
            var itemstore = _dbcontext.itemnames.Select(x => new SelectListItem()
            {
                Text = x.item,
                Value = x.id.ToString()
            }).ToList();
            

            model.itemname = itemstore;
            model.Username = id;
               
           foreach(SelectListItem item in model.itemname)
            {
                foreach(var i in itemids)
                {
                    if(item.Value.ToString()==i.ToString())
                    {
                        item.Selected = true;
                    }
                }
            }
           

            return View(model);


        }
        [HttpPost]
        public IActionResult Edit(int id,MenuModel obj)
        {
            // StoreData sd = new StoreData();
            var selecteditem = obj.itemname.Where(x => x.Selected).Select(y => y.Value).ToList();
            var demo = new List<StoreData>();
            foreach (var item in selecteditem)
            {
                 
                demo.Add(new StoreData()
                {
                    uid = obj.Username,
                    Itemid = int.Parse(item)
                });


            }
            var result = _dbcontext.storeDatas.Where(x => x.uid ==id);
            _dbcontext.RemoveRange(result);
            _dbcontext.storeDatas.AddRange(demo);
            _dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
