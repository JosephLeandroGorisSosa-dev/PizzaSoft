using PizzaSoft.Ui.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PizzaSoft.Ui.UCHistorialVentas
{
    public partial class UCHistorialVentas : UserControl
    {
        private readonly VentaService _ventaService;

        public UCHistorialVentas()
        {
            InitializeComponent();
        }

        public UCHistorialVentas(VentaService ventaService) : this()
        {
            _ventaService = ventaService;
            this.Load += UCHistorialVentas_Load;
        }

        private void UCHistorialVentas_Load(object? sender, EventArgs e)
        {
            CargarVentas();
        }

        private void CargarVentas()
        {
            try
            {
                DataTable dt = _ventaService.ObtenerHistorialVentas(txtBuscar?.Text ?? "");
                dgvVentas.DataSource = dt;

                if (dt.Rows.Count > 0)
                {
                    lblMensaje.Text = $"Se encontraron {dt.Rows.Count} ventas registradas.";
                }
                else
                {
                    lblMensaje.Text = "No hay ventas registradas aún para esta búsqueda.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial de ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblMensaje.Text = "Error al cargar las ventas.";
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarVentas();
        }
    }
}
