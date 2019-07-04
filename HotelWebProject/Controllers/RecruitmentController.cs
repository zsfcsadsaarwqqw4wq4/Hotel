using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebProject.Controllers
{
    public class RecruitmentController : Controller
    {
        // GET: Recruitment
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Publish(Recruitment recruitment)
        {
            DateTime time=DateTime.Now;
            recruitment.PublishTime = time;
            RecruitmentBLL.Create(recruitment);
            return View("Index");
        }
        public ActionResult RecruitmentManager()
        {
            IList<Recruitment> list=RecruitmentBLL.GetAll();
            List<Recruitment> recruitmentlist = new List<Recruitment>();
            foreach (var temp in list)
            {
                Recruitment recruitment = new Recruitment();
                recruitment.PostId = temp.PostId;
                recruitment.PostName = temp.PostName;
                recruitment.PostType = temp.PostType;
                recruitment.PostPlace = temp.PostPlace;
                recruitment.PostDesc = temp.PostDesc;
                recruitment.PostRequire = temp.PostRequire;
                recruitment.Experience = temp.Experience;
                recruitment.EduBackground = temp.EduBackground;
                recruitment.RequireCount = temp.RequireCount;
                recruitment.PublishTime = temp.PublishTime;
                recruitment.Manager = temp.Manager;
                recruitment.PhoneNumber = temp.PhoneNumber;
                recruitment.Email = temp.Email;
                recruitmentlist.Add(recruitment);
            }
            ViewData["RecruitmentManager"] = recruitmentlist;
            return View();
        }
        public ActionResult RecruitmentUpdate(int postId)
        {
            Recruitment recruitment = new Recruitment();
            recruitment = RecruitmentBLL.Get(o => o.PostId == postId);
            return View(recruitment);
        }
        public ActionResult RecruitmentsUpdate(Recruitment recruitment)
        {
            Recruitment recruitments = new Recruitment();
            recruitments = RecruitmentBLL.Get(o => o.PostId == recruitment.PostId);
            recruitments.PostName = recruitment.PostName;
            recruitments.PostType = recruitment.PostType;
            recruitments.PostPlace = recruitment.PostPlace;
            recruitments.PostDesc = recruitment.PostDesc;
            recruitments.PostRequire = recruitment.PostRequire;
            recruitments.Experience = recruitment.Experience;
            recruitments.EduBackground = recruitment.EduBackground;
            recruitments.RequireCount = recruitment.RequireCount;
            recruitments.PublishTime = recruitment.PublishTime;
            recruitments.Manager = recruitment.Manager;
            recruitments.PhoneNumber = recruitment.PhoneNumber;
            recruitments.Email = recruitment.Email;
            RecruitmentBLL.Update(recruitments);
            return RedirectToAction("/RecruitmentManager");
        }
        public ActionResult DeleteRecruitment(int postId)
        {
            Recruitment recruitments = new Recruitment();
            recruitments = RecruitmentBLL.Get(o => o.PostId == postId);
            RecruitmentBLL.Delete(recruitments);
            return RedirectToAction("/RecruitmentManager");
        }
    }
}