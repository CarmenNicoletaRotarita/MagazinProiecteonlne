using MagazinProiecte.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MagazinProiecte.Models;
using MagazinProiecte.Repository;

namespace MagazinProiecte.Controllers
{
    public class CarteController : Controller
    {
        private Repository.CarteRepository _repository;

        public CarteController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.CarteRepository(dbContext);
        }

        // GET: CartiController

        public ActionResult Index()
        {
            var agenties = _repository.GetAllCartis();
            return View("Index", agenties);

        }

        // GET: CartiController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetCartisByID(id);
            return View("CartiDetails", model);

        }

        // GET: CartiController/Create
        public ActionResult Create()
        {
            return View("CreateCarte");
        }

        // POST: CartiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.CarteModel model = new CarteModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertCarti(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateCarte");
            }

           

        }

        // GET: CartiController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetCartisByID(id);
            return View("EditCarti", model);
        }

        // POST: CartiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new CarteModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateCarti(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", id);
                }
            }
            catch
            {
                return RedirectToAction("Index", id);
            }
        }

        // GET: CartiController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetCartisByID(id);
            return View("DeleteCarte", model);
        }

        // POST: CartiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                var model = _repository.GetCartisByID(id);
                _repository.DeleteCarti(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteCarte");
            }
        }
    }
}
