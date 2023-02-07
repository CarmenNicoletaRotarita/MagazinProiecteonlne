using System.ComponentModel.DataAnnotations;

namespace MagazinProiecte.Models
{
    public class OfertaModel
    {
        public Guid IDOferta { get; set; }
        public DateTime DataLansare { get; set; }
        public DateTime DataLichidare { get; set; }
        public string DenumireOferte { get; set; }
        public string Descriere { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataEveniment { get; set; }
        public string? Tags { get; set; }
    }
}
    

