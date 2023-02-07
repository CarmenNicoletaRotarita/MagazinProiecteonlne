using MagazinProiecte.Data;
using System.Diagnostics.Metrics;
using MagazinProiecte.Models;
using MagazinProiecte.Models.DBObjects;

namespace MagazinProiecte.Repository
{
    public class EdituriRepository
    {
        private ApplicationDbContext dbContext;


        public EdituriRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public EdituriRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<EdituriModel> GetAllEdituras()
        {
            List<EdituriModel> edituriList = new List<EdituriModel>();

            foreach (Editura dbEditura in dbContext.Edituras)
            {
                edituriList.Add(MapDbObjectToModel(dbEditura));
            }

            return edituriList;

        }

        public EdituriModel GetEdituraByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Edituras.FirstOrDefault(x => x.Ideditura == ID));
        }

        public void InsertEditura(EdituriModel edituraModel)
        {
            edituraModel.IDEditura = Guid.NewGuid();

            dbContext.Edituras.Add(MapModelToDbObject(edituraModel));
            dbContext.SaveChanges();
        }

        public void UpdateEditura(EdituriModel edituraModel)
        {
            Editura existingEditura = dbContext.Edituras.FirstOrDefault(x => x.Ideditura == edituraModel.IDEditura);

            if (existingEditura != null)
            {
                existingEditura.Ideditura = edituraModel.IDEditura;
                existingEditura.NumeEditura = edituraModel.NumeEditura;
                existingEditura.Email = edituraModel.Email;
                existingEditura.Telefon = edituraModel.Telefon;





                dbContext.SaveChanges();


            }
        }

        public void DeleteEditura(EdituriModel edituriModel)
        {
            Editura existingEditura = dbContext.Edituras.FirstOrDefault(x => x.Ideditura == edituriModel.IDEditura);

            if (existingEditura != null)
            {
                dbContext.Edituras.Remove(existingEditura);
                dbContext.SaveChanges();
            }
        }
        private EdituriModel MapDbObjectToModel(Editura dbEditura)
        {
            EdituriModel edituriModel = new EdituriModel();

            if (dbEditura != null)
            {
                edituriModel.IDEditura = dbEditura.Ideditura;
                edituriModel.NumeEditura = dbEditura.NumeEditura;
                edituriModel.Email = dbEditura.Email;
                edituriModel.Telefon = dbEditura.Telefon;

            }

            return edituriModel;
        }

        private Editura MapModelToDbObject(EdituriModel edituriModel)
        {
            Editura edituri = new Editura();

            if (edituriModel != null)
            {
                edituri.Ideditura = edituriModel.IDEditura;
                edituri.NumeEditura = edituriModel.NumeEditura;
                edituri.Email = edituriModel.Email;
                edituri.Telefon = edituriModel.Telefon;

            }

            return edituri;
        }

    }

}
    

