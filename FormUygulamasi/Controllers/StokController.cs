using FormUygulamasi.Data;
using FormUygulamasi.Models;
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
        public IActionResult Kaydet(Stok stok)
        {
            if (!ModelState.IsValid)
            {
                return View("StokFormu", stok);
            }

            _context.Stoklar.Add(stok);
            _context.SaveChanges();

            return RedirectToAction("StokFormu");
        }

        [HttpGet]
        public IActionResult StokListele()
        {
            var stoklar = _context.Stoklar.ToList();

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

            return View(stok);
        }

        [HttpPost]
        public IActionResult StokGuncelle(Stok stok)
        {
            if (!ModelState.IsValid)
            {
                return View(stok);
            }

            _context.Stoklar.Update(stok);
            _context.SaveChanges();

            return RedirectToAction("StokListele");
        }
    }
}