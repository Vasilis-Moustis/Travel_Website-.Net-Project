using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MyTravelWebsite.Models;

namespace MyTravelWebsite.Controllers
{
    [Authorize]
    public class TravelPacketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TravelPackets
        public ActionResult Index()
        {
            return View(db.TravelPackets.ToList());
        }

        // GET: TravelPackets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelPacket travelPacket = db.TravelPackets.Find(id);
            if (travelPacket == null)
            {
                return HttpNotFound();
            }
            return View(travelPacket);
        }

        // GET: TravelPackets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TravelPackets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Destination,Company,Departure,Return,Tranportation,Price")] TravelPacket travelPacket)
        {
            if (ModelState.IsValid)
            {
                db.TravelPackets.Add(travelPacket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(travelPacket);
        }

        // GET: TravelPackets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelPacket travelPacket = db.TravelPackets.Find(id);
            if (travelPacket == null)
            {
                return HttpNotFound();
            }
            return View(travelPacket);
        }

        // POST: TravelPackets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Destination,Company,Departure,Return,Tranportation,Price")] TravelPacket travelPacket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(travelPacket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(travelPacket);
        }

        // GET: TravelPackets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelPacket travelPacket = db.TravelPackets.Find(id);
            if (travelPacket == null)
            {
                return HttpNotFound();
            }
            return View(travelPacket);
        }

        // POST: TravelPackets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TravelPacket travelPacket = db.TravelPackets.Find(id);
            db.TravelPackets.Remove(travelPacket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Show Search Packet, specific Destination
        public async Task<ActionResult> ShowSearchPacket(String SearchPhrase)
        {
            return View("Index", await db.TravelPackets.Where(u => u.Destination.Contains(SearchPhrase)).ToListAsync());
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
