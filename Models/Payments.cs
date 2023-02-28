using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Payments
{
    [Key]
    public int PaymentId { get; set; }
    public DateTime Date { get; set; }
    public int PersonId { get; set; }
    public string? Conceit { get; set; }
    public int Total { get; set; }

    [ForeignKey("PaymentId")]
    public virtual List<PaymentsDetalle> PaymentsDetalle {get; set;}
}