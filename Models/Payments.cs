using System.ComponentModel.DataAnnotations;

public class Payments
{
    [Key]

    public int PaymentId { get; set; }
    public DateTime Date { get; set; }
    public int PersonId { get; set; }
    public string? Conceit { get; set; }
    public int Total { get; set; }
}