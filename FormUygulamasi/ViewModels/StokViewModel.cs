using System.ComponentModel.DataAnnotations;

namespace FormUygulamasi.ViewModels
{
    public class StokViewModel
    {
        [Display(Name = "Stok Kodu")]
        public int StokKodu { get; set; }

        [Required(ErrorMessage = "Stok adı zorunludur.")]
        [Display(Name = "Stok Adı")]
        public string StokAdi { get; set; }

        [Required(ErrorMessage = "Barkod zorunludur.")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Barkod 9 karakter olmalıdır.")]
        [Display(Name = "Barkod")]
        public string Barkod { get; set; }

        [Required(ErrorMessage = "Birim adı zorunludur.")]
        [Display(Name = "Birim Adı")]
        public string BirimAdi { get; set; }

        [Required(ErrorMessage = "Adet zorunludur.")]
        [Display(Name = "Adet")]
        public int Adet { get; set; }

        [Required(ErrorMessage = "Alış fiyatı zorunludur.")]
        [Display(Name = "Alış Fiyatı")]
        public decimal AlisFiyati { get; set; }

        [Required(ErrorMessage = "Satış fiyatı zorunludur.")]
        [Display(Name = "Satış Fiyatı")]
        public decimal SatisFiyati { get; set; }

        [Display(Name = "KDV Oranı")]
        public int KdvOrani { get; set; }
    }
}