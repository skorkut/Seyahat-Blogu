﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeyahatSitesi.Models.Siniflar;
namespace SeyahatSitesi.Controllers
{
    public class DefaultController : Controller
    {
		// GET: Default
		//Contextden c türünde bir değer ürettik
		Context c = new Context();
        public ActionResult Index()
        {
            
            var degerler=c.Blogs.Take(8).ToList();
            return View(degerler);
        }
        public ActionResult About()
        {
            return View();
        }

        public PartialViewResult Partial1()
        {
            //Sondan 2 adet değeri partialda göstermeye yarayan metot
            var degerler=c.Blogs.OrderByDescending(x=>x.ID).Take(2).ToList();
            return PartialView(degerler);
        }

		public PartialViewResult Partial2()
        {
            var deger=c.Blogs.Where(x=> x.ID==1).ToList();
			return PartialView(deger);
		}

		public PartialViewResult Partial3()
        {
            var deger = c.Blogs.Take(10).ToList();
            return PartialView(deger);
        }

		public PartialViewResult Partial4()
		{
			var deger = c.Blogs.Take(3).ToList();
			return PartialView(deger);
		}

        //OrderByDescending Id ye göre büyükten küçüğe doğru sıralama işlemini yapmaktadır.
		public PartialViewResult Partial5()
		{
			var deger = c.Blogs.Take(3).OrderByDescending(x=>x.ID).ToList();
			return PartialView(deger);
		}


	}
}