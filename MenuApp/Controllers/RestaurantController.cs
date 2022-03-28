using MenuApp.Models;
using MenuApp.Repository;
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
        private IMenuRepository _FoodContext;
        public RestaurantController(IMenuRepository FoodContext)
        {
            _FoodContext = FoodContext;
        }
        public IActionResult Index()
        {
            return View(_FoodContext.GetData());
        }
        
        [HttpGet]
        public IActionResult Create(int ? id)
        {
            var model = _FoodContext.createview(id);
            model.itemname = _FoodContext.Itemdata();
            ViewBag.username = _FoodContext.Userdata();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(int? id,MenuModel obj)
        {
            var selecteditem = obj.itemname.Where(x => x.Selected).Select(y => y.Value).ToList();
            int uid = obj.Username; 
            if (ModelState.IsValid)
            {
                _FoodContext.Insert(id,selecteditem,uid);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Details(int id)
        {
            return View(_FoodContext.GetDetails(id));
        }
        
        public IActionResult Delete(int id)
        {
            _FoodContext.DeleteData(id);
            return RedirectToAction("Index");
        }
    }
}
