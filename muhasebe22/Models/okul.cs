using System.ComponentModel.DataAnnotations;
using muhasebe22.Models;
namespace muhasebe22.Models
{
    public class okul
    {
        [Key]
        public int Id { get; set; }
        public  int? okulKodu  { get; set; }
        public  string? adi { get; set; }
        public  int?  vergino { get; set; }

        public ICollection<Ogrenci>Ogrencis { get; set; }
        public ICollection<ogretmen> ogretmens { get; set; }
        public ICollection<idare> idares { get; set; }
    }
}
