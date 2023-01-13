using System.ComponentModel.DataAnnotations;

namespace NoodleReviews.Models;

public class NoodlePack
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string BarCode { get; set; }
    public string? Notes { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReviewDate { get; set; }
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