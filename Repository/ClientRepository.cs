using MagazinProiecte.Data;
using System.Diagnostics.Metrics;
using MagazinProiecte.Models;
using MagazinProiecte.Models.DBObjects;

namespace MagazinProiecte.Repository
{
    public class ClientRepository
    {
        private ApplicationDbContext dbContext;


        public ClientRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public ClientRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ClientModel> GetAllClientis()
        {
            List<ClientModel> clientiList = new List<ClientModel>();

            foreach (Clienti dbClienti in dbContext.Clientis)
            {
                clientiList.Add(MapDbObjectToModel(dbClienti));
            }

            return clientiList;

        }

        public ClientModel GetClientisByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Clientis.FirstOrDefault(x => x.Idclient == ID));
        }

        public void InsertClienti(ClientModel clientiModel)
        {
            clientiModel.IDClient = Guid.NewGuid();

            dbContext.Clientis.Add(MapModelToDbObject(clientiModel));
            dbContext.SaveChanges();
        }

        public void UpdateClienti(ClientModel clientiModel)
        {
            Clienti existingClienti = dbContext.Clientis.FirstOrDefault(x => x.Idclient == clientiModel.IDClient);

            if (existingClienti != null)
            {
                existingClienti.Idclient = clientiModel.IDClient;
                existingClienti.Nume = clientiModel.Nume;
                existingClienti.Telefon = clientiModel.Telefon;
                existingClienti.Adresa = clientiModel.Adresa;
                existingClienti.Email = clientiModel.Email;
                existingClienti.Gen = clientiModel.Gen;

                dbContext.SaveChanges();


            }
        }

        public void DeleteClienti(ClientModel clientiModel)
        {
            Clienti existingClienti = dbContext.Clientis.FirstOrDefault(x => x.Idclient == clientiModel.IDClient);

            if (existingClienti != null)
            {
                dbContext.Clientis.Remove(existingClienti);
                dbContext.SaveChanges();
            }
        }
        private ClientModel MapDbObjectToModel(Clienti dbClienti)
        {
            ClientModel clientiModel = new ClientModel();

            if (dbClienti != null)
            {
                clientiModel.IDClient = dbClienti.Idclient;
                clientiModel.Nume = dbClienti.Nume;
                clientiModel.Telefon = dbClienti.Telefon;
                clientiModel.Adresa = dbClienti.Adresa;
                clientiModel.Email = dbClienti.Email;
                clientiModel.Gen = dbClienti.Gen;

            }

            return clientiModel;
        }

        private Clienti MapModelToDbObject(ClientModel clientiModel)
        {
            Clienti clienti = new Clienti();

            if (clientiModel != null)
            {
                clienti.Idclient = clientiModel.IDClient;
                clienti.Nume = clientiModel.Nume;
                clienti.Telefon = clientiModel.Telefon;
                clienti.Adresa = clientiModel.Adresa;
                clienti.Email = clientiModel.Email;
                clienti.Gen = clientiModel.Gen;

            }

            return clienti;
        }

    }
}

    

    

