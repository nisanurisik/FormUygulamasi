using System.ComponentModel.DataAnnotations;

namespace FormUygulamasi.ViewModels
{
    public class CariViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Cari adı girilmesi zorunludur.")]
        [Display(Name = "Cari Adı")]
        public string CariAdi { get; set; }

        [Required(ErrorMessage = "Cari soyadı girilmesi zorunludur.")]
        [Display(Name = "Cari Soyadı")]         
        public string CariSoyadi { get; set; }

        [Required(ErrorMessage = "Telefon numarası girilmesi zorunludur.")]
        [Display(Name = "Telefon")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Firma adı girilmesi zorunludur.")]
        [Display(Name = "Firma Adı")]
        public string FirmaAdi { get; set; }

        [Required(ErrorMessage = "Firma VKN girilmesi zorunludur.")]
        [Display(Name = "Firma VKN")]
        public string FirmaVKN { get; set; }

        [Required(ErrorMessage = "Kategori girilmesi zorunludur.")]
        [Display(Name = "Kategori")]
        public string Kategori { get; set; }

        [Required(ErrorMessage = "İl girilmesi zorunludur.")]
        [Display(Name = "İl")]
        public string Il { get; set; }

        [Display(Name = "İlçe")]
        public string? Ilce { get; set; }

        [Display(Name = "Adres")]
        public string? Adres { get; set; }
    }
}