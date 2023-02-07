using MagazinProiecte.Data;
using System.Diagnostics.Metrics;
using MagazinProiecte.Models;
using MagazinProiecte.Models.DBObjects;


namespace MagazinProiecte.Repository
{
    public class OfertaRepository
    {
        private ApplicationDbContext dbContext;

        public OfertaRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public OfertaRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<OfertaModel> GetAllOfertes()
        {
            List<OfertaModel> ofertaList = new List<OfertaModel>();

            foreach (Oferte dbOferta in dbContext.Ofertes)
            {
                ofertaList.Add(MapDbObjectToModel(dbOferta));
            }

            return ofertaList;

        }

        public OfertaModel GetOferteByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Ofertes.FirstOrDefault(x => x.Idoferta == ID));
        }

        public void InsertOferta(OfertaModel ofertaModel)
        {
            ofertaModel.IDOferta = Guid.NewGuid();

            dbContext.Ofertes.Add(MapModelToDbObject(ofertaModel));
            dbContext.SaveChanges();
        }

        public void UpdateOferta(OfertaModel oferteModel)
        {
            Oferte existingOferte = dbContext.Ofertes.FirstOrDefault(x => x.Idoferta == oferteModel.IDOferta);

            if (existingOferte != null)
            {
                existingOferte.Idoferta = oferteModel.IDOferta;
                existingOferte.DataLansare = oferteModel.DataLansare;
                existingOferte.DataLichidare = oferteModel.DataLichidare;
                existingOferte.DenumireOferte = oferteModel.DenumireOferte;
                existingOferte.Descriere = oferteModel.Descriere;
                existingOferte.DataEveniment = oferteModel.DataEveniment;
                existingOferte.Tags = oferteModel.Tags;


                dbContext.SaveChanges();


            }
        }

        public void DeleteOferte(OfertaModel ofertaModel)
        {
            Oferte existingOferte = dbContext.Ofertes.FirstOrDefault(x => x.Idoferta == ofertaModel.IDOferta);

            if (existingOferte != null)
            {
                dbContext.Ofertes.Remove(existingOferte);
                dbContext.SaveChanges();
            }
        }
        private OfertaModel MapDbObjectToModel(Oferte dbOferte)
        {
            OfertaModel ofertaModel = new OfertaModel();

            if (dbOferte != null)
            {

                ofertaModel.IDOferta = dbOferte.Idoferta;
                ofertaModel.DataLansare = dbOferte.DataLansare;
                ofertaModel.DataLichidare = dbOferte.DataLichidare;
                ofertaModel.DenumireOferte = dbOferte.DenumireOferte;
                ofertaModel.Descriere = dbOferte.Descriere;
                ofertaModel.DataEveniment = dbOferte.DataEveniment;
                ofertaModel.Tags = dbOferte.Tags;
            }

            return ofertaModel;
        }

        private Oferte MapModelToDbObject(OfertaModel oferteModel)
        {
            Oferte oferte = new Oferte();

            if (oferteModel != null)
            {
                oferte.Idoferta = oferteModel.IDOferta;
                oferte.DataLansare = oferteModel.DataLansare;
                oferte.DataLichidare = oferteModel.DataLichidare;
                oferte.DenumireOferte = oferteModel.DenumireOferte;
                oferte.Descriere = oferteModel.Descriere;
                oferte.DataEveniment = oferte.DataEveniment;
                oferte.Tags = oferteModel.Tags;

            }

            return oferte;
        }

    }
}

    

    

