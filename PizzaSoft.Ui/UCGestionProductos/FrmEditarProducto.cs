using System;
using System.Windows.Forms;
using PizzaSoft.Data.Models;
using PizzaSoft.Ui.Services;
using System.Linq;

namespace PizzaSoft.Ui.UCGestionProductos
{
    public partial class FrmEditarProducto : Form
    {
        private readonly ProductoService _productoService;
        private readonly int _productoId;

        public FrmEditarProducto(ProductoService productoService, int productoId)
        {
            _productoService = productoService;
            _productoId = productoId;
            InitializeComponent();
        }

        private void FrmEditarProducto_Load(object sender, EventArgs e)
        {
            try
            {
                var categorias = _productoService.ObtenerCategorias();
                cmbCategoria.DataSource = categorias;
                cmbCategoria.DisplayMember = "Nombre";
                cmbCategoria.ValueMember = "IdCategoria";

                var producto = _productoService.ObtenerProductoPorId(_productoId);
                if (producto != null)
                {
                    txtNombre.Text = producto.Nombre;
                    txtPrecio.Text = producto.Precio.ToString("0.00");
                    if (producto.IdCategoria != null)
                    {
                        cmbCategoria.SelectedValue = producto.IdCategoria;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar producto: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || !decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Por favor, ingrese un nombre y un precio válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var producto = _productoService.ObtenerProductoPorId(_productoId);
                if (producto != null)
                {
                    producto.Nombre = txtNombre.Text;
                    producto.Precio = precio;
                    producto.IdCategoria = (int)cmbCategoria.SelectedValue;

                    _productoService.ModificarProducto(producto);
                    MessageBox.Show("Producto actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
