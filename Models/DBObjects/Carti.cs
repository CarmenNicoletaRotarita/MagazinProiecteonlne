using System;
using System.Collections.Generic;

namespace MagazinProiecte.Models.DBObjects
{
    public partial class Carti
    {
        public Guid Idcarte { get; set; }
        public string Titlu { get; set; } = null!;
        public string Descriere { get; set; } = null!;
        public int Pret { get; set; }
        public DateTime DataPublicare { get; set; }
        public bool InStoc { get; set; }
    }
}
