using System.ComponentModel.DataAnnotations;

namespace muhasebe22.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public  string? kul { get; set; }
        public  string? sifre { get; set; }
    }
}
