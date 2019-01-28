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
    public class kupionePrzedmiotyController : Controller
    {
        private retro_sklepEntities db = new retro_sklepEntities();

        // GET: kupionePrzedmioty
        public ActionResult Index()
        {
            return View(db.kupionePrzedmioty.ToList());
        }

        // GET: kupionePrzedmioty/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kupionePrzedmioty kupionePrzedmioty = db.kupionePrzedmioty.Find(id);
            if (kupionePrzedmioty == null)
            {
                return HttpNotFound();
            }
            return View(kupionePrzedmioty);
        }

        // GET: kupionePrzedmioty/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: kupionePrzedmioty/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NAZWISKO,NAZWA")] kupionePrzedmioty kupionePrzedmioty)
        {
            if (ModelState.IsValid)
            {
                db.kupionePrzedmioty.Add(kupionePrzedmioty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kupionePrzedmioty);
        }

        // GET: kupionePrzedmioty/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kupionePrzedmioty kupionePrzedmioty = db.kupionePrzedmioty.Find(id);
            if (kupionePrzedmioty == null)
            {
                return HttpNotFound();
            }
            return View(kupionePrzedmioty);
        }

        // POST: kupionePrzedmioty/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NAZWISKO,NAZWA")] kupionePrzedmioty kupionePrzedmioty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kupionePrzedmioty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kupionePrzedmioty);
        }

        // GET: kupionePrzedmioty/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kupionePrzedmioty kupionePrzedmioty = db.kupionePrzedmioty.Find(id);
            if (kupionePrzedmioty == null)
            {
                return HttpNotFound();
            }
            return View(kupionePrzedmioty);
        }

        // POST: kupionePrzedmioty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            kupionePrzedmioty kupionePrzedmioty = db.kupionePrzedmioty.Find(id);
            db.kupionePrzedmioty.Remove(kupionePrzedmioty);
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
