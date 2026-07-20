using System.ComponentModel.DataAnnotations;

namespace FormUygulamasi.Models
{
    public class Stok
    {
        [Key]
        public int StokKodu { get; set; }

        [Required(ErrorMessage = "Stok adı zorunludur.")]
        public string StokAdi { get; set; }

        [Required(ErrorMessage = "Barkod zorunludur.")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Barkod 9 karakter olmalıdır.")]
        public string Barkod { get; set; }

        [Required(ErrorMessage = "Birim adı zorunludur.")]
        public string BirimAdi { get; set; }

        [Required(ErrorMessage = "Adet zorunludur.")]
        public int Adet { get; set; }

        [Required(ErrorMessage = "Alış fiyatı zorunludur.")]
        public decimal AlisFiyati { get; set; }

        [Required(ErrorMessage = "Satış fiyatı zorunludur.")]
        public decimal SatisFiyati { get; set; }

        public int KdvOrani { get; set; }
    }
}