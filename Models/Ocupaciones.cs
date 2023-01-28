using System.ComponentModel.DataAnnotations;

public class Ocupaciones
{
    [Key]

    public int OcupacionId{get; set;}
    public float Salario {get; set;}
    [Required(ErrorMessage ="La descripcion es requerida")]
    public string? Descripcion{get; set;}
}