using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcOkulProject.Models.EntitiyFramework;

namespace MvcOkulProject.Controllers
{
    public class OgrenciController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();

        public ActionResult Index()
        {
            var ogrenciler = db.tbl_ogrenciler.ToList();
            return View(ogrenciler);
        }

        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            // Kulüplerin listesini ViewBag'e dolduruyoruz
            ViewBag.dgr = db.tbl_kulupler
                .Select(x => new SelectListItem
                {
                    Text = x.KULUPAD,
                    Value = x.KULUPID.ToString()
                })
                .ToList();

            return View();
        }

        [HttpPost]
        public ActionResult OgrenciEkle(tbl_ogrenciler p)
        {
            // Kulüp bilgisi ilişkilendiriliyor
            var klp = db.tbl_kulupler.Find(p.OGRKULUP);
            if (klp != null)
            {
                p.tbl_kulupler = klp;
            }

            db.tbl_ogrenciler.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult OgrenciSil(int id)
        {
            var ogrenci = db.tbl_ogrenciler.Find(id);
            db.tbl_ogrenciler.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var guncellenecekOgrenci = db.tbl_ogrenciler.Find(id);

            // Kulüpler listesini alıyoruz
            var kulupListesi = db.tbl_kulupler
                                 .Select(k => new SelectListItem
                                 {
                                     Value = k.KULUPID.ToString(),
                                     Text = k.KULUPAD
                                 }).ToList();

            // ViewBag ile kulüp listesini View'a gönderiyoruz
            ViewBag.KulupListesi = kulupListesi;
            // Cinsiyet listesini manuel olarak ekliyoruz
            var cinsiyetListesi = new List<SelectListItem>
    {
        new SelectListItem { Value = "Erkek", Text = "Erkek" },
        new SelectListItem { Value = "Kız", Text = "Kız" }
    };

            // ViewBag ile cinsiyet listesini View'a gönderiyoruz
            ViewBag.CinsiyetListesi = cinsiyetListesi;

            // ViewBag ile kulüp listesini View'a gönderiyoruz
            ViewBag.KulupListesi = kulupListesi;

            return View("OgrenciGetir", guncellenecekOgrenci);
        }
        public ActionResult OgrenciGuncelle(tbl_ogrenciler o)
        {
            var ogrenciler = db.tbl_ogrenciler.Find(o.OGRID);
            ogrenciler.OGRAD = o.OGRAD;
            ogrenciler.OGRSOYAD = o.OGRSOYAD;
            ogrenciler.OGRFOTOGRAF = o.OGRFOTOGRAF;
            ogrenciler.OGRCINSIYET = o.OGRCINSIYET;
            ogrenciler.OGRKULUP = o.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }

    }
}
