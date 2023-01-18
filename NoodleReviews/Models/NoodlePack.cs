using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoodleReviews.Models;

public class NoodlePack
{
    public int Id { get; set; }
    [Display(Name = "Navn")]
    public required string Name { get; set; }
    [Display(Name = "Stregkode")]
    public required string BarCode { get; set; }
    [Display(Name = "Noter")]
    public string? Notes { get; set; }
    [Display(Name = "Anmeldelsesdato")]
    [DataType(DataType.Date)]
    public DateTime ReviewDate { get; set; }
    [Display(Name = "Karakter")]
    public Grade Grade { get; set; }
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