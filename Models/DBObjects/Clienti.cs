using System;
using System.Collections.Generic;

namespace MagazinProiecte.Models.DBObjects
{
    public partial class Clienti
    {
        public Guid Idclient { get; set; }
        public string Nume { get; set; } = null!;
        public string Telefon { get; set; } = null!;
        public string Adresa { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Gen { get; set; }
    }
}
