using System.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace MagazinProiecte.Models
{
    public class CarteModel
        {
            public Guid IDCarte { get; set; }

            public string Titlu { get; set; }
            public string Descriere { get; set; }
            public int Pret { get; set; }

            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
            [DataType(DataType.Date)]
            public DateTime DataPublicare { get; set; }
            public bool InStoc { get; set; }


        }
    }

