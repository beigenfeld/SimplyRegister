using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimplyRegister.Models;
using Microsoft.AspNet.Identity;

namespace SimplyRegister.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        // GET: Events
        public ActionResult Index( )
        {
            return View(db.Events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            Event @event = new Event();
            return View(@event);
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "eventId,eventName,eventDate,eventType")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                if (@event.eventType == "Corporate")
                {
                    return RedirectToAction("SetCorporateEventPrices", @event);
                }
                else if (@event.eventType == "Training")
                {
                    return RedirectToAction("SetTrainingEventPrices", @event);
                }
                
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "eventId,eventName,eventDate,eventType, corporatePrice, assocaitePrice, cbaPrice, iapPrice, nonMemberPrice ")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        //GET
        public ActionResult SetCorporateEventPrices(Event @event, bool overloadFiller = false)
        {
            return View(@event);
        }

        //POST
        [HttpPost]
        public ActionResult SetCorporateEventPrices([Bind(Include = "eventId, eventName, eventDate, eventType, corporatePrice, assocaitePrice, cbaPrice, iapPrice, nonMemberPrice")] Event @event)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AdminEventIndex");
            }
            return View(@event);
            
        }


        //GET
        public ActionResult SetTrainingEventPrices(Event @event, bool overloadFiller = false)
        {
            return View(@event);
        }


        //POST
        [HttpPost]
        public ActionResult SetTrainingEventPrices([Bind(Include = "eventId, eventName, eventDate, eventType, corporatePrice, assocaitePrice, cbaPrice, iapPrice, nonMemberPrice")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        public ActionResult RegisterCustomer(int id)
        {

            var Id = User.Identity.GetUserId();
            var customer = db.Customers.FirstOrDefault(c => c.userId == Id);
            var company = db.Companies.FirstOrDefault(c => c.companyId == customer.customerCompany);

            var @event = db.Events.SingleOrDefault(m => m.eventId == id);
            //var user = ApplicationUserManager.//FindById(User.Identity.GetUserId())
            var user = User.Identity.GetUserId();
            if(@event.eventType == "Corporate" && company.companyMembershipLevel != "Corporate" && company.companyMembershipLevel != "Associate")
            {
                return View("RegisterCustomerNonMember");
            }
            else
            {
                return View(@event);
                
            }
            
        }

        
        public ActionResult RegisterCustomerTwo(int customerId,int eventId, double amountBilled)
        {
            Registration reg = new Registration();
            reg.customerId = customerId;
            reg.eventId = eventId;
            reg.amountBilled = amountBilled;

            db.Registrations.Add(reg);
            db.SaveChanges();
            return RedirectToAction("MakePayment", "Customers", reg);
        }

        [HttpPost]
        public ActionResult AddRegistration(Registration reg)
        {
            db.Registrations.Add(reg);
            db.SaveChanges();
            return View("MakePayment", "Customers", reg);
        }

        public ActionResult AdminEventIndex()
        {
            
            return View(db.Events.ToList());
        }




    }
}
