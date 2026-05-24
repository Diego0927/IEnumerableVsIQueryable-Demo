using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IEnumerableVsIQueryable.Console.Entities;

[Table("CLIENTES")]
public class Cliente
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("NOMBRE")]
    public string Nombre { get; set; } = string.Empty;

    [Column("CIUDAD")]
    public string Ciudad { get; set; } = string.Empty;

    [Column("EDAD")]
    public int Edad { get; set; }

    [Column("SALARIO")]
    public decimal Salario { get; set; }

    [Column("ACTIVO")]
    public string Activo { get; set; } = string.Empty;

    [Column("FECHA_REGISTRO")]
    public DateTime FechaRegistro { get; set; }

    [Column("TIPO_CLIENTE")]
    public string TipoCliente { get; set; } = string.Empty;
}