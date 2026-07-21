using System.ComponentModel.DataAnnotations;

namespace FormUygulamasi.Models
{
    public class Stok
    {
        [Key]
        public int StokKodu { get; set; }

        public string StokAdi { get; set; }

        public string Barkod { get; set; }

        public string BirimAdi { get; set; }

        public int Adet { get; set; }

        public decimal AlisFiyati { get; set; }

        public decimal SatisFiyati { get; set; }

        public int KdvOrani { get; set; }
    }
}