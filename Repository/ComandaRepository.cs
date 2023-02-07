using MagazinProiecte.Data;
using System.Diagnostics.Metrics;
using MagazinProiecte.Models;
using MagazinProiecte.Models.DBObjects;

namespace MagazinProiecte.Repository
{
    public class ComandaRepository
    {
        private ApplicationDbContext dbContext;

        public ComandaRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public ComandaRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ComandaModel> GetAllComenzis()
        {
            List<ComandaModel> comenziList = new List<ComandaModel>();

            foreach (Comenzi dbComenzi in dbContext.Comenzis)
            {
                comenziList.Add(MapDbObjectToModel(dbComenzi));
            }

            return comenziList;

        }

        public ComandaModel GetComenziByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Comenzis.FirstOrDefault(x => x.Idcomanda == ID));
        }

        public void InsertComenzi(ComandaModel comenziModel)
        {
            comenziModel.IDComanda = Guid.NewGuid();

            dbContext.Comenzis.Add(MapModelToDbObject(comenziModel));
            dbContext.SaveChanges();
        }

        public void UpdateComenzi(ComandaModel comenziModel)
        {
            Comenzi existingComenzi = dbContext.Comenzis.FirstOrDefault(x => x.Idcomanda == comenziModel.IDComanda);

            if (existingComenzi != null)
            {
                existingComenzi.Idcomanda = comenziModel.IDComanda;
                existingComenzi.DataPlasare = comenziModel.DataPlasare;
                existingComenzi.DataLivrare = comenziModel.DataLivrare;
                existingComenzi.Cantitate = comenziModel.Cantitate;

                dbContext.SaveChanges();


            }
        }

        public void DeleteComenzi(ComandaModel comenziModel)
        {
            Comenzi existingComenzi = dbContext.Comenzis.FirstOrDefault(x => x.Idcomanda == comenziModel.IDComanda);

            if (existingComenzi != null)
            {
                dbContext.Comenzis.Remove(existingComenzi);
                dbContext.SaveChanges();
            }
        }
        private ComandaModel MapDbObjectToModel(Comenzi dbComenzi)
        {
            ComandaModel comenziModel = new ComandaModel();

            if (dbComenzi != null)
            {
                comenziModel.IDComanda = dbComenzi.Idcomanda;
                comenziModel.DataPlasare = (DateTime)dbComenzi.DataPlasare;
                comenziModel.Datalivrare = dbComenzi.DataLivrare;
                comenziModel.Cantitate = dbComenzi.Cantitate;

            }

            return comenziModel;
        }

        private Comenzi MapModelToDbObject(ComandaModel comenziModel)
        {
            Comenzi comenzi = new Comenzi();

            if (comenziModel != null)
            {
                comenzi.Idcomanda = comenziModel.IDComanda;
                comenzi.DataPlasare = comenziModel.DataPlasare;
                comenzi.DataLivrare = comenziModel.DataLivrare;
                comenzi.Cantitate = comenziModel.Cantitate;

            }

            return comenzi;
        }

    }
}

    


    

