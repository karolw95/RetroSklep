using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RetroSprzety___v6;

namespace RetroSprzety___v6.Controllers
{
    public class produktyDoRenowacjiController : Controller
    {
        private retro_sklepEntities db = new retro_sklepEntities();

        // GET: produktyDoRenowacji
        public ActionResult Index()
        {
            return View(db.produktyDoRenowacji.ToList());
        }

        // GET: produktyDoRenowacji/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produktyDoRenowacji produktyDoRenowacji = db.produktyDoRenowacji.Find(id);
            if (produktyDoRenowacji == null)
            {
                return HttpNotFound();
            }
            return View(produktyDoRenowacji);
        }

        // GET: produktyDoRenowacji/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: produktyDoRenowacji/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NAZWA,PRODUCENT")] produktyDoRenowacji produktyDoRenowacji)
        {
            if (ModelState.IsValid)
            {
                db.produktyDoRenowacji.Add(produktyDoRenowacji);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produktyDoRenowacji);
        }

        // GET: produktyDoRenowacji/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produktyDoRenowacji produktyDoRenowacji = db.produktyDoRenowacji.Find(id);
            if (produktyDoRenowacji == null)
            {
                return HttpNotFound();
            }
            return View(produktyDoRenowacji);
        }

        // POST: produktyDoRenowacji/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NAZWA,PRODUCENT")] produktyDoRenowacji produktyDoRenowacji)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produktyDoRenowacji).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produktyDoRenowacji);
        }

        // GET: produktyDoRenowacji/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produktyDoRenowacji produktyDoRenowacji = db.produktyDoRenowacji.Find(id);
            if (produktyDoRenowacji == null)
            {
                return HttpNotFound();
            }
            return View(produktyDoRenowacji);
        }

        // POST: produktyDoRenowacji/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            produktyDoRenowacji produktyDoRenowacji = db.produktyDoRenowacji.Find(id);
            db.produktyDoRenowacji.Remove(produktyDoRenowacji);
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
