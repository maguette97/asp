using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TripAdvisor.Models;
using Tripadvisor.Models;
using PagedList;

namespace Tripadvisor.Controllers
{
    public class TypeBienViewModelsController : Controller
    {
        private bdtripadvisorEntities1 db = new bdtripadvisorEntities1();
        int pageSize = 5;

        // GET: TypeBienViewModels
        public ActionResult Index(int? page, string CodeTypeBien, string LibelleTypeBien)
        {
            ViewBag.LibelleTypeBien = string.IsNullOrEmpty(LibelleTypeBien)? string.Empty : LibelleTypeBien;
            ViewBag.CodeTypeBien = string.IsNullOrEmpty(CodeTypeBien) ? string.Empty : CodeTypeBien;
            List<TypeBienViewModel> liste = new List<TypeBienViewModel>();
            var list = db.TypeBien.ToList();

            if (!string.IsNullOrEmpty(CodeTypeBien))
            {
                list = list.Where(a => a.CodeTypeBien.ToUpper() == CodeTypeBien.ToUpper()).ToList();
            }
            if (!string.IsNullOrEmpty(LibelleTypeBien))
            {
                list = list.Where(a => a.LibelleTypeBien.ToUpper().Contains(LibelleTypeBien.ToUpper())).ToList();
            }

            foreach (var i in list)
            {
                TypeBienViewModel t = new TypeBienViewModel();
                t.IdTypeBien = i.IdTypeBien;
                t.CodeTypeBien = i.CodeTypeBien;
                t.LibelleTypeBien = i.LibelleTypeBien;
                liste.Add(t);

            }
            page = page.HasValue ? page : 1;
            return View(liste.ToPagedList((int)page, pageSize));
        }

        // GET: TypeBienViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var i = db.TypeBien.Find(id);
            TypeBienViewModel typeBienViewModel = new TypeBienViewModel();
            typeBienViewModel.IdTypeBien = i.IdTypeBien;
            typeBienViewModel.CodeTypeBien = i.CodeTypeBien;
            typeBienViewModel.LibelleTypeBien = i.LibelleTypeBien;
           // TypeBienViewModel typeBienViewModel = db.TypeBienViewModels.Find(id);
            if (typeBienViewModel == null)
            {
                return HttpNotFound();
            }
            return View(typeBienViewModel);
        }

        // GET: TypeBienViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeBienViewModels/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTypeBien,CodeTypeBien,LibelleTypeBien")] TypeBienViewModel typeBienViewModel)
        {
            if (ModelState.IsValid)
            {
                TypeBien t = new TypeBien();
                t.IdTypeBien = typeBienViewModel.IdTypeBien;
                t.CodeTypeBien = typeBienViewModel.CodeTypeBien;
                t.LibelleTypeBien = typeBienViewModel.LibelleTypeBien;
                db.TypeBien.Add(t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeBienViewModel);
        }

        // GET: TypeBienViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var i = db.TypeBien.Find(id);
            TypeBienViewModel typeBienViewModel = new TypeBienViewModel();
            typeBienViewModel.IdTypeBien = i.IdTypeBien;
            typeBienViewModel.CodeTypeBien = i.CodeTypeBien;
            typeBienViewModel.LibelleTypeBien = i.LibelleTypeBien;
            //TypeBienViewModel typeBienViewModel = db.TypeBienViewModels.Find(id);
            if (typeBienViewModel == null)
            {
                return HttpNotFound();
            }
            return View(typeBienViewModel);
        }

        // POST: TypeBienViewModels/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTypeBien,CodeTypeBien,LibelleTypeBien")] TypeBienViewModel typeBienViewModel)
        {
            if (ModelState.IsValid)
            {
                TypeBien t = db.TypeBien.Find(typeBienViewModel.IdTypeBien);
                t.IdTypeBien = typeBienViewModel.IdTypeBien;
                t.CodeTypeBien = typeBienViewModel.CodeTypeBien;
                t.LibelleTypeBien = typeBienViewModel.LibelleTypeBien;
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeBienViewModel);
        }

        // GET: TypeBienViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var i = db.TypeBien.Find(id);
            TypeBienViewModel typeBienViewModel = new TypeBienViewModel();
            typeBienViewModel.IdTypeBien = i.IdTypeBien;
            typeBienViewModel.CodeTypeBien = i.CodeTypeBien;
            typeBienViewModel.LibelleTypeBien = i.LibelleTypeBien;
            //TypeBienViewModel typeBienViewModel = db.TypeBienViewModels.Find(id);
            if (typeBienViewModel == null)
            {
                return HttpNotFound();
            }
            return View(typeBienViewModel);
        }

        // POST: TypeBienViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //TypeBienViewModel typeBienViewModel = db.TypeBienViewModels.Find(id);
            TypeBien t = db.TypeBien.Find(id);
            db.TypeBien.Remove(t);
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
