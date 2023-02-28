using System.ComponentModel.DataAnnotations;

public class PaymentsDetalle
{
    [Key]

    public int PaymentDetalleId { get; set; }
    public int PaymentId { get; set; }
    public int LoanId { get; set; }
    public int PaidValue { get; set; }

    public PaymentsDetalle()
    {
        PaymentDetalleId =0;
        PaymentId = 0;
        LoanId = 0;
        PaidValue =0;
    }
    public PaymentsDetalle(int paymentId, int loanId, int paidValue)
    {
        PaymentDetalleId =0;
        PaymentId = paymentId;
        LoanId = loanId;
        PaidValue = paidValue;
    }
}