using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_VitalPets_PIV.Controllers
{
    public class MascotaController : Controller
    {
        // GET: MascotaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MascotaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MascotaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MascotaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MascotaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MascotaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MascotaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MascotaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
