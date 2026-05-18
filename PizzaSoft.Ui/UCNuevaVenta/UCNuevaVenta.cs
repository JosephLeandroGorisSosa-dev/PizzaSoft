using PizzaSoft.Ui.Services;
using PizzaSoft.Ui.Models;
using PizzaSoft.Ui.UCTarjetaPizza;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PizzaSoft.Ui.UCNuevaVenta
{
    public partial class UCNuevaVenta : UserControl
    {
        private readonly VentaService _ventaService;
        private readonly ProductoService _productoService;
        private readonly CategoriaService _categoriaService;

        public UCNuevaVenta()
        {
            InitializeComponent();
        }

        public UCNuevaVenta(VentaService ventaService, ProductoService productoService, CategoriaService categoriaService) : this()
        {
            _ventaService = ventaService;
            _productoService = productoService;
            _categoriaService = categoriaService;

            this.Load += UCNuevaVenta_Load;
            btnProcesarVenta.Click += BtnProcesarVenta_Click;
            btnCancelarVenta.Click += BtnCancelarVenta_Click;
        }

        private void BtnCancelarVenta_Click(object? sender, EventArgs e)
        {
            if (dgvCarrito.Rows.Count == 0)
            {
                MessageBox.Show("El carrito ya está vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro que desea cancelar la venta actual? Se perderán todos los productos agregados al carrito.", "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                dgvCarrito.Rows.Clear();
                ActualizarTotal();
                MessageBox.Show("Venta cancelada exitosamente.", "Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnProcesarVenta_Click(object? sender, EventArgs e)
        {
            if (dgvCarrito.Rows.Count == 0)
            {
                MessageBox.Show("El carrito está vacío. Agregue productos antes de procesar la venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Calcular el total
            decimal totalVenta = 0;
            List<DetalleVentaModel> detalles = new List<DetalleVentaModel>();

            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                totalVenta += Convert.ToDecimal(row.Cells["Subtotal"].Value);

                detalles.Add(new DetalleVentaModel
                {
                    IdProducto = Convert.ToInt32(row.Cells["IdProducto"].Value),
                    Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),
                    Subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value)
                });
            }

            try
            {
                string nombreCliente = "";
                using (Form prompt = new Form())
                {
                    prompt.Width = 400;
                    prompt.Height = 150;
                    prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                    prompt.Text = "Nombre del Cliente";
                    prompt.StartPosition = FormStartPosition.CenterParent;
                    prompt.MinimizeBox = false;
                    prompt.MaximizeBox = false;

                    Label textLabel = new Label() { Left = 20, Top = 20, Text = "Ingrese el nombre del cliente (opcional):", Width = 350 };
                    TextBox textBox = new TextBox() { Left = 20, Top = 45, Width = 340 };
                    Button confirmation = new Button() { Text = "Aceptar", Left = 260, Width = 100, Top = 75, DialogResult = DialogResult.OK };

                    prompt.Controls.Add(textLabel);
                    prompt.Controls.Add(textBox);
                    prompt.Controls.Add(confirmation);
                    prompt.AcceptButton = confirmation;

                    if (prompt.ShowDialog() == DialogResult.OK)
                    {
                        nombreCliente = textBox.Text.Trim();
                    }
                    else
                    {
                        // Si el usuario cancela, no procesamos la venta
                        return;
                    }
                }

                int idVenta = _ventaService.ProcesarVenta(totalVenta, detalles, nombreCliente);

                MessageBox.Show($"¡Venta procesada con éxito!\nNúmero de ticket (IdVenta): {idVenta}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar pnl y totales
                dgvCarrito.Rows.Clear();
                ActualizarTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la venta: \n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UCNuevaVenta_Load(object? sender, EventArgs e)
        {
            ConfigurarCarrito();
            CargarCategoriasFiltro();
            CargarProductosDesdeBD();

            // Suscribir al evento SelectedIndexChanged para filtrar
            cmbCategoria.SelectedIndexChanged += CmbCategoria_SelectedIndexChanged;
        }

        private void CargarCategoriasFiltro()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Todas las Categorías");

            try
            {
                var categorias = _categoriaService.ObtenerNombresCategorias();
                foreach (var cat in categorias)
                {
                    cmbCategoria.Items.Add(cat);
                }

                // Seleccionar "Todas las Categorías" por defecto
                if (cmbCategoria.Items.Count > 0)
                {
                    cmbCategoria.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías para el filtro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbCategoria_SelectedIndexChanged(object? sender, EventArgs e)
        {
            CargarProductosDesdeBD();
        }

        private void ConfigurarCarrito()
        {
            dgvCarrito.Columns.Clear();
            dgvCarrito.Columns.Add("IdProducto", "ID");
            dgvCarrito.Columns["IdProducto"].Visible = false; // Ocultamos el ID
            dgvCarrito.Columns.Add("Nombre", "Producto");
            dgvCarrito.Columns.Add("Cantidad", "Cant.");
            dgvCarrito.Columns.Add("Precio", "Precio");
            dgvCarrito.Columns.Add("Subtotal", "Subtotal");

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.Name = "Eliminar";
            btnEliminar.HeaderText = "";
            btnEliminar.Text = "X";
            btnEliminar.UseColumnTextForButtonValue = true;
            btnEliminar.FillWeight = 15;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            dgvCarrito.Columns.Add(btnEliminar);

            dgvCarrito.ReadOnly = true;
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.RowHeadersVisible = false;
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ajustar un poco los anchos
            dgvCarrito.Columns["Cantidad"].FillWeight = 20;
            dgvCarrito.Columns["Precio"].FillWeight = 25;
            dgvCarrito.Columns["Subtotal"].FillWeight = 25;
            dgvCarrito.Columns["Nombre"].FillWeight = 30;

            // Evento para capturar el click en el botón Eliminar
            dgvCarrito.CellClick -= DgvCarrito_CellClick;
            dgvCarrito.CellClick += DgvCarrito_CellClick;
        }

        private void DgvCarrito_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCarrito.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                dgvCarrito.Rows.RemoveAt(e.RowIndex);
                ActualizarTotal();
            }
        }

        private void CargarProductosDesdeBD()
        {
            flpProductos.Controls.Clear();

            try
            {
                string filtroCategoria = cmbCategoria.SelectedItem?.ToString();
                string filtroNombre = txtBuscar?.Text ?? "";
                var productos = _productoService.ObtenerCatalogo(filtroCategoria, filtroNombre);

                foreach (var p in productos)
                {
                    // Crear una nueva tarjeta
                    PizzaSoft.Ui.UCTarjetaPizza.UCTarjetaPizza tarjeta = new PizzaSoft.Ui.UCTarjetaPizza.UCTarjetaPizza();

                    // Cargar los datos
                    tarjeta.CargarDatos(p.IdProducto, p.Nombre, p.Categoria, p.Precio, null);

                    // Suscribirse al evento Agregar
                    tarjeta.BtnAgregarClick += Tarjeta_BtnAgregarClick;

                    // Agregarla al contenedor
                    flpProductos.Controls.Add(tarjeta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarProductosDesdeBD();
        }

        private void Tarjeta_BtnAgregarClick(object? sender, EventArgs e)
        {
            if (sender is PizzaSoft.Ui.UCTarjetaPizza.UCTarjetaPizza tarjeta)
            {
                bool existe = false;

                // Verificar si el producto ya está en el carrito
                foreach (DataGridViewRow row in dgvCarrito.Rows)
                {
                    if (Convert.ToInt32(row.Cells["IdProducto"].Value) == tarjeta.IdProducto)
                    {
                        // Si existe, aumentamos la cantidad y el subtotal
                        int cant = Convert.ToInt32(row.Cells["Cantidad"].Value) + 1;
                        row.Cells["Cantidad"].Value = cant;
                        row.Cells["Subtotal"].Value = cant * tarjeta.PrecioPizza;
                        existe = true;
                        break;
                    }
                }

                // Si no existe, agregamos una nueva fila
                if (!existe)
                {
                    dgvCarrito.Rows.Add(
                        tarjeta.IdProducto,
                        tarjeta.NombrePizza,
                        1,
                        tarjeta.PrecioPizza,
                        tarjeta.PrecioPizza
                    );
                }

                ActualizarTotal();
            }
        }

        private void ActualizarTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
            }

            lblTotal.Text = $"TOTAL: ${total:0.00}";
        }
    }
}
