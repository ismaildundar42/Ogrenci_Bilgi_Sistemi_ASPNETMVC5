using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOkulProject.Models.EntitiyFramework;
namespace MvcOkulProject.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var kulupler = db.tbl_kulupler.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult KulupEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KulupEkle(tbl_kulupler p)
        {
            db.tbl_kulupler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupSil(int id)
        {
            var kulup = db.tbl_kulupler.Find(id);
            db.tbl_kulupler.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetir(int id)
        {
            var guncellenecekKulup = db.tbl_kulupler.Find(id);
            return View("KulupGetir",guncellenecekKulup);
        }
        public ActionResult KulupGuncelle(tbl_kulupler k)
        {
            var kulup = db.tbl_kulupler.Find(k.KULUPID);
            kulup.KULUPAD = k.KULUPAD;
            kulup.KULUPKONTENJAN = k.KULUPKONTENJAN;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulupler");
        }
    }
}