using PizzaSoft.Ui.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PizzaSoft.Ui.UCGestionProductos
{
    public partial class UCGestionProductos : UserControl
    {
        private readonly ProductoService _productoService;

        public UCGestionProductos()
        {
            InitializeComponent();
        }

        public UCGestionProductos(ProductoService productoService) : this()
        {
            _productoService = productoService;
            this.Load += UCGestionProductos_Load;
        }

        private void UCGestionProductos_Load(object? sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                dgvDatos.DataSource = _productoService.ObtenerProductosGridView(txtBuscar?.Text ?? "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmNuevoProducto(_productoService))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarProductos(); // Recargar datos después de agregar
                }
            }
        }

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvDatos.CurrentRow.Cells["ID"].Value);
                using (var frm = new FrmEditarProducto(_productoService, id))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CargarProductos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvDatos.CurrentRow.Cells["ID"].Value);
                string nombre = dgvDatos.CurrentRow.Cells["Nombre"].Value.ToString();

                var result = MessageBox.Show($"¿Está seguro que desea eliminar el producto '{nombre}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _productoService.EliminarProducto(id);
                        CargarProductos();
                        MessageBox.Show("Producto eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
