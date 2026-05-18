namespace PizzaSoft
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnNuevaVenta;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Panel pnlContent;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            btnClientes = new Button();
            btnVentas = new Button();
            btnNuevaVenta = new Button();
            btnCategorias = new Button();
            btnProductos = new Button();
            pnlContent = new Panel();
            pnlSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.White;
            pnlSidebar.BorderStyle = BorderStyle.FixedSingle;
            pnlSidebar.Controls.Add(btnClientes);
            pnlSidebar.Controls.Add(btnVentas);
            pnlSidebar.Controls.Add(btnNuevaVenta);
            pnlSidebar.Controls.Add(btnCategorias);
            pnlSidebar.Controls.Add(btnProductos);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Padding = new Padding(10);
            pnlSidebar.Size = new Size(200, 432);
            pnlSidebar.TabIndex = 0;
            // 
            // btnClientes
            // 
            btnClientes.Dock = DockStyle.Top;
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Location = new Point(10, 170);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(178, 40);
            btnClientes.TabIndex = 4;
            btnClientes.Text = "Clientes";
            btnClientes.TextAlign = ContentAlignment.MiddleLeft;
            btnClientes.UseVisualStyleBackColor = true;
            // 
            // btnVentas
            // 
            btnVentas.Dock = DockStyle.Top;
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Location = new Point(10, 130);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(178, 40);
            btnVentas.TabIndex = 3;
            btnVentas.Text = "Ventas";
            btnVentas.TextAlign = ContentAlignment.MiddleLeft;
            btnVentas.UseVisualStyleBackColor = true;
            // 
            // btnNuevaVenta
            // 
            btnNuevaVenta.Dock = DockStyle.Top;
            btnNuevaVenta.FlatStyle = FlatStyle.Flat;
            btnNuevaVenta.Location = new Point(10, 90);
            btnNuevaVenta.Name = "btnNuevaVenta";
            btnNuevaVenta.Size = new Size(178, 40);
            btnNuevaVenta.TabIndex = 2;
            btnNuevaVenta.Text = "Nueva Venta";
            btnNuevaVenta.TextAlign = ContentAlignment.MiddleLeft;
            btnNuevaVenta.UseVisualStyleBackColor = true;
            // 
            // btnCategorias
            // 
            btnCategorias.Dock = DockStyle.Top;
            btnCategorias.FlatStyle = FlatStyle.Flat;
            btnCategorias.Location = new Point(10, 50);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(178, 40);
            btnCategorias.TabIndex = 1;
            btnCategorias.Text = "Categorías";
            btnCategorias.TextAlign = ContentAlignment.MiddleLeft;
            btnCategorias.UseVisualStyleBackColor = true;
            // 
            // btnProductos
            // 
            btnProductos.Dock = DockStyle.Top;
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Location = new Point(10, 10);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(178, 40);
            btnProductos.TabIndex = 0;
            btnProductos.Text = "Productos";
            btnProductos.TextAlign = ContentAlignment.MiddleLeft;
            btnProductos.UseVisualStyleBackColor = true;
            // 
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(200, 0);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(20);
            pnlContent.Size = new Size(558, 432);
            pnlContent.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(758, 432);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PizzaSoft POS";
            pnlSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
