
using MagazinProiecte.Data;
using MagazinProiecte.Models;
using MagazinProiecte.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagazinProiecte.Controllers
{
    public class OfertaController : Controller
    {
        private Repository.OfertaRepository _repository;

        public OfertaController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.OfertaRepository(dbContext);
        }

        // GET: OferteController
        public ActionResult Index()
        {
            var model = _repository.GetAllOfertes();
            return View("Index", model);

        }

        // GET: OferteController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetOferteByID(id);
            return View("OferteDetails", model);


        }

        // GET: OferteController/Create
        public ActionResult Create()
        {
            return View("CreateOferte");
        }

        // POST: OferteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                OfertaModel model = new OfertaModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertOferta(model);
                }
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View("CreateOferte");
            }

            

        }

        // GET: OferteController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetOferteByID(id);
            return View("EditOferta", model);
        }

        // POST: OferteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new OfertaModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateOferta(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", id);
                }
            }
            catch
            {
                return View("Index", id);
            }
        }

        // GET: OferteController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetOferteByID(id);
            return View("DeleteOferte", model);

        }

        // POST: OferteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                var model = _repository.GetOferteByID(id);

                _repository.DeleteOferte(model);
                return RedirectToAction("Index");

            }
            catch
            {
                return View("DeleteOferte");
            }
        }
    }
}


