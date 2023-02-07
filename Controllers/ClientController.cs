using MagazinProiecte.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MagazinProiecte.Models;
using MagazinProiecte.Repository;


namespace MagazinProiecte.Controllers
{
    public class ClientController : Controller
    {
        private Repository.ClientRepository _repository;

        public ClientController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.ClientRepository(dbContext);
        }

        // GET: ClientiController
        public ActionResult Index()
        {
            var model = _repository.GetAllClientis();
            return View("Index", model);

        }

        // GET: ClientiController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetClientisByID(id);
            return View("ClientiDetails", model);

        }

        // GET: ClientiController/Create
        public ActionResult Create()
        {
            return View("CreateClient");
        }

        // POST: ClientiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {

                Models.ClientModel model = new Models.ClientModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertClienti(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateClient");
            }

      

        }

        // GET: ClientiController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetClientisByID(id);
            return View("EditClient", model);
        }

        // POST: ClientiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new ClientModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateClienti(model);
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

        // GET: ClientiController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetClientisByID(id);
            return View("DeleteClient", model);

        }

        // POST: ClientiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                var model = _repository.GetClientisByID(id);

                _repository.DeleteClienti(model);
                return RedirectToAction("Index");

            }
            catch
            {
                return View("DeleteClient");
            }
        }
    }
}

