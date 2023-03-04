using System.ComponentModel.DataAnnotations;

public class PaymentsDetalle
{
    [Key]

    public int PaymentDetalleId { get; set; }
    public int PaymentId { get; set; }
    public int LoanId { get; set; }
    public int PaidValue { get; set; }

}