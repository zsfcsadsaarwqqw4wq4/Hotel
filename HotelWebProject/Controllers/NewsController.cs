using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebProject.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            IList<NewsCategory> lists = NewsCategoryBLL.GetAll();
            List<NewsCategory> newscategorylist = new List<NewsCategory>();
            foreach (var temp in lists)
            {
                NewsCategory newscategory = new NewsCategory();
                newscategory.CategoryId = temp.CategoryId;
                newscategory.CategoryName = temp.CategoryName;
                newscategorylist.Add(newscategory);
            }
            return View(newscategorylist);
        }
        [HttpPost]
        public ActionResult NewsPublish(string NewsTitle, string NewsContents, int CategoryId, string PublishTime)
        {
            return RedirectToAction("Index");
        }
        public ActionResult NewsManager()
        {
            IList<News> list = NewsBLL.GetAll();
            List<News> newslist = new List<News>();
            foreach (var temp in list)
            {
                News news = new News();
                news.NewsId = temp.NewsId;
                news.NewsTitle = temp.NewsTitle;
                news.NewsCategory = temp.NewsCategory;
                news.PublishTime = temp.PublishTime;
                news.CategoryId = temp.CategoryId;          
                newslist.Add(news);
            }
            IList<NewsCategory> lists = NewsCategoryBLL.GetAll();
            List<NewsCategory> newscategorylist = new List<NewsCategory>();
            foreach (var temp in lists)
            {
                NewsCategory newscategory = new NewsCategory();
                newscategory.CategoryId = temp.CategoryId;
                newscategory.CategoryName = temp.CategoryName;
                newscategorylist.Add(newscategory);
            }
            ViewBag.NewsCategory = newscategorylist;
            return View(newslist);
        }
        public ActionResult DeleteNews(int NewsId)
        {
            News news = new News();
            news = NewsBLL.Get(o => o.NewsId == NewsId);
            NewsBLL.Delete(news);
            return RedirectToAction("NewsManager");
        }
        public ActionResult UpdateNews(int NewsId)
        {
            News news = new News();
            news = NewsBLL.Get(o => o.NewsId == NewsId);
            NewsCategory newscategorys = new NewsCategory();
            newscategorys = NewsCategoryBLL.Get(o => o.CategoryId == news.CategoryId);
            ViewBag.NewsCategorys = newscategorys;
            IList<NewsCategory> lists = NewsCategoryBLL.GetAll();
            List<NewsCategory> newscategorylist = new List<NewsCategory>();
            foreach (var temp in lists)
            {
                NewsCategory newscategory = new NewsCategory();
                newscategory.CategoryId = temp.CategoryId;
                newscategory.CategoryName = temp.CategoryName;
                newscategorylist.Add(newscategory);
            }
            ViewBag.NewsCategory = newscategorylist;
            return View(news);
        }
        [HttpPost]
        public JsonResult UpdatesNews(int NewsId,string NewsTitle,string NewsContents,int CategoryId,string PublishTime)
        {
            News news = new News();
            news = NewsBLL.Get(o => o.NewsId == NewsId);
            news.NewsTitle = NewsTitle;
            news.NewsContents = NewsContents;
            news.CategoryId = CategoryId;
            news.PublishTime =DateTime.Parse(PublishTime);
            int result=NewsBLL.Update(news);
            string msg = "";
            if (result != 0)
            {
                msg = "修改成功";
            }
            NewsBLL.Update(news);
            return Json(msg);
        }
    }
}