using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimplyRegister.Models;
using MVCEmail.Models;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SimplyRegister.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            var companiesList = db.Companies.ToList();
            Customer customer = new Customer()
            {
                companyId = 0,
                Companies = companiesList
                
            };
            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerId,firstName,lastName,customerCompany,clcMember")] Customer customer, Company company)
        {
            if (ModelState.IsValid)
            {
                var currentUserName = User.Identity.Name;
                var currentUserId = db.Users.Where(m => m.UserName == currentUserName).Select(m => m.Id).First();
                customer.isAdmin = false;
                customer.userId = currentUserId;
                customer.customerCompany = company.companyId;




                db.Customers.Add(customer);
                db.SaveChanges();

                var message = new MailMessage();
                message.To.Add(new MailAddress("umabob2017@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("umabob2017@gmail.com");  // replace with valid value
                message.Subject = "Verify Employment";
                message.Body = "Please verify this person is an employee.";
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "umabob2017@gmail.com",  // replace with valid value
                        Password = "UmaBob123!"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(message);

                }
                return RedirectToAction("CustomerHome", "Customers", customer);
                
            }

            return View(customer);
        }


        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerId,firstName,lastName,customerCompany,clcMember")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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

        public ActionResult CustomerHome()
        {
            return View();
        }

        public ActionResult CompanyPassword()
        {
            return View();
        }





        // GET: Customers/Create
        public ActionResult AdminCreate()
        {
            var companiesList = db.Companies.ToList();
            Customer customer = new Customer()
            {
                companyId = 0,
                Companies = companiesList
            };
            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminCreate([Bind(Include = "customerId,firstName,lastName,customerCompany,clcMember")] Customer customer, Company company)
        {
            if (ModelState.IsValid)
            {
                customer.isAdmin = true;
                customer.customerCompany = company.companyId;
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Register", "Account", customer);
            }

            return View(customer);
        }

        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult MakePayment(Registration reg)
        {
            db.Registrations.Add(reg);
            db.SaveChanges();
            return View(reg);
        }
        [HttpPost]
        public ActionResult MakePayment(Registration reg, bool lala = false)
        {
            db.Registrations.Add(reg);
            db.SaveChanges();
            //return View("MakePayment", "Customers", reg);
            return View();
        }

        public ActionResult EventRegister(Customer customer, Event @event)
        {
            //double pricePoint;
            //if (customer.company.companyMembershipLevel == "Corporate")
            //{
            //    pricePoint = @event.corporatePrice;
            //}
            //else if (customer.company.companyMembershipLevel == "Associate")
            //{
            //    pricePoint = @event.assocaitePrice;
            //}
            //else if (customer.company.companyMembershipLevel == "CBA")
            //{
            //    pricePoint = @event.cbaPrice;
            //}
            //else if (customer.company.companyMembershipLevel == "IAP")
            //{
            //    pricePoint = @event.iapPrice;
            //}
            //else if (customer.company.companyMembershipLevel == "Non-Member")
            //{
            //    pricePoint = @event.nonMemberPrice;
            //}

            return View();
        }




        
        public ActionResult InvoiceConfirmation()
        
        {
            
            if (ModelState.IsValid)
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress("umabob2017@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("umabob2017@gmail.com");  // replace with valid value
                message.Subject = "Please Send Invoice";
                message.Body = "Please send invoice";
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "umabob2017@gmail.com",  // replace with valid value
                        Password = "UmaBob123!"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send (message);
                    return View("InvoiceConfirmation");

                }
            }
            return View();
        }

        public ActionResult UpdateCompany()
        {
            var currentUserName = User.Identity.Name;
            var currentUserId = db.Users.Where(m => m.UserName == currentUserName).Select(m => m.Id).FirstOrDefault();
            var customer = db.Customers.Where(m => m.userId == currentUserId).FirstOrDefault();
            
            var companiesList = db.Companies.ToList();
            customer.Companies = companiesList;
              
            return View(customer);
        }

        [HttpPost]
        public ActionResult UpdateCompany([Bind(Include = "customerId,firstName,lastName,customerCompany,clcMember")] Customer customer, Company company)
        {
            var currentUserName = User.Identity.Name;
            var currentUserId = db.Users.Where(m => m.UserName == currentUserName).Select(m => m.Id).FirstOrDefault();
            var currentCustomer = db.Customers.Where(m => m.userId == currentUserId).First();
            currentCustomer.customerCompany = company.companyId;
            db.SaveChanges();
            return RedirectToAction("CompanyUpdated");
        }


        //public ActionResult InvoiceConfirmation()
        // {
        //     return View();
        // }


        //public ActionResult MyEvents()
        //{
        //    foreach (var item in db.Registrations)
        //    {
        //        if (item.customerId == )
        //        {

        //        }
        //    }
        //    return View();
        //}


        public ActionResult CompanyUpdated()
        {
            return View();
        }





    }
}
