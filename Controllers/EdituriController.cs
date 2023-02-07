
using MagazinProiecte.Data;
using MagazinProiecte.Models;
using MagazinProiecte.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagazinProiecte.Controllers
{
    public class EdituriController : Controller
    {
        private Repository.EdituriRepository _repository;

        public EdituriController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.EdituriRepository(dbContext);
        }

        // GET: EdituraController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EditurController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EdituraController/Create
        public ActionResult Create()
        {
            return View("CreateEdituri");
        }

        // POST: EdituraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.EdituriModel model = new Models.EdituriModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertEditura(model);
                }

                return View("CreateEdituri");
            }
            catch
            {
                return View("CreateEdituri");
            }

            return RedirectToAction(nameof(Index));

        }

        // GET: EdituraController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetEdituraByID(id);
            return View("EditEdituri", model);
        }

        // POST: EdituraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new EdituriModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateEditura(model);
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

        // GET: EdituraController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EdituraController/Delete/5
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
