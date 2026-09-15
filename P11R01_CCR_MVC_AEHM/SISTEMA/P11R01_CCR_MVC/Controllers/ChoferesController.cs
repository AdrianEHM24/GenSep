//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using P11R01_CCR_MVC.Models;

//namespace P11R01_CCR_MVC.Controllers
//{
//    public class ChoferesController : Controller
//    {
//        private GenSepCCREntities db = new GenSepCCREntities();

//        // GET: Choferes
//        public ActionResult Index()
//        {
//            return View(db.Choferes.ToList());
//        }

//        // GET: Choferes/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Choferes choferes = db.Choferes.Find(id);
//            if (choferes == null)
//            {
//                return HttpNotFound();
//            }
//            return View(choferes);
//        }

//        // GET: Choferes/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Choferes/Create
//        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
//        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "IdChofer,Nombre,ApPaterno,ApMaterno,Telefono,FechaNacimiento,Licencia,UrlFoto,Disponibilidad,FechaRegistro")] Choferes choferes)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Choferes.Add(choferes);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(choferes);
//        }

//        // GET: Choferes/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Choferes choferes = db.Choferes.Find(id);
//            if (choferes == null)
//            {
//                return HttpNotFound();
//            }
//            return View(choferes);
//        }

//        // POST: Choferes/Edit/5
//        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
//        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "IdChofer,Nombre,ApPaterno,ApMaterno,Telefono,FechaNacimiento,Licencia,UrlFoto,Disponibilidad,FechaRegistro")] Choferes choferes)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(choferes).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(choferes);
//        }

//        // GET: Choferes/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Choferes choferes = db.Choferes.Find(id);
//            if (choferes == null)
//            {
//                return HttpNotFound();
//            }
//            return View(choferes);
//        }

//        // POST: Choferes/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Choferes choferes = db.Choferes.Find(id);
//            db.Choferes.Remove(choferes);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using P11R01_CCR_MVC.Models;

namespace P11R01_CCR_MVC.Controllers
{
    public class ChoferesController : Controller
    {
        private GenSepCCREntities db = new GenSepCCREntities();
        private const int PageSize = 10;
        private const string CacheKeyTotal = "ChoferesTotalCount";
        private const int CacheMinutes = 5;

        // GET: Choferes
        public ActionResult Index(int page = 1, string searchString = null)
        {
            if (page < 1) page = 1;

            var query = db.Choferes.AsQueryable();

            bool hasFilter = !string.IsNullOrWhiteSpace(searchString);

            // Filtro global por búsqueda (aplica a todos los registros)
            if (hasFilter)
            {
                var s = searchString.Trim().ToLower();
                query = query.Where(c =>
                    (c.Nombre != null && c.Nombre.ToLower().Contains(s)) ||
                    (c.ApPaterno != null && c.ApPaterno.ToLower().Contains(s)) ||
                    (c.ApMaterno != null && c.ApMaterno.ToLower().Contains(s)) ||
                    (c.Telefono != null && c.Telefono.ToLower().Contains(s)) ||
                    (c.Licencia != null && c.Licencia.ToLower().Contains(s))
                );
            }

            // ---------------------------------------------------------
            // Optimización del COUNT para 2M de registros
            // Si no hay filtro, cacheamos el total 5 minutos.
            // Si hay filtro, el COUNT se hace sobre el subconjunto filtrado
            // (mucho más rápido que sobre toda la tabla).
            // ---------------------------------------------------------
            int totalItems;
            if (!hasFilter)
            {
                var cached = HttpContext.Cache[CacheKeyTotal];
                if (cached != null)
                {
                    totalItems = (int)cached;
                }
                else
                {
                    totalItems = query.Count();
                    HttpContext.Cache.Insert(
                        CacheKeyTotal,
                        totalItems,
                        null,
                        DateTime.Now.AddMinutes(CacheMinutes),
                        Cache.NoSlidingExpiration
                    );
                }
            }
            else
            {
                totalItems = query.Count();
            }

            int totalPages = (int)Math.Ceiling((double)totalItems / PageSize);
            if (totalPages > 0 && page > totalPages) page = totalPages;

            var items = query
                .OrderBy(c => c.IdChofer)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            var pagedResult = new PagedResult<Choferes>
            {
                Items = items,
                PageNumber = page,
                PageSize = PageSize,
                TotalItems = totalItems,
                SearchString = searchString
            };

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ChoferesTable", pagedResult);
            }

            return View(pagedResult);
        }

        // GET: Choferes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choferes choferes = db.Choferes.Find(id);
            if (choferes == null)
            {
                return HttpNotFound();
            }
            return View(choferes);
        }

        // GET: Choferes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Choferes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdChofer,Nombre,ApPaterno,ApMaterno,Telefono,FechaNacimiento,Licencia,UrlFoto,Disponibilidad,FechaRegistro")] Choferes choferes)
        {
            if (ModelState.IsValid)
            {
                db.Choferes.Add(choferes);
                db.SaveChanges();

                // Invalidar caché del total
                HttpContext.Cache.Remove(CacheKeyTotal);

                return RedirectToAction("Index");
            }

            return View(choferes);
        }

        // GET: Choferes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choferes choferes = db.Choferes.Find(id);
            if (choferes == null)
            {
                return HttpNotFound();
            }
            return View(choferes);
        }

        // POST: Choferes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdChofer,Nombre,ApPaterno,ApMaterno,Telefono,FechaNacimiento,Licencia,UrlFoto,Disponibilidad,FechaRegistro")] Choferes choferes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(choferes).State = EntityState.Modified;
                db.SaveChanges();

                // Invalidar caché del total (no cambia el total, pero por consistencia)
                HttpContext.Cache.Remove(CacheKeyTotal);

                return RedirectToAction("Index");
            }
            return View(choferes);
        }

        // GET: Choferes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choferes choferes = db.Choferes.Find(id);
            if (choferes == null)
            {
                return HttpNotFound();
            }
            return View(choferes);
        }

        // POST: Choferes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Choferes choferes = db.Choferes.Find(id);
            db.Choferes.Remove(choferes);
            db.SaveChanges();

            // Invalidar caché del total (el total cambió)
            HttpContext.Cache.Remove(CacheKeyTotal);

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