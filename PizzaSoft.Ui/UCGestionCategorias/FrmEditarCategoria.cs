using System;
using System.Windows.Forms;
using PizzaSoft.Data.Models;
using PizzaSoft.Ui.Services;

namespace PizzaSoft.Ui
{
    public partial class FrmEditarCategoria : Form
    {
        private readonly CategoriaService _categoriaService;
        private readonly int _categoriaId;

        public FrmEditarCategoria(CategoriaService categoriaService, int categoriaId)
        {
            _categoriaService = categoriaService;
            _categoriaId = categoriaId;
            InitializeComponent();
        }

        private void FrmEditarCategoria_Load(object sender, EventArgs e)
        {
            try
            {
                var categoria = _categoriaService.ObtenerCategoriaPorId(_categoriaId);
                if (categoria != null)
                {
                    txtNombre.Text = categoria.Nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categoría: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var categoria = _categoriaService.ObtenerCategoriaPorId(_categoriaId);
                if (categoria != null)
                {
                    categoria.Nombre = txtNombre.Text;

                    _categoriaService.ModificarCategoria(categoria);
                    MessageBox.Show("Categoría actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la categoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}