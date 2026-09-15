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
//    public class RutasController : Controller
//    {
//        private GenSepCCREntities db = new GenSepCCREntities();

//        // GET: Rutas
//        public ActionResult Index()
//        {
//            var rutas = db.Rutas.Include(r => r.Camiones).Include(r => r.Choferes);
//            return View(rutas.ToList());
//        }

//        // GET: Rutas/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Rutas rutas = db.Rutas.Find(id);
//            if (rutas == null)
//            {
//                return HttpNotFound();
//            }
//            return View(rutas);
//        }

//        // GET: Rutas/Create
//        public ActionResult Create()
//        {
//            ViewBag.IdCamion = new SelectList(db.Camiones, "IdCamion", "Matricula");
//            ViewBag.IdChofer = new SelectList(db.Choferes, "IdChofer", "Nombre");
//            return View();
//        }

//        // POST: Rutas/Create
//        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
//        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "IdRuta,IdChofer,IdCamion,Origen,Destino,FechaSalida,FechaLlegada,ATiempo,Distancia,FechaRegistro")] Rutas rutas)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Rutas.Add(rutas);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.IdCamion = new SelectList(db.Camiones, "IdCamion", "Matricula", rutas.IdCamion);
//            ViewBag.IdChofer = new SelectList(db.Choferes, "IdChofer", "Nombre", rutas.IdChofer);
//            return View(rutas);
//        }

//        // GET: Rutas/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Rutas rutas = db.Rutas.Find(id);
//            if (rutas == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.IdCamion = new SelectList(db.Camiones, "IdCamion", "Matricula", rutas.IdCamion);
//            ViewBag.IdChofer = new SelectList(db.Choferes, "IdChofer", "Nombre", rutas.IdChofer);
//            return View(rutas);
//        }

//        // POST: Rutas/Edit/5
//        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
//        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "IdRuta,IdChofer,IdCamion,Origen,Destino,FechaSalida,FechaLlegada,ATiempo,Distancia,FechaRegistro")] Rutas rutas)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(rutas).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.IdCamion = new SelectList(db.Camiones, "IdCamion", "Matricula", rutas.IdCamion);
//            ViewBag.IdChofer = new SelectList(db.Choferes, "IdChofer", "Nombre", rutas.IdChofer);
//            return View(rutas);
//        }

//        // GET: Rutas/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Rutas rutas = db.Rutas.Find(id);
//            if (rutas == null)
//            {
//                return HttpNotFound();
//            }
//            return View(rutas);
//        }

//        // POST: Rutas/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Rutas rutas = db.Rutas.Find(id);
//            db.Rutas.Remove(rutas);
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
    public class RutasController : Controller
    {
        private GenSepCCREntities db = new GenSepCCREntities();
        private const int PageSize = 10;
        private const string CacheKeyTotal = "RutasTotalCount";
        private const int CacheMinutes = 5;

        // GET: Rutas
        public ActionResult Index(int page = 1, string searchString = null)
        {
            if (page < 1) page = 1;

            // Include de navegaciones para poder mostrar Matricula y Nombre en la tabla
            var query = db.Rutas
                          .Include(r => r.Camiones)
                          .Include(r => r.Choferes)
                          .AsQueryable();

            bool hasFilter = !string.IsNullOrWhiteSpace(searchString);

            // Filtro global por búsqueda (aplica a todos los registros)
            if (hasFilter)
            {
                var s = searchString.Trim().ToLower();
                query = query.Where(r =>
                    (r.Origen != null && r.Origen.ToLower().Contains(s)) ||
                    (r.Destino != null && r.Destino.ToLower().Contains(s)) ||
                    // Búsqueda en navegación: matrícula del camión
                    (r.Camiones != null && r.Camiones.Matricula != null && r.Camiones.Matricula.ToLower().Contains(s)) ||
                    // Búsqueda en navegación: nombre del chofer
                    (r.Choferes != null && r.Choferes.Nombre != null && r.Choferes.Nombre.ToLower().Contains(s))
                );
            }

            // ---------------------------------------------------------
            // Optimización del COUNT
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
                .OrderBy(r => r.IdRuta)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            var pagedResult = new PagedResult<Rutas>
            {
                Items = items,
                PageNumber = page,
                PageSize = PageSize,
                TotalItems = totalItems,
                SearchString = searchString
            };

            if (Request.IsAjaxRequest())
            {
                return PartialView("_RutasTable", pagedResult);
            }

            return View(pagedResult);
        }

        // GET: Rutas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rutas rutas = db.Rutas.Find(id);
            if (rutas == null)
            {
                return HttpNotFound();
            }
            return View(rutas);
        }

        // GET: Rutas/Create
        public ActionResult Create()
        {
            ViewBag.IdCamion = new SelectList(db.Camiones, "IdCamion", "Matricula");
            ViewBag.IdChofer = new SelectList(db.Choferes, "IdChofer", "Nombre");
            return View();
        }

        // POST: Rutas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRuta,IdChofer,IdCamion,Origen,Destino,FechaSalida,FechaLlegada,ATiempo,Distancia,FechaRegistro")] Rutas rutas)
        {
            if (ModelState.IsValid)
            {
                db.Rutas.Add(rutas);
                db.SaveChanges();

                // Invalidar caché del total
                HttpContext.Cache.Remove(CacheKeyTotal);

                return RedirectToAction("Index");
            }

            ViewBag.IdCamion = new SelectList(db.Camiones, "IdCamion", "Matricula", rutas.IdCamion);
            ViewBag.IdChofer = new SelectList(db.Choferes, "IdChofer", "Nombre", rutas.IdChofer);
            return View(rutas);
        }

        // GET: Rutas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rutas rutas = db.Rutas.Find(id);
            if (rutas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCamion = new SelectList(db.Camiones, "IdCamion", "Matricula", rutas.IdCamion);
            ViewBag.IdChofer = new SelectList(db.Choferes, "IdChofer", "Nombre", rutas.IdChofer);
            return View(rutas);
        }

        // POST: Rutas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRuta,IdChofer,IdCamion,Origen,Destino,FechaSalida,FechaLlegada,ATiempo,Distancia,FechaRegistro")] Rutas rutas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rutas).State = EntityState.Modified;
                db.SaveChanges();

                // Invalidar caché por consistencia
                HttpContext.Cache.Remove(CacheKeyTotal);

                return RedirectToAction("Index");
            }
            ViewBag.IdCamion = new SelectList(db.Camiones, "IdCamion", "Matricula", rutas.IdCamion);
            ViewBag.IdChofer = new SelectList(db.Choferes, "IdChofer", "Nombre", rutas.IdChofer);
            return View(rutas);
        }

        // GET: Rutas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rutas rutas = db.Rutas.Find(id);
            if (rutas == null)
            {
                return HttpNotFound();
            }
            return View(rutas);
        }

        // POST: Rutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rutas rutas = db.Rutas.Find(id);
            db.Rutas.Remove(rutas);
            db.SaveChanges();

            // Invalidar caché (el total cambió)
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