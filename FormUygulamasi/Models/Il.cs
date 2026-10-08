using System.ComponentModel.DataAnnotations;

namespace FormUygulamasi.Models
{
    public class Il
    {
        [Key]
        public int IlId { get; set; }
        public string IlAdi { get; set; }
        public List<Ilce> Ilceler { get; set; } = new();
    }
}
