using System.ComponentModel.DataAnnotations;


namespace MagazinProiecte.Models
{
    public class ComandaModel
    {
        public Guid IDComanda { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataPlasare { get; set; }
        public DateTime Dataplasare { get; internal set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataLivrare { get; set; }
        public DateTime? Datalivrare { get; internal set; }
        public int Cantitate { get; set; }

    }
}
    

