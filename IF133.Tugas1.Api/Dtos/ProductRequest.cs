using System.ComponentModel.DataAnnotations;

namespace IF133.Tugas1.Api.Dtos;

/// <summary>
/// Body request untuk POST dan PUT. Id tidak ikut dikirim client
/// supaya primary key tetap dikontrol oleh database.
/// </summary>
public class ProductRequest
{
    [Required(ErrorMessage = "Name wajib diisi.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name harus 3-100 karakter.")]
    public string Name { get; set; } = string.Empty;

    [StringLength(250, ErrorMessage = "Description maksimal 250 karakter.")]
    public string? Description { get; set; }

    [Range(0, 999_999_999, ErrorMessage = "Price tidak boleh negatif.")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Stock tidak boleh negatif.")]
    public int Stock { get; set; }
}
