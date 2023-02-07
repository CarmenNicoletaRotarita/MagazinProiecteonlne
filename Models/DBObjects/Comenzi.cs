using System;
using System.Collections.Generic;

namespace MagazinProiecte.Models.DBObjects
{
    public partial class Comenzi
    {
        public Guid Idcomanda { get; set; }
        public DateTime? DataPlasare { get; set; }
        public DateTime? DataLivrare { get; set; }
        public int Cantitate { get; set; }
    }
}
