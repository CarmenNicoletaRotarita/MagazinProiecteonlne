using System;
using System.Collections.Generic;

namespace MagazinProiecte.Models.DBObjects
{
    public partial class Oferte
    {
        public Guid Idoferta { get; set; }
        public DateTime DataLansare { get; set; }
        public DateTime DataLichidare { get; set; }
        public string DenumireOferte { get; set; } = null!;
        public string Descriere { get; set; } = null!;
        public DateTime DataEveniment { get; set; }
        public string? Tags { get; set; }
    }
}
