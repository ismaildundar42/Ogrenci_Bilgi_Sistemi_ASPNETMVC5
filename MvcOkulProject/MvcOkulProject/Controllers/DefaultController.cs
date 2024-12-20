using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOkulProject.Models.EntitiyFramework;
namespace MvcOkulProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var dersler = db.tbl_dersler.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDers(tbl_dersler p)
        {
            db.tbl_dersler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersSil(int id)
        {
            var ders = db.tbl_dersler.Find(id);
            db.tbl_dersler.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
        {
            var guncellenecekDers = db.tbl_dersler.Find(id);
            return View("DersGetir",guncellenecekDers);
        }
        public ActionResult DersGuncelle(tbl_dersler d)
        {
            var dersler = db.tbl_dersler.Find(d.DERSID);
            dersler.DERSAD = d.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index","Default");
        }
    }
}