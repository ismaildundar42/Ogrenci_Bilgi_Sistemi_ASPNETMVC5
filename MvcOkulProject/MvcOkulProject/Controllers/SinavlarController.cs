using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOkulProject.Models.EntitiyFramework;
using MvcOkulProject.Models;
namespace MvcOkulProject.Controllers
{
    public class SinavlarController : Controller
    {
        // GET: Sinavlar
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var sinavlar = db.tbl_sinavlar.ToList();
            return View(sinavlar);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {
            var dersler = db.tbl_dersler.ToList();
            ViewBag.DersListesi = new SelectList(dersler, "DERSID", "DERSAD");
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(tbl_sinavlar s)
        {
            db.tbl_sinavlar.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SinavGetir(int id)
        {
            var guncellenecekSinav = db.tbl_sinavlar.Find(id);
            return View("SinavGetir", guncellenecekSinav);
        }
        [HttpPost]
        public ActionResult SinavGetir(Class1 model,tbl_sinavlar s, int SINAV1 = 0, int SINAV2 = 0, int SINAV3 = 0, int PROJE = 0)
        {
            if (model.islem == "HESAPLA")
            {
                // işlem 1
                float ortalama =(float) ((SINAV1 + SINAV2 + SINAV3 + PROJE) /4);
                ViewBag.ort = ortalama;
            }
            if (model.islem == "NOTGUNCELLE")
            {
                var sinavlar = db.tbl_sinavlar.Find(s.NOTID);
                sinavlar.SINAV1 = s.SINAV1;
                sinavlar.SINAV2 = s.SINAV2;
                sinavlar.SINAV3 = s.SINAV3;
                sinavlar.PROJE = s.PROJE;
                sinavlar.ORTALAMA = s.ORTALAMA;
                sinavlar.DURUM = s.DURUM;
                db.SaveChanges();
                return RedirectToAction("Index","Sinavlar");
            }
            return View();
        }

    }
}