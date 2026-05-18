using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PizzaSoft.Data.Models;

public partial class DetalleVentum
{
    [Key]
    public int IdDetalle { get; set; }

    public int? IdVenta { get; set; }

    public int? IdProducto { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Subtotal { get; set; }

    [ForeignKey("IdProducto")]
    [InverseProperty("DetalleVenta")]
    public virtual Producto? IdProductoNavigation { get; set; }

    [ForeignKey("IdVenta")]
    [InverseProperty("DetalleVenta")]
    public virtual Venta? IdVentaNavigation { get; set; }
}
