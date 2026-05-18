using System;
using System.Windows.Forms;
using PizzaSoft.Data.Models;
using PizzaSoft.Ui.Services;
using System.Linq;

namespace PizzaSoft.Ui.UCGestionProductos
{
    public partial class FrmNuevoProducto : Form
    {
        private readonly ProductoService _productoService;

        public FrmNuevoProducto(ProductoService productoService)
        {
            _productoService = productoService;
            InitializeComponent();
        }

        private void FrmNuevoProducto_Load(object sender, EventArgs e)
        {
            try
            {
                var categorias = _productoService.ObtenerCategorias();
                cmbCategoria.DataSource = categorias;
                cmbCategoria.DisplayMember = "Nombre";
                cmbCategoria.ValueMember = "IdCategoria";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || !decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Por favor, ingrese un nombre y un precio válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var producto = new Producto
            {
                Nombre = txtNombre.Text,
                Precio = precio,
                IdCategoria = (int)cmbCategoria.SelectedValue
            };

            try
            {
                _productoService.AgregarProducto(producto);
                MessageBox.Show("Producto agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
