using BLL;
using HotelWebProject.AppHelper;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebProject.Controllers
{
    public class DishesController : Controller
    {
        // GET: Dishes
        public ActionResult Index()
        {
            IList<DishesCategory> list = DishesCategoryBLL.GetAll();
            List<DishesCategory> dishescategorylist = new List<DishesCategory>();
            foreach (var temp in list)
            {
                DishesCategory dishescategory = new DishesCategory();
                dishescategory.CategoryId = temp.CategoryId;
                dishescategory.CategoryName = temp.CategoryName;
                dishescategorylist.Add(dishescategory);
            }
            return View(dishescategorylist);
        }
        [HttpPost]
        public ActionResult DishesPublish(string DishesName, string UnitPrice, int CategoryId)
        {
            Dishes dishes = new Dishes();
            dishes.UnitPrice = int.Parse(UnitPrice);
            dishes.DishesName = DishesName;
            dishes.CategoryId = CategoryId;
            DishesBLL.Create(dishes);
            Dishes dishess = new Dishes();
            dishess=DishesBLL.Get(o => o.DishesName == DishesName);
            HttpPostedFileBase file = Request.Files["DishesImage"];
            string filePath = Server.MapPath(string.Format("~/{0}", "Images/dishes"));
            string imagename = dishess.DishesId + ".PNG";
            string savePath;
            savePath = Path.Combine(filePath, imagename);
            file.SaveAs(savePath);          
            return RedirectToAction("Index");
        }
        public ActionResult DishesManager()
        {
            IList<Dishes> list = DishesBLL.GetAll();
            List<DishesCategoryHelper> disheslist = new List<DishesCategoryHelper>();
            foreach (var temp in list)
            {
                DishesCategoryHelper dishes = new DishesCategoryHelper();
                dishes.DishesId = temp.DishesId;
                dishes.DishesName = temp.DishesName;
                dishes.CategoryId =Convert.ToInt32(temp.CategoryId);
                dishes.UnitPrice =Convert.ToDecimal(temp.UnitPrice);
                DishesCategory dishescategory=new DishesCategory();
                dishescategory=DishesCategoryBLL.Get(o => o.CategoryId == dishes.CategoryId);
                dishes.CategoryName = dishescategory.CategoryName;
                disheslist.Add(dishes);
            }

            ViewData["dishesManager"] = disheslist;
            IList<DishesCategory> lists = DishesCategoryBLL.GetAll();
            List<DishesCategory> dishescategorylist = new List<DishesCategory>();
            foreach (var temp in lists)
            {
                DishesCategory dishescategorys = new DishesCategory();
                dishescategorys.CategoryId = temp.CategoryId;
                dishescategorys.CategoryName = temp.CategoryName;
                dishescategorylist.Add(dishescategorys);
            }
            ViewBag.dishescategorylist = dishescategorylist;
            return View();
        }
        [HttpPost]
        public JsonResult DeleteDishes(int dishesId)
        {
            Dishes dishes = new Dishes();
            Dishes dishess = new Dishes();
            dishes = DishesBLL.Get(o => o.DishesId == dishesId);
            dishess=DishesBLL.Delete(dishes);
            string msg = "";
            if(dishess!= null)
            {
                msg = "success";
            }
            return Json(msg);
        }
        public ActionResult UpdateDishes(int dishesId,int categoryId)
        {
            Dishes dishes = DishesBLL.Get(o=>o.DishesId==dishesId);
            DishesCategory dishescategory = DishesCategoryBLL.Get(o => o.CategoryId == categoryId);           
            ViewData["dishescategory"] = dishescategory;
            ViewBag.dishes = dishes;
            IList<DishesCategory> list = DishesCategoryBLL.GetAll();
            List<DishesCategory> dishescategorylist = new List<DishesCategory>();
            foreach (var temp in list)
            {
                DishesCategory dishescategorys = new DishesCategory();
                dishescategorys.CategoryId = temp.CategoryId;
                dishescategorys.CategoryName = temp.CategoryName;
                dishescategorylist.Add(dishescategorys);
            }
            return View(dishescategorylist);
        }
        public ActionResult UpdatesDishes(Dishes dishes)
        {            
            Dishes dishess = new Dishes();
            dishess = DishesBLL.Get(o => o.DishesId == dishes.DishesId);
            dishess.DishesId = dishes.DishesId;
            dishess.DishesName = dishes.DishesName;
            dishess.UnitPrice = dishes.UnitPrice;
            dishess.CategoryId = dishes.CategoryId;
            DishesBLL.Update(dishess);
            return RedirectToAction("/DishesManager");
        }
        public ActionResult QueryDishes(int CategoryId)
        {
            List<Dishes> list = DishesBLL.ToList(o=>o.CategoryId== CategoryId);
            List<DishesCategoryHelper> disheslist = new List<DishesCategoryHelper>();
            foreach (var temp in list)
            {
                DishesCategoryHelper dishes = new DishesCategoryHelper();
                dishes.DishesId = temp.DishesId;
                dishes.DishesName = temp.DishesName;
                dishes.CategoryId = Convert.ToInt32(temp.CategoryId);
                dishes.UnitPrice = Convert.ToDecimal(temp.UnitPrice);
                DishesCategory dishescategory = new DishesCategory();
                dishescategory = DishesCategoryBLL.Get(o => o.CategoryId == dishes.CategoryId);
                dishes.CategoryName = dishescategory.CategoryName;
                disheslist.Add(dishes);
            }

            ViewData["dishesManager"] = disheslist;
            IList<DishesCategory> lists = DishesCategoryBLL.GetAll();
            List<DishesCategory> dishescategorylist = new List<DishesCategory>();
            foreach (var temp in lists)
            {
                DishesCategory dishescategorys = new DishesCategory();
                dishescategorys.CategoryId = temp.CategoryId;
                dishescategorys.CategoryName = temp.CategoryName;
                dishescategorylist.Add(dishescategorys);
            }
            ViewBag.dishescategorylist = dishescategorylist;
            DishesCategory dishescategoryss = DishesCategoryBLL.Get(o => o.CategoryId == CategoryId);
            ViewBag.dishescategoryss = dishescategoryss;
            return View();
        }
    }
}