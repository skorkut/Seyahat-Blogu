using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeyahatSitesi.Models.Siniflar;

namespace SeyahatSitesi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }

        //Sayfa yüklendiğinde hiçbişey yapma sadece sayfanın boş halini getiren metot
        [HttpGet]
        public ActionResult YeniBlog()
        {
           return View();
        }

        //sayfadan bişey gönderildiğinde içerideki viewi döndürür.
        [HttpPost]
		public ActionResult YeniBlog(Blog p)
		{
            //contextden türettiğimiz c nesnesine blogların içerisine parametreden gelen değerleri eklemeye yarayan kod
            c.Blogs.Add(p);
            c.SaveChanges();
            //kayıt işleminden sonra indexe yönlendirir.
            return RedirectToAction("Index");
		}

        public ActionResult BlogSil(int id)
        {
            // b değişkeni oluşturup içine bloglardaki id den gelen değerleri atarız.
            var b = c.Blogs.Find(id);
            //oluşturduğumuz b değişkenini remove yardımıyla komple sileriz.
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            //bloglar içinde id ye göre bulup bl değişkenine atadık
            var bl = c.Blogs.Find(id);
            return View("BlogGetir", bl);

        }
        public ActionResult BlogGuncelle(Blog b)
        {
            //b den gönderdiğimiz ID ye göre ilgili bloğu bul
            var blg = c.Blogs.Find(b.ID);
            //burda b den gelen açıklamayı blg değişkenindeki açıklamaya atamaktayız
            blg.Aciklama=b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage= b.BlogImage;
            blg.Tarih=b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }


        public ActionResult YorumSil(int id)
        {
          
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }

        public ActionResult YorumGuncelle(Yorumlar y)
        {
           
            var yrm = c.Yorumlars.Find(y.ID);
            
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }


    }
}