using MagazinProiecte.Data;
using System.Diagnostics.Metrics;
using MagazinProiecte.Models;
using MagazinProiecte.Models.DBObjects;

namespace MagazinProiecte.Repository
{
    public class CarteRepository
    {
        private ApplicationDbContext dbContext;

        public CarteRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public CarteRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<CarteModel> GetAllCartis()
        {
            List<CarteModel> cartiList = new List<CarteModel>();

            foreach (Carti dbCarti in dbContext.Cartis)
            {
                cartiList.Add(MapDbObjectToModel(dbCarti));
            }

            return cartiList;

        }

        public CarteModel GetCartisByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Cartis.FirstOrDefault(x => x.Idcarte == ID));
        }

        public void InsertCarti(CarteModel cartiModel)
        {
            cartiModel.IDCarte = Guid.NewGuid();

            dbContext.Cartis.Add(MapModelToDbObject(cartiModel));
            dbContext.SaveChanges();
        }

        public void UpdateCarti(CarteModel cartiModel)
        {
            Carti existingCarti = dbContext.Cartis.FirstOrDefault(x => x.Idcarte == cartiModel.IDCarte);

            if (existingCarti != null)
            {
                existingCarti.Idcarte = cartiModel.IDCarte;
                existingCarti.Titlu = cartiModel.Titlu;
                existingCarti.Descriere = cartiModel.Descriere;
                existingCarti.Pret = cartiModel.Pret;
                existingCarti.DataPublicare = cartiModel.DataPublicare;
                existingCarti.InStoc = cartiModel.InStoc;

                dbContext.SaveChanges();


            }
        }

        public void DeleteCarti(CarteModel cartiModel)
        {
            Carti existingCarti = dbContext.Cartis.FirstOrDefault(x => x.Idcarte == cartiModel.IDCarte);

            if (existingCarti != null)
            {
                dbContext.Cartis.Remove(existingCarti);
                dbContext.SaveChanges();
            }
        }
        private CarteModel MapDbObjectToModel(Carti dbCarti)
        {
            CarteModel cartiModel = new CarteModel();

            if (dbCarti != null)
            {
                cartiModel.IDCarte = dbCarti.Idcarte;
                cartiModel.Titlu = dbCarti.Titlu;
                cartiModel.Descriere = dbCarti.Descriere;
                cartiModel.Pret = dbCarti.Pret;
                cartiModel.DataPublicare = dbCarti.DataPublicare;
                cartiModel.InStoc = dbCarti.InStoc;
            }

            return cartiModel;
        }

        private Carti MapModelToDbObject(CarteModel cartiModel)
        {
            Carti carti = new Carti();

            if (cartiModel != null)
            {
                carti.Idcarte = cartiModel.IDCarte;
                carti.Titlu = cartiModel.Titlu;
                carti.Descriere = cartiModel.Descriere;
                carti.Pret = cartiModel.Pret;
                carti.DataPublicare = cartiModel.DataPublicare;
                carti.InStoc = cartiModel.InStoc;
            }

            return carti;
        }

        internal object GetCartisByID(int id)
        {
            throw new NotImplementedException();
        }

        internal void DeleteCarti(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
    

