using EventManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult EventManager()
        {
            return View();
        }

        public ActionResult GetEvent()
        {
            using (MyDatabaseEntities2 db = new MyDatabaseEntities2())
            {
                var events = db.Events.OrderBy(a => a.Name).ToList();
                return Json(new { data = events }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            using (MyDatabaseEntities2 db = new MyDatabaseEntities2())
            {
                var view = db.Events.Where(a => a.Id == id).FirstOrDefault();
                return View(view);
            }
        }

        [HttpPost]
        public ActionResult Save(Event events)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (MyDatabaseEntities2 db = new MyDatabaseEntities2())
                {
                    if (events.Id > 0)
                    {
                        var view = db.Events.Where(a => a.Id == events.Id).FirstOrDefault();
                        if (view != null)
                        {
                            view.Name = events.Name;
                            view.Location = events.Location;
                            view.StartDate = events.StartDate;
                            view.StartDateTime = events.StartDateTime;
                            view.EndDate = events.EndDate;
                            view.EndDateTime = events.EndDateTime;
                        }
                    }
                    else
                    {
                        db.Events.Add(events);
                    }
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult {Data=new { status = status} };
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (MyDatabaseEntities2 db = new MyDatabaseEntities2())
            {
                var view = db.Events.Where(a => a.Id == id).FirstOrDefault();
                if (view != null)
                {
                    return View(view);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEvent(int id)
        {
            bool status = false;
            using (MyDatabaseEntities2 db = new MyDatabaseEntities2())
            {
                var view = db.Events.Where(a => a.Id == id).FirstOrDefault();
                if (view != null)
                {
                    db.Events.Remove(view);
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

    }
       
}
