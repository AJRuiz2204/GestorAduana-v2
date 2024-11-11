using System.ComponentModel.DataAnnotations;

public class Camionero
{
    [Key]
    public int IdCamionero { get; set; }

    [Required]
    [StringLength(50)]
    public string Nombre { get; set; }

    [Required]
    [StringLength(50)]
    public string Apellido { get; set; }

    [Required]
    [StringLength(10)]
    public string Dui { get; set; }

    [Required]
    public int Edad { get; set; }

    [Required]
    [StringLength(20)]
    public string Placa { get; set; }

    [Required]
    [StringLength(100)]
    public string QueTransporta { get; set; }

    [Required]
    public int CantidadTransportada { get; set; }

    // Clave foránea a Empresa
    public int EmpresaId { get; set; }
    public virtual Empresa Empresa { get; set; }
}
