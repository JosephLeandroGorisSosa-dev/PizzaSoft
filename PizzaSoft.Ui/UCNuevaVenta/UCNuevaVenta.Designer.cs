namespace PizzaSoft.Ui.UCNuevaVenta
{
    partial class UCNuevaVenta
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlCarrito = new System.Windows.Forms.Panel();
            this.lblTituloCarrito = new System.Windows.Forms.Label();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.pnlTotales = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCancelarVenta = new System.Windows.Forms.Button();
            this.btnProcesarVenta = new System.Windows.Forms.Button();
            this.pnlCatalogo = new System.Windows.Forms.Panel();
            this.pnlFiltro = new System.Windows.Forms.Panel();
            this.lblTituloCatalogo = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.flpProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();

            this.pnlCarrito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.pnlTotales.SuspendLayout();
            this.pnlCatalogo.SuspendLayout();
            this.pnlFiltro.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlCarrito
            // 
            this.pnlCarrito.BackColor = System.Drawing.Color.White;
            this.pnlCarrito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCarrito.Controls.Add(this.dgvCarrito);
            this.pnlCarrito.Controls.Add(this.pnlTotales);
            this.pnlCarrito.Controls.Add(this.lblTituloCarrito);
            this.pnlCarrito.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCarrito.Location = new System.Drawing.Point(550, 0);
            this.pnlCarrito.Name = "pnlCarrito";
            this.pnlCarrito.Padding = new System.Windows.Forms.Padding(10);
            this.pnlCarrito.Size = new System.Drawing.Size(250, 560);
            this.pnlCarrito.TabIndex = 1;

            // 
            // lblTituloCarrito
            // 
            this.lblTituloCarrito.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloCarrito.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloCarrito.Location = new System.Drawing.Point(10, 10);
            this.lblTituloCarrito.Name = "lblTituloCarrito";
            this.lblTituloCarrito.Size = new System.Drawing.Size(228, 30);
            this.lblTituloCarrito.TabIndex = 0;
            this.lblTituloCarrito.Text = "Detalle de Venta";

            // 
            // dgvCarrito
            // 
            this.dgvCarrito.AllowUserToAddRows = false;
            this.dgvCarrito.AllowUserToDeleteRows = false;
            this.dgvCarrito.BackgroundColor = System.Drawing.Color.White;
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.ColumnHeadersVisible = false;
            this.dgvCarrito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarrito.Location = new System.Drawing.Point(10, 40);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.ReadOnly = true;
            this.dgvCarrito.RowHeadersVisible = false;
            this.dgvCarrito.Size = new System.Drawing.Size(228, 410);
            this.dgvCarrito.TabIndex = 1;

            // 
            // pnlTotales
            // 
            this.pnlTotales.Controls.Add(this.lblTotal);
            this.pnlTotales.Controls.Add(this.btnCancelarVenta);
            this.pnlTotales.Controls.Add(this.btnProcesarVenta);
            this.pnlTotales.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotales.Location = new System.Drawing.Point(10, 420);
            this.pnlTotales.Name = "pnlTotales";
            this.pnlTotales.Size = new System.Drawing.Size(228, 128);
            this.pnlTotales.TabIndex = 2;

            // 
            // lblTotal
            // 
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.Location = new System.Drawing.Point(0, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(228, 30);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "TOTAL: $0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // btnCancelarVenta
            // 
            this.btnCancelarVenta.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnCancelarVenta.ForeColor = System.Drawing.Color.White;
            this.btnCancelarVenta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCancelarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarVenta.FlatAppearance.BorderSize = 0;
            this.btnCancelarVenta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelarVenta.Location = new System.Drawing.Point(0, 48);
            this.btnCancelarVenta.Name = "btnCancelarVenta";
            this.btnCancelarVenta.Size = new System.Drawing.Size(228, 40);
            this.btnCancelarVenta.TabIndex = 3;
            this.btnCancelarVenta.Text = "Cancelar Venta";
            this.btnCancelarVenta.UseVisualStyleBackColor = false;

            // 
            // btnProcesarVenta
            // 
            this.btnProcesarVenta.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnProcesarVenta.ForeColor = System.Drawing.Color.White;
            this.btnProcesarVenta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnProcesarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesarVenta.FlatAppearance.BorderSize = 0;
            this.btnProcesarVenta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnProcesarVenta.Location = new System.Drawing.Point(0, 88);
            this.btnProcesarVenta.Name = "btnProcesarVenta";
            this.btnProcesarVenta.Size = new System.Drawing.Size(228, 40);
            this.btnProcesarVenta.TabIndex = 1;
            this.btnProcesarVenta.Text = "Procesar Venta";
            this.btnProcesarVenta.UseVisualStyleBackColor = false;

            // 
            // pnlCatalogo
            // 
            this.pnlCatalogo.BackColor = System.Drawing.Color.White;
            this.pnlCatalogo.Controls.Add(this.flpProductos);
            this.pnlCatalogo.Controls.Add(this.pnlFiltro);
            this.pnlCatalogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCatalogo.Location = new System.Drawing.Point(0, 0);
            this.pnlCatalogo.Name = "pnlCatalogo";
            this.pnlCatalogo.Padding = new System.Windows.Forms.Padding(10);
            this.pnlCatalogo.Size = new System.Drawing.Size(550, 560);
            this.pnlCatalogo.TabIndex = 0;

            // 
            // pnlFiltro
            // 
            this.pnlFiltro.Controls.Add(this.cmbCategoria);
            this.pnlFiltro.Controls.Add(this.lblTituloCatalogo);
            this.pnlFiltro.Controls.Add(this.lblBuscar);
            this.pnlFiltro.Controls.Add(this.txtBuscar);
            this.pnlFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltro.Location = new System.Drawing.Point(10, 10);
            this.pnlFiltro.Name = "pnlFiltro";
            this.pnlFiltro.Size = new System.Drawing.Size(530, 60);
            this.pnlFiltro.TabIndex = 0;

            // 
            // lblTituloCatalogo
            // 
            this.lblTituloCatalogo.AutoSize = true;
            this.lblTituloCatalogo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloCatalogo.Location = new System.Drawing.Point(0, 0);
            this.lblTituloCatalogo.Name = "lblTituloCatalogo";
            this.lblTituloCatalogo.Size = new System.Drawing.Size(211, 25);
            this.lblTituloCatalogo.TabIndex = 0;
            this.lblTituloCatalogo.Text = "Catálogo de Productos";

            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Items.AddRange(new object[] {
            "Todas las Categorías"});
            this.cmbCategoria.Location = new System.Drawing.Point(5, 30);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(150, 23);
            this.cmbCategoria.TabIndex = 1;

            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(165, 33);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(45, 15);
            this.lblBuscar.TabIndex = 2;
            this.lblBuscar.Text = "Buscar:";

            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(215, 30);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(200, 23);
            this.txtBuscar.TabIndex = 3;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            // 
            // flpProductos
            // 
            this.flpProductos.AutoScroll = true;
            this.flpProductos.BackColor = System.Drawing.Color.White;
            this.flpProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProductos.Location = new System.Drawing.Point(10, 70);
            this.flpProductos.Name = "flpProductos";
            this.flpProductos.Padding = new System.Windows.Forms.Padding(5);
            this.flpProductos.Size = new System.Drawing.Size(530, 480);
            this.flpProductos.TabIndex = 1;

            // 
            // UCNuevaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlCatalogo);
            this.Controls.Add(this.pnlCarrito);
            this.Name = "UCNuevaVenta";
            this.Size = new System.Drawing.Size(800, 560);

            this.pnlCarrito.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.pnlTotales.ResumeLayout(false);
            this.pnlCatalogo.ResumeLayout(false);
            this.pnlFiltro.ResumeLayout(false);
            this.pnlFiltro.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlCarrito;
        private System.Windows.Forms.Label lblTituloCarrito;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Panel pnlTotales;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnProcesarVenta;
        private System.Windows.Forms.Button btnCancelarVenta;
        private System.Windows.Forms.Panel pnlCatalogo;
        private System.Windows.Forms.Panel pnlFiltro;
        private System.Windows.Forms.Label lblTituloCatalogo;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.FlowLayoutPanel flpProductos;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;

        #endregion
    }
}
