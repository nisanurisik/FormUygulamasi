using FormUygulamasi.Data;
using FormUygulamasi.Models;
using FormUygulamasi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FormUygulamasi.Controllers
{
    public class StokController : Controller
    {
        private readonly AppDbContext _context;

        public StokController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult StokFormu()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Kaydet(StokViewModel stok)
        {
            if (!ModelState.IsValid)
            {
                return View("StokFormu", stok);
            }

            var yeniStok = new Stok
            {
                StokKodu = stok.StokKodu,
                StokAdi = stok.StokAdi,
                Barkod = stok.Barkod,
                BirimAdi = stok.BirimAdi,
                Adet = stok.Adet,
                AlisFiyati = stok.AlisFiyati,
                SatisFiyati = stok.SatisFiyati,
                KdvOrani = stok.KdvOrani
            };

            _context.Stoklar.Add(yeniStok);
            _context.SaveChanges();

            return RedirectToAction("StokFormu");
        }

        [HttpGet]
        public IActionResult StokListele()
        {
            var stoklar = _context.Stoklar
                .Select(x => new StokViewModel
                {
                    StokKodu = x.StokKodu,
                    StokAdi = x.StokAdi,
                    Barkod = x.Barkod,
                    BirimAdi = x.BirimAdi,
                    Adet = x.Adet,
                    AlisFiyati = x.AlisFiyati,
                    SatisFiyati = x.SatisFiyati,
                    KdvOrani = x.KdvOrani
                })
                .ToList();

            return View(stoklar);
        }

        [HttpGet]
        public IActionResult StokGuncelle(int id)
        {
            var stok = _context.Stoklar.FirstOrDefault(x => x.StokKodu == id);

            if (stok == null)
            {
                return NotFound();
            }

            var model = new StokViewModel
            {
                StokKodu = stok.StokKodu,
                StokAdi = stok.StokAdi,
                Barkod = stok.Barkod,
                BirimAdi = stok.BirimAdi,
                Adet = stok.Adet,
                AlisFiyati = stok.AlisFiyati,
                SatisFiyati = stok.SatisFiyati,
                KdvOrani = stok.KdvOrani
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult StokGuncelle(StokViewModel stok)
        {
            if (!ModelState.IsValid)
            {
                return View(stok);
            }

            var guncellenecekStok = _context.Stoklar
                .FirstOrDefault(x => x.StokKodu == stok.StokKodu);

            if (guncellenecekStok == null)
            {
                return NotFound();
            }

            guncellenecekStok.StokAdi = stok.StokAdi;
            guncellenecekStok.Barkod = stok.Barkod;
            guncellenecekStok.BirimAdi = stok.BirimAdi;
            guncellenecekStok.Adet = stok.Adet;
            guncellenecekStok.AlisFiyati = stok.AlisFiyati;
            guncellenecekStok.SatisFiyati = stok.SatisFiyati;
            guncellenecekStok.KdvOrani = stok.KdvOrani;

            _context.SaveChanges();

            return RedirectToAction("StokListele");
        }
    }
}