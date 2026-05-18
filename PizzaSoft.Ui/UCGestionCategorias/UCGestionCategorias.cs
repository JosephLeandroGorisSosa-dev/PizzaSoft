using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PizzaSoft.Ui.Services;

namespace PizzaSoft.Ui
{
    public partial class UCGestionCategorias : UserControl
    {
        private readonly CategoriaService _categoriaService;

        public UCGestionCategorias()
        {
            InitializeComponent();
        }

        public UCGestionCategorias(CategoriaService categoriaService) : this()
        {
            _categoriaService = categoriaService;
            this.Load += UCGestionCategorias_Load;
        }

        private void UCGestionCategorias_Load(object? sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            try
            {
                dgvDatos.DataSource = _categoriaService.ObtenerCategoriasGridView(txtBuscar?.Text ?? "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmNuevaCategoria(_categoriaService))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarCategorias();
                }
            }
        }

        private void btnEditarCategoria_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvDatos.CurrentRow.Cells["ID"].Value);
                using (var frm = new FrmEditarCategoria(_categoriaService, id))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CargarCategorias();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una categoría para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            if (dgvDatos.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvDatos.CurrentRow.Cells["ID"].Value);
                string nombre = dgvDatos.CurrentRow.Cells["Nombre"].Value.ToString();

                var result = MessageBox.Show($"¿Está seguro que desea eliminar la categoría '{nombre}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _categoriaService.EliminarCategoria(id);
                        CargarCategorias();
                        MessageBox.Show("Categoría eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar la categoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una categoría para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
