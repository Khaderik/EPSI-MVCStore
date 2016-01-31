using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCStoreApplication.Models;

namespace MVCStoreApplication.Controllers
{
    public class CartsController : Controller
    {
        private MusicStoreContext db = new MusicStoreContext();

        // GET: Carts
        public ActionResult Index()
        {
            var carts = db.Carts.Where(c => c.CartId.Equals("Khaderik"));
            return View(carts.ToList());
        }

        // GET: Carts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // GET: Carts/tate
        public ActionResult Create()
        {
            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "Title");
            return View();
        }

        // POST: Carts/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordId,CartId,AlbumId,Count,DateCreated")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "Title", cart.AlbumId);
            return View(cart);
        }

        // GET: Carts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "Title", cart.AlbumId);
            return View(cart);
        }

        // POST: Carts/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordId,CartId,AlbumId,Count,DateCreated")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "Title", cart.AlbumId);
            return View(cart);
        }

        // GET: Carts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            //Recherche de l'album
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }

            //Récpération du panier correspondant à l'album à insérer et à mon CartId
            Cart monPanier = db.Carts.Where(c => c.CartId.Equals("Khaderik") && c.AlbumId.Equals(id)).FirstOrDefault();
            //Le panier correspondant à l'album existe déjà...
            if (monPanier != null)
            {
                //...on incrémente le count.
                monPanier.Count++;
                db.Entry(monPanier).State = EntityState.Modified;
            }
            //Il n'exite pas...
            else
            {
                //...on le crée
                monPanier = new Cart();
                monPanier.CartId = "Khaderik";
                monPanier.AlbumId = id;
                monPanier.Count = 1;
                monPanier.DateCreated = DateTime.Now;
                db.Carts.Add(monPanier);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Carts/ClearAll
        public ActionResult ClearAll()
        {
            List<Cart> MesPaniers = db.Carts.Where(c => c.CartId.Equals("Khaderik")).ToList();
            MesPaniers.ForEach(p => db.Carts.Remove(p));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult RemoveFromCart(int? id)
        {
            string message = "L'album a bien été supprimé du panier";
            if (id == null)
            {
                message = "Aucune clé ne correspond à l'album";
            }
            //Recherche de la Ligne dans le panier
            Cart cart = db.Carts.Where(c => c.CartId.Equals("Khaderik") && c.RecordId == id).SingleOrDefault();
            if (cart == null)
            {
                message = "L'album n'est pas présent dans votre panier";
            }
            else
            {
                try
                {
                    // Suppression du panier
                    db.Carts.Remove(cart);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    message = "L'album n'a pas pu être supprimé : " + ex.Message;
                    id = 0;
                }
            }

            return Json(new { DeleteId = id, Message = message });
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
