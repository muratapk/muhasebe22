using Microsoft.AspNetCore.Mvc;
using muhasebe22.Data;
using muhasebe22.Models;

namespace muhasebe22.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        //database context nesnesi global her her ulaşmam için
        //tanımlama yapıyorum.
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
            //bu metodların her yerinde erişebilmem için ayarlama yaptım
        }
        //otomatik bu kontrol çalış çalışma admin controller çalıştır
        public IActionResult Index()
        {
            var liste=_context.admins.ToList();
            //admin içindeki tüm verileri nereye listeye ata
            return View(liste);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Admin tablo)
        {
            
            _context.admins.Add(tablo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
           var bul = _context.admins.Find(Id);
             _context.admins.Remove(bul);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            var bul = _context.admins.Find(Id);
            return View(bul);
        }
        [HttpPost]
        public IActionResult Edit(Admin gelen)
        {
            var tablom = _context.admins.Find(gelen.Id);
            tablom.kul = gelen.kul;
            tablom.sifre = gelen.sifre;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
