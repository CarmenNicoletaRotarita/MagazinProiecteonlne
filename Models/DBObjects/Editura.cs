using System;
using System.Collections.Generic;

namespace MagazinProiecte.Models.DBObjects
{
    public partial class Editura
    {
        public Guid Ideditura { get; set; }
        public string NumeEditura { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Telefon { get; set; }
    }
}
