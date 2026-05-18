namespace PizzaSoft
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblLogo;
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
            pnlLogo = new Panel();
            lblLogo = new Label();
            btnClientes = new Button();
            btnVentas = new Button();
            btnNuevaVenta = new Button();
            btnCategorias = new Button();
            btnProductos = new Button();
            pnlContent = new Panel();
            pnlSidebar.SuspendLayout();
            pnlLogo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(192, 57, 43);
            pnlSidebar.BorderStyle = BorderStyle.None;
            pnlSidebar.Controls.Add(btnClientes);
            pnlSidebar.Controls.Add(btnVentas);
            pnlSidebar.Controls.Add(btnNuevaVenta);
            pnlSidebar.Controls.Add(btnCategorias);
            pnlSidebar.Controls.Add(btnProductos);
            pnlSidebar.Controls.Add(pnlLogo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(200, 432);
            pnlSidebar.TabIndex = 0;
            // 
            // pnlLogo
            // 
            pnlLogo.Controls.Add(lblLogo);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(200, 70);
            pnlLogo.TabIndex = 5;
            pnlLogo.BackColor = Color.FromArgb(142, 36, 26);
            // 
            // lblLogo
            // 
            lblLogo.Dock = DockStyle.Fill;
            lblLogo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(0, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(200, 70);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "🍕 PizzaSoft";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClientes
            // 
            btnClientes.Dock = DockStyle.Top;
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnClientes.ForeColor = Color.White;
            btnClientes.Location = new Point(0, 270);
            btnClientes.Name = "btnClientes";
            btnClientes.Padding = new Padding(20, 0, 0, 0);
            btnClientes.Size = new Size(200, 50);
            btnClientes.TabIndex = 4;
            btnClientes.Text = "👥 Clientes";
            btnClientes.TextAlign = ContentAlignment.MiddleLeft;
            btnClientes.UseVisualStyleBackColor = true;
            // 
            // btnVentas
            // 
            btnVentas.Dock = DockStyle.Top;
            btnVentas.FlatAppearance.BorderSize = 0;
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnVentas.ForeColor = Color.White;
            btnVentas.Location = new Point(0, 220);
            btnVentas.Name = "btnVentas";
            btnVentas.Padding = new Padding(20, 0, 0, 0);
            btnVentas.Size = new Size(200, 50);
            btnVentas.TabIndex = 3;
            btnVentas.Text = "📋 Historial Ventas";
            btnVentas.TextAlign = ContentAlignment.MiddleLeft;
            btnVentas.UseVisualStyleBackColor = true;
            // 
            // btnNuevaVenta
            // 
            btnNuevaVenta.Dock = DockStyle.Top;
            btnNuevaVenta.FlatAppearance.BorderSize = 0;
            btnNuevaVenta.FlatStyle = FlatStyle.Flat;
            btnNuevaVenta.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnNuevaVenta.ForeColor = Color.White;
            btnNuevaVenta.Location = new Point(0, 170);
            btnNuevaVenta.Name = "btnNuevaVenta";
            btnNuevaVenta.Padding = new Padding(20, 0, 0, 0);
            btnNuevaVenta.Size = new Size(200, 50);
            btnNuevaVenta.TabIndex = 2;
            btnNuevaVenta.Text = "🛒 Nueva Venta";
            btnNuevaVenta.TextAlign = ContentAlignment.MiddleLeft;
            btnNuevaVenta.UseVisualStyleBackColor = true;
            // 
            // btnCategorias
            // 
            btnCategorias.Dock = DockStyle.Top;
            btnCategorias.FlatAppearance.BorderSize = 0;
            btnCategorias.FlatStyle = FlatStyle.Flat;
            btnCategorias.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnCategorias.ForeColor = Color.White;
            btnCategorias.Location = new Point(0, 120);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Padding = new Padding(20, 0, 0, 0);
            btnCategorias.Size = new Size(200, 50);
            btnCategorias.TabIndex = 1;
            btnCategorias.Text = "🏷️ Categorías";
            btnCategorias.TextAlign = ContentAlignment.MiddleLeft;
            btnCategorias.UseVisualStyleBackColor = true;
            // 
            // btnProductos
            // 
            btnProductos.Dock = DockStyle.Top;
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnProductos.ForeColor = Color.White;
            btnProductos.Location = new Point(0, 70);
            btnProductos.Name = "btnProductos";
            btnProductos.Padding = new Padding(20, 0, 0, 0);
            btnProductos.Size = new Size(200, 50);
            btnProductos.TabIndex = 0;
            btnProductos.Text = "🍕 Productos";
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
