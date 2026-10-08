using FormUygulamasi.Data;
using FormUygulamasi.Models;
using FormUygulamasi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> CariFormu()
        {
            var iller = await _context.Iller.ToListAsync();

            ViewData["iller"] = iller;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Kaydet(CariViewModel cari)
        {
            if (!ModelState.IsValid)
            {
                var iller = await _context.Iller.ToListAsync();

                ViewData["iller"] = iller;

                if (cari.IlId.HasValue)
                {
                    var ilceler = await _context.Ilceler
                        .Where(x => x.IlId == cari.IlId.Value)
                        .ToListAsync();

                    ViewData["ilceler"] = ilceler;
                }

                return View("CariFormu", cari);
            }

            var il = await _context.Iller
                .FirstOrDefaultAsync(x => x.IlId == cari.IlId);

            var ilce = await _context.Ilceler
                .FirstOrDefaultAsync(x =>
                    x.IlceId == cari.IlceId &&
                    x.IlId == cari.IlId);

            if (il == null || ilce == null)
            {
                return BadRequest();
            }

            var yeniCari = new Cari
            {
                CariAdi = cari.CariAdi,
                CariSoyadi = cari.CariSoyadi,
                Telefon = cari.Telefon,
                FirmaAdi = cari.FirmaAdi,
                FirmaVKN = cari.FirmaVKN,
                Kategori = cari.Kategori,

                Il = il.IlAdi,
                Ilce = ilce.IlceAdi,

                Adres = cari.Adres
            };

            _context.Cariler.Add(yeniCari);

            await _context.SaveChangesAsync();

            return RedirectToAction("CariFormu");
        }

        public async Task<IActionResult> CariListele()
        {
            var cariler = await _context.Cariler
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
                .ToListAsync();

            return View(cariler);
        }

        public async Task<IActionResult> CariGuncelle(int id)
        {
            var cari = await _context.Cariler.FindAsync(id);

            if (cari == null)
            {
                return NotFound();
            }

            var il = await _context.Iller
                .FirstOrDefaultAsync(x => x.IlAdi == cari.Il);

            Ilce? ilce = null;

            if (il != null)
            {
                ilce = await _context.Ilceler
                    .FirstOrDefaultAsync(x =>
                        x.IlceAdi == cari.Ilce &&
                        x.IlId == il.IlId);
            }

            var iller = await _context.Iller.ToListAsync();

            ViewData["iller"] = iller;

            if (il != null)
            {
                var ilceler = await _context.Ilceler
                    .Where(x => x.IlId == il.IlId)
                    .ToListAsync();

                ViewData["ilceler"] = ilceler;
            }

            var model = new CariViewModel
            {
                Id = cari.Id,
                CariAdi = cari.CariAdi,
                CariSoyadi = cari.CariSoyadi,
                Telefon = cari.Telefon,
                FirmaAdi = cari.FirmaAdi,
                FirmaVKN = cari.FirmaVKN,
                Kategori = cari.Kategori,

                IlId = il?.IlId,
                IlceId = ilce?.IlceId,

                Il = cari.Il,
                Ilce = cari.Ilce,

                Adres = cari.Adres
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CariGuncelle(CariViewModel cari)
        {
            if (!ModelState.IsValid)
            {
                var iller = await _context.Iller.ToListAsync();

                ViewData["iller"] = iller;

                if (cari.IlId.HasValue)
                {
                    var ilceler = await _context.Ilceler
                        .Where(x => x.IlId == cari.IlId.Value)
                        .ToListAsync();

                    ViewData["ilceler"] = ilceler;
                }

                return View(cari);
            }

            var guncellenecekCari =
                await _context.Cariler.FindAsync(cari.Id);

            if (guncellenecekCari == null)
            {
                return NotFound();
            }

            var il = await _context.Iller
                .FirstOrDefaultAsync(x => x.IlId == cari.IlId);

            var ilce = await _context.Ilceler
                .FirstOrDefaultAsync(x =>
                    x.IlceId == cari.IlceId &&
                    x.IlId == cari.IlId);

            if (il == null || ilce == null)
            {
                return BadRequest();
            }

            guncellenecekCari.CariAdi = cari.CariAdi;
            guncellenecekCari.CariSoyadi = cari.CariSoyadi;
            guncellenecekCari.Telefon = cari.Telefon;
            guncellenecekCari.FirmaAdi = cari.FirmaAdi;
            guncellenecekCari.FirmaVKN = cari.FirmaVKN;
            guncellenecekCari.Kategori = cari.Kategori;

            guncellenecekCari.Il = il.IlAdi;
            guncellenecekCari.Ilce = ilce.IlceAdi;

            guncellenecekCari.Adres = cari.Adres;

            await _context.SaveChangesAsync();

            return RedirectToAction("CariListele");
        }

        [HttpGet]
        public async Task<IActionResult> IlceleriGetir(int ilId)
        {
            var ilceler = await _context.Ilceler
                .Where(x => x.IlId == ilId)
                .Select(x => new
                {
                    ilceId = x.IlceId,
                    ilceAdi = x.IlceAdi
                })
                .ToListAsync();

            return Json(ilceler);
        }
    }
}