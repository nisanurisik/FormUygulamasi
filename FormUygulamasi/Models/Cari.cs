using System.ComponentModel.DataAnnotations;

namespace FormUygulamasi.Models
{
    public class Cari
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Cari adı girilmesi zorunludur.")]
        public string CariAdi { get; set; }

        [Required(ErrorMessage = "Cari soyadı girilmesi zorunludur.")]
        public string CariSoyadi { get; set; }

        [Required(ErrorMessage = "Telefon numarası girilmesi zorunludur.")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Firma adı girilmesi zorunludur.")]
        public string FirmaAdi { get; set; }

        [Required(ErrorMessage = "Firma VKN girilmesi zorunludur.")]
        public string FirmaVKN { get; set; }

        [Required(ErrorMessage = "Kategori girilmesi zorunludur.")]
        public string Kategori { get; set; }

        [Required(ErrorMessage = "İl girilmesi zorunludur.")]
        public string Il { get; set; }

        public string Ilce { get; set; }

        public string Adres { get; set; }
    }
}