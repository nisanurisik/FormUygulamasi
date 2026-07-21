using System.ComponentModel.DataAnnotations;

namespace FormUygulamasi.Models
{
    public class Cari
    {
        [Key]
        public int Id { get; set; }

        public string CariAdi { get; set; }

        public string CariSoyadi { get; set; }

        public string Telefon { get; set; }

        public string FirmaAdi { get; set; }

        public string FirmaVKN { get; set; }

        public string Kategori { get; set; }

        public string Il { get; set; }

        public string Ilce { get; set; }

        public string Adres { get; set; }
    }
}