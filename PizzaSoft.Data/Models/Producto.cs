using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PizzaSoft.Data.Models;

public partial class Producto
{
    [Key]
    public int IdProducto { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Precio { get; set; }

    public int? IdCategoria { get; set; }

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    [ForeignKey("IdCategoria")]
    [InverseProperty("Productos")]
    public virtual Categoria? IdCategoriaNavigation { get; set; }
}
