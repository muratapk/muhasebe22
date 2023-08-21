using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace muhasebe22.Models
{
    public class ogretmen
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Öğretmenin Adı Soyadı")]
        public string? adsoyad { get; set; }
        public int? tcno { get; set; }
        public string? sinif { get; set; }
        [ForeignKey("okul")]
        public int okulId { get; set; }
        public  okul? okul { get; set; }
        public string? Iban { get; set; }
        public string? unvan { get; set; }
    }
}
