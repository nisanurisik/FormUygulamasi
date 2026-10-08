using System.ComponentModel.DataAnnotations;

namespace FormUygulamasi.Models
{
    public class Ilce
    {
        [Key]
        public int IlceId { get; set; }
        public string IlceAdi { get; set; }
        public int IlId { get; set; }
        public Il Il { get; set; }
    }
}
