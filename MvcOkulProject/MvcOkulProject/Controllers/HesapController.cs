using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOkulProject.Controllers
{
    public class HesapController : Controller
    {
        // GET: Hesap
        public ActionResult Index(int s1=0,int s2=0,int s3 = 0,int prj = 0)
        {
            float sonuc = (float)((s1 * 0.25)+(s2*0.25)+(s3*0.25)+(prj*0.25));
            ViewBag.snc = sonuc;
            return View();
        }
    }
}