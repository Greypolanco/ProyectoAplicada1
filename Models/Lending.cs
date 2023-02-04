using System.ComponentModel.DataAnnotations;

public class Lendind{

    [Key]

    public int loadId{get; set;}

    public DateTime loan_date {get; set;}
    public DateTime loan_expiration {get; set;}
    public int personalId {get; set;}
    public string? conceit{get; set;}
    public float total{get; set;}
    public float balance {get; set;}
}