using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Empresa
{
    [Key]
    public int EmpresaId { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; }

    // Relación con Camioneros
    public virtual ICollection<Camionero> Camioneros { get; set; }
}
