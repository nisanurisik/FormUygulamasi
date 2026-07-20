using FormUygulamasi.Data;
using FormUygulamasi.Models;
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
        public IActionResult Kaydet(Cari cari)
        {
            if (!ModelState.IsValid)
            {
                return View("CariFormu", cari);
            }

            _context.Cariler.Add(cari);
            _context.SaveChanges();

            return RedirectToAction("CariFormu");
        }
        public IActionResult CariListele()
        {
            var cariler = _context.Cariler.ToList();

            return View(cariler);
        }

        public IActionResult CariGuncelle(int id)
        {
            var cari = _context.Cariler.Find(id);

            if (cari == null)
                return NotFound();

            return View(cari);
        }

        [HttpPost]
        public IActionResult CariGuncelle(Cari cari)
        {
            if (!ModelState.IsValid)
            {
                return View(cari);
            }

            _context.Cariler.Update(cari);
            _context.SaveChanges();

            return RedirectToAction("CariListele");
        }
    }
}