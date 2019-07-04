using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebProject.Controllers
{
    public class DishesBookController : Controller
    {
        // GET: DishesBook
        public ActionResult DishesBook()
        {
            IList<DishesBook> list = DishesBookBLL.GetAll();
            List<DishesBook> dishesbooklist = new List<DishesBook>();
            foreach (var temp in list)
            {
                DishesBook dishesbook = new DishesBook();
                dishesbook.BookId = temp.BookId;
                dishesbook.HotelName = temp.HotelName;
                dishesbook.ConsumeTime = temp.ConsumeTime;
                dishesbook.ConsumePersons = temp.ConsumePersons;
                dishesbook.RoomType = temp.RoomType;
                dishesbook.CustomerName = temp.CustomerName;
                dishesbook.CustomerPhone = temp.CustomerPhone;
                dishesbook.CustomerEmail = temp.CustomerEmail;
                dishesbook.Comments = temp.Comments;
                dishesbook.BookTime = temp.BookTime;
                dishesbook.OrderStatus = temp.OrderStatus;
                dishesbooklist.Add(dishesbook);
            }
            return View(dishesbooklist);
        }
        public ActionResult DeleteDishesBook(int BookId)
        {
            DishesBook dishesbook=new DishesBook();
            dishesbook=DishesBookBLL.Get(o => o.BookId == BookId);
            DishesBookBLL.Delete(dishesbook);
            return RedirectToAction("DishesBook");
        }
        public ActionResult ModifyBook(int OrderStatus,int BookId)
        {
            DishesBook dishesbook = new DishesBook();
            dishesbook = DishesBookBLL.Get(o => o.BookId == BookId);
            dishesbook.OrderStatus = OrderStatus;
            DishesBookBLL.Update(dishesbook);
            return RedirectToAction("DishesBook");
        }
    }
}