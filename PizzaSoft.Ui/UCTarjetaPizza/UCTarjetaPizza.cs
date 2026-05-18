using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PizzaSoft.Ui.UCTarjetaPizza
{
    public partial class UCTarjetaPizza : UserControl
    {
        // Evento que se disparará cuando el usuario haga clic en "Agregar"
        public event EventHandler BtnAgregarClick;

        // Propiedades públicas para que desde afuera podamos leer los datos de esta tarjeta
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int IdProducto { get; set; }

        public string NombrePizza { get { return lblNombre.Text; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal PrecioPizza { get; set; }

        public UCTarjetaPizza()
        {
            InitializeComponent();
            btnAgregar.Click += (s, e) => BtnAgregarClick?.Invoke(this, e);
        }

        // Método para llenar la tarjeta con los datos de la base de datos
        public void CargarDatos(int id, string nombre, string categoria, decimal precio, Image imagen = null)
        {
            IdProducto = id;
            lblNombre.Text = nombre;
            lblCategoria.Text = categoria;
            PrecioPizza = precio;
            lblPrecio.Text = $"${precio:0.00}";

            if (imagen != null)
            {
                pbImagen.Image = imagen;
            }
        }
    }
}
