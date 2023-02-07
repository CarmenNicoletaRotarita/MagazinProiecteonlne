
using MagazinProiecte.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MagazinProiecte.Models;
using MagazinProiecte.Repository;

namespace MagazinProiecte.Controllers
{
    public class ComandaController : Controller
    {
        private Repository.ComandaRepository _repository;

        public ComandaController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.ComandaRepository(dbContext);
        }

        // GET: ComenziController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ComenziController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ComenziController/Create
        public ActionResult Create()
        {
            return View("CreateComanda");
        }

        // POST: ComenziController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.ComandaModel model = new Models.ComandaModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertComenzi(model);
                }

                return View("CreateComanda");
            }
            catch
            {
                return View("CreateComanda");
            }

            return RedirectToAction(nameof(Index));

        }

        // GET: ComenziController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetComenziByID(id);
            return View("EditComanda", model);
        }

        // POST: ComenziController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new ComandaModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateComenzi(model);
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

        // GET: ComenziController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComenziController/Delete/5
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
