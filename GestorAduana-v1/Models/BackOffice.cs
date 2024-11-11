// Models/BackOffice.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BackOffice
{
    // Clave primaria para BackOffice
    [Key]
    public int IdBackOffice { get; set; }

    // Nombre del BackOffice con longitud máxima de 50 caracteres
    [Required]
    [StringLength(50)]
    public string NombreBo { get; set; }

    // Apellido del BackOffice con longitud máxima de 50 caracteres
    [Required]
    [StringLength(50)]
    public string ApellidoBo { get; set; }

    // Clave foránea que referencia a la entidad Empresa
    [Required]
    public int EmpresaId { get; set; }

    // Navegación a la entidad Empresa
    [ForeignKey("EmpresaId")]
    public virtual Empresa Empresa { get; set; }

    // Otros campos relacionados al recorrido y contenido con longitud máxima de 200 caracteres
    [Required]
    [StringLength(200)]
    public string Recorrido { get; set; }
}
