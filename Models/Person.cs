using System.ComponentModel.DataAnnotations;

public class Person{

    [Key]

    public int personId{get; set;}
    public string? name{get; set;}
    public int number_pho{get; set;}
    public int number_cel{get; set;}
    public string? email{get; set;}
    public string? address{get; set;}
    public DateTime birth_date{get; set;}
    public int occupationId{get; set;}

}