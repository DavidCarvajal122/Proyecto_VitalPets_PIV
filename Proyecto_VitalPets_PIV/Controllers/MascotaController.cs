using Microsoft.AspNetCore.Mvc;
using Proyecto_VitalPets_PIV.Models; // <-- Para usar tus clases
using Proyecto_VitalPets_PIV.Data;   // <-- Para usar ApplicationDbContext
using System.Linq;                   // <-- Para consultar con LINQ

namespace Proyecto_VitalPets_PIV.Controllers
{
    public class MascotaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MascotaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mascota
        public ActionResult Index()
        {
            var mascotas = _context.Mascotas.ToList();
            return View(mascotas);
        }

        // GET: Mascota/Details/5
        public ActionResult Details(int id)
        {
            var mascota = _context.Mascotas.FirstOrDefault(m => m.Id == id);
            if (mascota == null)
                return NotFound();

            return View(mascota);
        }

        // GET: Mascota/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mascota/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                _context.Mascotas.Add(mascota);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(mascota);
        }

        // GET: Mascota/Edit/5
        public ActionResult Edit(int id)
        {
            var mascota = _context.Mascotas.Find(id);
            if (mascota == null)
                return NotFound();

            return View(mascota);
        }

        // POST: Mascota/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Mascota mascota)
        {
            if (id != mascota.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Mascotas.Update(mascota);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(mascota);
        }

        // GET: Mascota/Delete/5
        public ActionResult Delete(int id)
        {
            var mascota = _context.Mascotas.Find(id);
            if (mascota == null)
                return NotFound();

            return View(mascota);
        }

        // POST: Mascota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var mascota = _context.Mascotas.Find(id);
            if (mascota != null)
            {
                _context.Mascotas.Remove(mascota);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
