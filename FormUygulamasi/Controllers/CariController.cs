using FormUygulamasi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormUygulamasi.Controllers
{
    public class CariController : Controller
    {
        public IActionResult CariFormu()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Kaydet(Cari cari)
        {
            string dosyaYolu = Path.Combine(
                Directory.GetCurrentDirectory(),
                "cariler.txt");

            string satir = $"{cari.CariAdi};{cari.CariSoyadi};{cari.Telefon};{cari.FirmaAdi};{cari.FirmaVKN};{cari.Kategori};{cari.Il};{cari.Ilce};{cari.Adres}";

            System.IO.File.AppendAllText(dosyaYolu, satir + Environment.NewLine);

            return RedirectToAction("CariFormu");
        }
    }
}