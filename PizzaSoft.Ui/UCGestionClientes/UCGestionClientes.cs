using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PizzaSoft.Ui.Services;

namespace PizzaSoft.Ui.UCGestionClientes
{
    public partial class UCGestionClientes : UserControl
    {
        private readonly ClienteService _clienteService;

        public UCGestionClientes()
        {
            InitializeComponent();
        }

        public UCGestionClientes(ClienteService clienteService) : this()
        {
            _clienteService = clienteService;
            this.Load += UCGestionClientes_Load;
        }

        private void UCGestionClientes_Load(object? sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                dgvDatos.DataSource = _clienteService.ObtenerClientesGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
