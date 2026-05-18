using Microsoft.Extensions.DependencyInjection;
using PizzaSoft.Ui.UCGestionClientes;
using PizzaSoft.Ui.UCGestionProductos;
using PizzaSoft.Ui.UCNuevaVenta;
using PizzaSoft.Ui.UCHistorialVentas;
using System;
using System.Windows.Forms;

namespace PizzaSoft
{
    public partial class Form1 : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(IServiceProvider serviceProvider) : this()
        {
            _serviceProvider = serviceProvider;

            // Asignar los eventos Click a los botones
            btnProductos.Click += BtnProductos_Click;
            btnCategorias.Click += BtnCategorias_Click;
            btnNuevaVenta.Click += BtnNuevaVenta_Click;
            btnVentas.Click += BtnVentas_Click;
            btnClientes.Click += BtnClientes_Click;
        }

        // Método auxiliar para cargar un UserControl en el panel principal
        private void MostrarControl(UserControl control)
        {
            pnlContent.Controls.Clear(); // Limpiar el panel
            control.Dock = DockStyle.Fill; // Hacer que ocupe todo el espacio
            pnlContent.Controls.Add(control); // Agregar el nuevo control
        }

        private void BtnProductos_Click(object? sender, EventArgs e)
        {
            MostrarControl(_serviceProvider.GetRequiredService<UCGestionProductos>());
        } 

        private void BtnCategorias_Click(object? sender, EventArgs e)
        {
            MostrarControl(_serviceProvider.GetRequiredService<PizzaSoft.Ui.UCGestionCategorias>());
        }

        private void BtnNuevaVenta_Click(object? sender, EventArgs e)
        {
            MostrarControl(_serviceProvider.GetRequiredService<UCNuevaVenta>());
        }

        private void BtnVentas_Click(object? sender, EventArgs e)
        {
            MostrarControl(_serviceProvider.GetRequiredService<UCHistorialVentas>());
        }

        private void BtnClientes_Click(object? sender, EventArgs e)
        {
            MostrarControl(_serviceProvider.GetRequiredService<UCGestionClientes>());
        } 
    }
}
