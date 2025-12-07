namespace GestorMovilChip
{
    partial class FormMenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnListadoVentas = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.lblTituloVentasHoy = new System.Windows.Forms.Label();
            this.lblVentasHoy = new System.Windows.Forms.Label();
            this.lblTituloVentasMes = new System.Windows.Forms.Label();
            this.lblVentasMes = new System.Windows.Forms.Label();
            this.lblTituloStockBajo = new System.Windows.Forms.Label();
            this.lblStockBajo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Location = new System.Drawing.Point(44, 38);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(75, 16);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Bienvenido";
            // 
            // btnCategorias
            // 
            this.btnCategorias.AutoSize = true;
            this.btnCategorias.Location = new System.Drawing.Point(28, 293);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(123, 30);
            this.btnCategorias.TabIndex = 1;
            this.btnCategorias.Text = "Categorias";
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Location = new System.Drawing.Point(28, 349);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(123, 29);
            this.btnProductos.TabIndex = 2;
            this.btnProductos.Text = "Productos";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Location = new System.Drawing.Point(28, 405);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(123, 30);
            this.btnVentas.TabIndex = 3;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnListadoVentas
            // 
            this.btnListadoVentas.AutoSize = true;
            this.btnListadoVentas.Location = new System.Drawing.Point(28, 459);
            this.btnListadoVentas.Name = "btnListadoVentas";
            this.btnListadoVentas.Size = new System.Drawing.Size(125, 36);
            this.btnListadoVentas.TabIndex = 4;
            this.btnListadoVentas.Text = "Listado de Ventas";
            this.btnListadoVentas.UseVisualStyleBackColor = true;
            this.btnListadoVentas.Click += new System.EventHandler(this.btnListadoVentas_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(28, 523);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(123, 32);
            this.btnClientes.TabIndex = 5;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // lblTituloVentasHoy
            // 
            this.lblTituloVentasHoy.AutoSize = true;
            this.lblTituloVentasHoy.Location = new System.Drawing.Point(462, 38);
            this.lblTituloVentasHoy.Name = "lblTituloVentasHoy";
            this.lblTituloVentasHoy.Size = new System.Drawing.Size(99, 16);
            this.lblTituloVentasHoy.TabIndex = 6;
            this.lblTituloVentasHoy.Text = "Ventas de hoy: ";
            // 
            // lblVentasHoy
            // 
            this.lblVentasHoy.AutoSize = true;
            this.lblVentasHoy.Location = new System.Drawing.Point(593, 38);
            this.lblVentasHoy.Name = "lblVentasHoy";
            this.lblVentasHoy.Size = new System.Drawing.Size(38, 16);
            this.lblVentasHoy.TabIndex = 7;
            this.lblVentasHoy.Text = "0.00€";
            // 
            // lblTituloVentasMes
            // 
            this.lblTituloVentasMes.AutoSize = true;
            this.lblTituloVentasMes.Location = new System.Drawing.Point(458, 95);
            this.lblTituloVentasMes.Name = "lblTituloVentasMes";
            this.lblTituloVentasMes.Size = new System.Drawing.Size(103, 16);
            this.lblTituloVentasMes.TabIndex = 8;
            this.lblTituloVentasMes.Text = "Ventas del mes:";
            // 
            // lblVentasMes
            // 
            this.lblVentasMes.AutoSize = true;
            this.lblVentasMes.Location = new System.Drawing.Point(593, 95);
            this.lblVentasMes.Name = "lblVentasMes";
            this.lblVentasMes.Size = new System.Drawing.Size(38, 16);
            this.lblVentasMes.TabIndex = 9;
            this.lblVentasMes.Text = "0.00€";
            // 
            // lblTituloStockBajo
            // 
            this.lblTituloStockBajo.AutoSize = true;
            this.lblTituloStockBajo.Location = new System.Drawing.Point(372, 147);
            this.lblTituloStockBajo.Name = "lblTituloStockBajo";
            this.lblTituloStockBajo.Size = new System.Drawing.Size(189, 16);
            this.lblTituloStockBajo.TabIndex = 10;
            this.lblTituloStockBajo.Text = "Productos con stock bajo (< 5):";
            // 
            // lblStockBajo
            // 
            this.lblStockBajo.AutoSize = true;
            this.lblStockBajo.Location = new System.Drawing.Point(593, 147);
            this.lblStockBajo.Name = "lblStockBajo";
            this.lblStockBajo.Size = new System.Drawing.Size(38, 16);
            this.lblStockBajo.TabIndex = 11;
            this.lblStockBajo.Text = "0.00€";
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 594);
            this.Controls.Add(this.lblStockBajo);
            this.Controls.Add(this.lblTituloStockBajo);
            this.Controls.Add(this.lblVentasMes);
            this.Controls.Add(this.lblTituloVentasMes);
            this.Controls.Add(this.lblVentasHoy);
            this.Controls.Add(this.lblTituloVentasHoy);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnListadoVentas);
            this.Controls.Add(this.btnVentas);
            this.Controls.Add(this.btnProductos);
            this.Controls.Add(this.btnCategorias);
            this.Controls.Add(this.lblBienvenida);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMenuPrincipal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMenuPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FormMenuPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnListadoVentas;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Label lblTituloVentasHoy;
        private System.Windows.Forms.Label lblVentasHoy;
        private System.Windows.Forms.Label lblTituloVentasMes;
        private System.Windows.Forms.Label lblVentasMes;
        private System.Windows.Forms.Label lblTituloStockBajo;
        private System.Windows.Forms.Label lblStockBajo;
    }
}