using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PizzaSoft.Data.Models;

public partial class Venta
{
    [Key]
    public int IdVenta { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Fecha { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Total { get; set; }

    public int? IdCliente { get; set; }

    [InverseProperty("IdVentaNavigation")]
    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    [ForeignKey("IdCliente")]
    [InverseProperty("Venta")]
    public virtual Cliente? IdClienteNavigation { get; set; }
}
