using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mailer.Models;

namespace Mailer.Controllers
{
    public class MailListController : Controller
    {
        private MailerContext db = new MailerContext();

        // GET: MailList
        public ActionResult Index()
        {
            return View(db.Receivers.ToList());
        }

        // GET: MailList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receiver receiver = db.Receivers.Find(id);
            if (receiver == null)
            {
                return HttpNotFound();
            }
            return View(receiver);
        }

        // GET: MailList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MailList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmailAddress,FirstName,LastName")] Receiver receiver)
        {
            if (ModelState.IsValid)
            {
                db.Receivers.Add(receiver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(receiver);
        }

        // GET: MailList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receiver receiver = db.Receivers.Find(id);
            if (receiver == null)
            {
                return HttpNotFound();
            }
            return View(receiver);
        }

        // POST: MailList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmailAddress,FirstName,LastName")] Receiver receiver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receiver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(receiver);
        }

        // GET: MailList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receiver receiver = db.Receivers.Find(id);
            if (receiver == null)
            {
                return HttpNotFound();
            }
            return View(receiver);
        }

        // POST: MailList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receiver receiver = db.Receivers.Find(id);
            db.Receivers.Remove(receiver);
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
    }
}
