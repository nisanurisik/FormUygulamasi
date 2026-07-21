using FormUygulamasi.Data;
using FormUygulamasi.Models;
using FormUygulamasi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FormUygulamasi.Controllers
{
    public class CariController : Controller
    {
        private readonly AppDbContext _context;

        public CariController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CariFormu()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Kaydet(CariViewModel cari)
        {
            if (!ModelState.IsValid)
            {
                return View("CariFormu", cari);
            }

            var yeniCari = new Cari
            {
                CariAdi = cari.CariAdi,
                CariSoyadi = cari.CariSoyadi,
                Telefon = cari.Telefon,
                FirmaAdi = cari.FirmaAdi,
                FirmaVKN = cari.FirmaVKN,
                Kategori = cari.Kategori,
                Il = cari.Il,
                Ilce = cari.Ilce,
                Adres = cari.Adres
            };

            _context.Cariler.Add(yeniCari);
            _context.SaveChanges();

            return RedirectToAction("CariFormu");
        }

        public IActionResult CariListele()
        {
            var cariler = _context.Cariler
                .Select(x => new CariViewModel
                {
                    Id = x.Id,
                    CariAdi = x.CariAdi,
                    CariSoyadi = x.CariSoyadi,
                    Telefon = x.Telefon,
                    FirmaAdi = x.FirmaAdi,
                    FirmaVKN = x.FirmaVKN,
                    Kategori = x.Kategori,
                    Il = x.Il,
                    Ilce = x.Ilce,
                    Adres = x.Adres
                })
                .ToList();

            return View(cariler);
        }

        public IActionResult CariGuncelle(int id)
        {
            var cari = _context.Cariler.Find(id);

            if (cari == null)
                return NotFound();

            var model = new CariViewModel
            {
                Id = cari.Id,
                CariAdi = cari.CariAdi,
                CariSoyadi = cari.CariSoyadi,
                Telefon = cari.Telefon,
                FirmaAdi = cari.FirmaAdi,
                FirmaVKN = cari.FirmaVKN,
                Kategori = cari.Kategori,
                Il = cari.Il,
                Ilce = cari.Ilce,
                Adres = cari.Adres
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult CariGuncelle(CariViewModel cari)
        {
            if (!ModelState.IsValid)
            {
                return View(cari);
            }

            var guncellenecekCari = _context.Cariler.Find(cari.Id);

            if (guncellenecekCari == null)
                return NotFound();

            guncellenecekCari.CariAdi = cari.CariAdi;
            guncellenecekCari.CariSoyadi = cari.CariSoyadi;
            guncellenecekCari.Telefon = cari.Telefon;
            guncellenecekCari.FirmaAdi = cari.FirmaAdi;
            guncellenecekCari.FirmaVKN = cari.FirmaVKN;
            guncellenecekCari.Kategori = cari.Kategori;
            guncellenecekCari.Il = cari.Il;
            guncellenecekCari.Ilce = cari.Ilce;
            guncellenecekCari.Adres = cari.Adres;

            _context.SaveChanges();

            return RedirectToAction("CariListele");
        }
    }
}