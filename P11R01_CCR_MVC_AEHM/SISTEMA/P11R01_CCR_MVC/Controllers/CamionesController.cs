using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using P11R01_CCR_MVC.Models;

namespace P11R01_CCR_MVC.Controllers
{
    public class CamionesController : Controller
    {
        private GenSepCCREntities db = new GenSepCCREntities();
        private const int PageSize = 10;
        private const string CacheKeyTotal = "CamionesTotalCount";
        private const int CacheMinutes = 5;

        // GET: Camiones
        public ActionResult Index(int page = 1, string searchString = null)
        {
            if (page < 1) page = 1;

            var query = db.Camiones.AsQueryable();

            bool hasFilter = !string.IsNullOrWhiteSpace(searchString);

            // Filtro global por búsqueda (aplica a todos los registros)
            if (hasFilter)
            {
                var s = searchString.Trim().ToLower();

                query = query.Where(c =>
                    (c.Matricula != null && c.Matricula.ToLower().Contains(s)) ||
                    (c.TipoCamion != null && c.TipoCamion.ToLower().Contains(s)) ||
                    (c.Marca != null && c.Marca.ToLower().Contains(s)) ||
                    (c.UrlFoto != null && c.UrlFoto.ToLower().Contains(s)) ||
                    // Modelo es int → lo convertimos a string para poder buscar
                    SqlFunctions.StringConvert((double)c.Modelo).Trim().Contains(s)
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
                .OrderBy(c => c.IdCamion)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            var pagedResult = new PagedResult<Camiones>
            {
                Items = items,
                PageNumber = page,
                PageSize = PageSize,
                TotalItems = totalItems,
                SearchString = searchString
            };

            if (Request.IsAjaxRequest())
            {
                return PartialView("_CamionesTable", pagedResult);
            }

            return View(pagedResult);
        }

        // GET: Camiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camiones camiones = db.Camiones.Find(id);
            if (camiones == null)
            {
                return HttpNotFound();
            }
            return View(camiones);
        }

        // GET: Camiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Camiones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCamion,Matricula,TipoCamion,Modelo,Marca,Capacidad,Kilometraje,Disponibilidad,UrlFoto")] Camiones camiones)
        {
            if (ModelState.IsValid)
            {
                db.Camiones.Add(camiones);
                db.SaveChanges();

                HttpContext.Cache.Remove(CacheKeyTotal);

                return RedirectToAction("Index");
            }

            return View(camiones);
        }

        // GET: Camiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camiones camiones = db.Camiones.Find(id);
            if (camiones == null)
            {
                return HttpNotFound();
            }
            return View(camiones);
        }

        // POST: Camiones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCamion,Matricula,TipoCamion,Modelo,Marca,Capacidad,Kilometraje,Disponibilidad,UrlFoto")] Camiones camiones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(camiones).State = EntityState.Modified;
                db.SaveChanges();

                HttpContext.Cache.Remove(CacheKeyTotal);

                return RedirectToAction("Index");
            }
            return View(camiones);
        }

        // GET: Camiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camiones camiones = db.Camiones.Find(id);
            if (camiones == null)
            {
                return HttpNotFound();
            }
            return View(camiones);
        }

        // POST: Camiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Camiones camiones = db.Camiones.Find(id);
            db.Camiones.Remove(camiones);
            db.SaveChanges();

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