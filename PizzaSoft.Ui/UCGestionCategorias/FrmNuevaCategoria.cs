using System;
using System.Windows.Forms;
using PizzaSoft.Data.Models;
using PizzaSoft.Ui.Services;

namespace PizzaSoft.Ui
{
    public partial class FrmNuevaCategoria : Form
    {
        private readonly CategoriaService _categoriaService;

        public FrmNuevaCategoria(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var categoria = new Categoria
            {
                Nombre = txtNombre.Text
            };

            try
            {
                _categoriaService.AgregarCategoria(categoria);
                MessageBox.Show("Categoría agregada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la categoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}