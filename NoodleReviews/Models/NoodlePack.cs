using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoodleReviews.Models;

public class NoodlePack
{
    public int Id { get; set; }

    [Display(Name = "Navn")]
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public required string Name { get; set; }

    [Display(Name = "Stregkode")]
    [RegularExpression(@"^[0-9]+$")]
    [Required]
    public required string BarCode { get; set; }

    [Display(Name = "Noter")]
    [StringLength(512)]
    public string? Notes { get; set; }

    [Display(Name = "Anmeldelsesdato")]
    [DataType(DataType.Date)]
    public DateTime ReviewDate { get; set; }

    [Display(Name = "Karakter")]
    public Grade Grade { get; set; }

    [Display(Name = "Pris")]
    [Range(0, 300)]
    // [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(9, 2)")]
    public decimal Price { get; set; }
}

public enum Grade
{
    S,
    A,
    B,
    C,
    D,
    F,
}