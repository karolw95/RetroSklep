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
    public class dzialajacyProducencisController : Controller
    {
        private retro_sklepEntities db = new retro_sklepEntities();

        // GET: dzialajacyProducencis
        public ActionResult Index()
        {
            return View(db.dzialajacyProducenci.ToList());
        }

        // GET: dzialajacyProducencis/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dzialajacyProducenci dzialajacyProducenci = db.dzialajacyProducenci.Find(id);
            if (dzialajacyProducenci == null)
            {
                return HttpNotFound();
            }
            return View(dzialajacyProducenci);
        }

        // GET: dzialajacyProducencis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: dzialajacyProducencis/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NAZWA,PRODUCENT")] dzialajacyProducenci dzialajacyProducenci)
        {
            if (ModelState.IsValid)
            {
                db.dzialajacyProducenci.Add(dzialajacyProducenci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dzialajacyProducenci);
        }

        // GET: dzialajacyProducencis/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dzialajacyProducenci dzialajacyProducenci = db.dzialajacyProducenci.Find(id);
            if (dzialajacyProducenci == null)
            {
                return HttpNotFound();
            }
            return View(dzialajacyProducenci);
        }

        // POST: dzialajacyProducencis/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NAZWA,PRODUCENT")] dzialajacyProducenci dzialajacyProducenci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dzialajacyProducenci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dzialajacyProducenci);
        }

        // GET: dzialajacyProducencis/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dzialajacyProducenci dzialajacyProducenci = db.dzialajacyProducenci.Find(id);
            if (dzialajacyProducenci == null)
            {
                return HttpNotFound();
            }
            return View(dzialajacyProducenci);
        }

        // POST: dzialajacyProducencis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            dzialajacyProducenci dzialajacyProducenci = db.dzialajacyProducenci.Find(id);
            db.dzialajacyProducenci.Remove(dzialajacyProducenci);
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
        public ActionResult Show()
        {
            var query = from a in db.dzialajacyProducenci select a;
            return View(query.ToList());
        }
    }
}
