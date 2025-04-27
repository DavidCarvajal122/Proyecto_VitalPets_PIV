using Microsoft.AspNetCore.Mvc;
using Proyecto_VitalPets_PIV.Data;
using Proyecto_VitalPets_PIV.Models;
using System.Linq;

namespace Proyecto_VitalPets_PIV.Controllers
{
    public class CitaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var citas = _context.Citas.ToList();
            return View(citas);
        }

        public ActionResult Details(int id)
        {
            var cita = _context.Citas.FirstOrDefault(c => c.Id == id);
            if (cita == null)
                return NotFound();

            return View(cita);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Citas.Add(cita);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cita);
        }

        public ActionResult Edit(int id)
        {
            var cita = _context.Citas.Find(id);
            if (cita == null)
                return NotFound();

            return View(cita);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cita cita)
        {
            if (id != cita.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Citas.Update(cita);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cita);
        }

        public ActionResult Delete(int id)
        {
            var cita = _context.Citas.Find(id);
            if (cita == null)
                return NotFound();

            return View(cita);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cita = _context.Citas.Find(id);
            if (cita != null)
            {
                _context.Citas.Remove(cita);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

