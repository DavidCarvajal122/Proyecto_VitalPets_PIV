using Microsoft.AspNetCore.Mvc;
using Proyecto_VitalPets_PIV.Data;
using Proyecto_VitalPets_PIV.Models;
using System.Linq;

namespace Proyecto_VitalPets_PIV.Controllers
{
    public class VeterinarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VeterinarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var veterinarios = _context.Veterinarios.ToList();
            return View(veterinarios);
        }

        public ActionResult Details(int id)
        {
            var veterinario = _context.Veterinarios.FirstOrDefault(v => v.Id == id);
            if (veterinario == null)
                return NotFound();

            return View(veterinario);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Veterinario veterinario)
        {
            if (ModelState.IsValid)
            {
                _context.Veterinarios.Add(veterinario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(veterinario);
        }

        public ActionResult Edit(int id)
        {
            var veterinario = _context.Veterinarios.Find(id);
            if (veterinario == null)
                return NotFound();

            return View(veterinario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Veterinario veterinario)
        {
            if (id != veterinario.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Veterinarios.Update(veterinario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(veterinario);
        }

        public ActionResult Delete(int id)
        {
            var veterinario = _context.Veterinarios.Find(id);
            if (veterinario == null)
                return NotFound();

            return View(veterinario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var veterinario = _context.Veterinarios.Find(id);
            if (veterinario != null)
            {
                _context.Veterinarios.Remove(veterinario);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
