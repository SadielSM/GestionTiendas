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
            this.lblUsuarioLogueado = new System.Windows.Forms.Label();
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
            this.btnRefrescarDashboard = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblTituloApp = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsuarioLogueado
            // 
            this.lblUsuarioLogueado.AutoSize = true;
            this.lblUsuarioLogueado.Location = new System.Drawing.Point(585, 89);
            this.lblUsuarioLogueado.Name = "lblUsuarioLogueado";
            this.lblUsuarioLogueado.Size = new System.Drawing.Size(83, 20);
            this.lblUsuarioLogueado.TabIndex = 0;
            this.lblUsuarioLogueado.Text = "Bienvenido";
            // 
            // btnCategorias
            // 
            this.btnCategorias.AutoSize = true;
            this.btnCategorias.Location = new System.Drawing.Point(12, 250);
            this.btnCategorias.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnCategorias.Size = new System.Drawing.Size(123, 38);
            this.btnCategorias.TabIndex = 1;
            this.btnCategorias.Text = "Categorias";
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Location = new System.Drawing.Point(12, 320);
            this.btnProductos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnProductos.Size = new System.Drawing.Size(123, 36);
            this.btnProductos.TabIndex = 2;
            this.btnProductos.Text = "Productos";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Location = new System.Drawing.Point(12, 390);
            this.btnVentas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnVentas.Size = new System.Drawing.Size(123, 38);
            this.btnVentas.TabIndex = 3;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnListadoVentas
            // 
            this.btnListadoVentas.AutoSize = true;
            this.btnListadoVentas.Location = new System.Drawing.Point(12, 458);
            this.btnListadoVentas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnListadoVentas.Name = "btnListadoVentas";
            this.btnListadoVentas.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnListadoVentas.Size = new System.Drawing.Size(145, 45);
            this.btnListadoVentas.TabIndex = 4;
            this.btnListadoVentas.Text = "Listado de Ventas";
            this.btnListadoVentas.UseVisualStyleBackColor = true;
            this.btnListadoVentas.Click += new System.EventHandler(this.btnListadoVentas_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(12, 538);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnClientes.Size = new System.Drawing.Size(123, 40);
            this.btnClientes.TabIndex = 5;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // lblTituloVentasHoy
            // 
            this.lblTituloVentasHoy.AutoSize = true;
            this.lblTituloVentasHoy.Location = new System.Drawing.Point(585, 242);
            this.lblTituloVentasHoy.Name = "lblTituloVentasHoy";
            this.lblTituloVentasHoy.Size = new System.Drawing.Size(108, 20);
            this.lblTituloVentasHoy.TabIndex = 6;
            this.lblTituloVentasHoy.Text = "Ventas de hoy: ";
            // 
            // lblVentasHoy
            // 
            this.lblVentasHoy.AutoSize = true;
            this.lblVentasHoy.Location = new System.Drawing.Point(716, 242);
            this.lblVentasHoy.Name = "lblVentasHoy";
            this.lblVentasHoy.Size = new System.Drawing.Size(44, 20);
            this.lblVentasHoy.TabIndex = 7;
            this.lblVentasHoy.Text = "0.00€";
            // 
            // lblTituloVentasMes
            // 
            this.lblTituloVentasMes.AutoSize = true;
            this.lblTituloVentasMes.Location = new System.Drawing.Point(581, 314);
            this.lblTituloVentasMes.Name = "lblTituloVentasMes";
            this.lblTituloVentasMes.Size = new System.Drawing.Size(111, 20);
            this.lblTituloVentasMes.TabIndex = 8;
            this.lblTituloVentasMes.Text = "Ventas del mes:";
            // 
            // lblVentasMes
            // 
            this.lblVentasMes.AutoSize = true;
            this.lblVentasMes.Location = new System.Drawing.Point(716, 314);
            this.lblVentasMes.Name = "lblVentasMes";
            this.lblVentasMes.Size = new System.Drawing.Size(44, 20);
            this.lblVentasMes.TabIndex = 9;
            this.lblVentasMes.Text = "0.00€";
            // 
            // lblTituloStockBajo
            // 
            this.lblTituloStockBajo.AutoSize = true;
            this.lblTituloStockBajo.Location = new System.Drawing.Point(495, 379);
            this.lblTituloStockBajo.Name = "lblTituloStockBajo";
            this.lblTituloStockBajo.Size = new System.Drawing.Size(214, 20);
            this.lblTituloStockBajo.TabIndex = 10;
            this.lblTituloStockBajo.Text = "Productos con stock bajo (< 5):";
            // 
            // lblStockBajo
            // 
            this.lblStockBajo.AutoSize = true;
            this.lblStockBajo.Location = new System.Drawing.Point(716, 379);
            this.lblStockBajo.Name = "lblStockBajo";
            this.lblStockBajo.Size = new System.Drawing.Size(44, 20);
            this.lblStockBajo.TabIndex = 11;
            this.lblStockBajo.Text = "0.00€";
            // 
            // btnRefrescarDashboard
            // 
            this.btnRefrescarDashboard.AutoSize = true;
            this.btnRefrescarDashboard.Location = new System.Drawing.Point(575, 445);
            this.btnRefrescarDashboard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefrescarDashboard.Name = "btnRefrescarDashboard";
            this.btnRefrescarDashboard.Size = new System.Drawing.Size(140, 32);
            this.btnRefrescarDashboard.TabIndex = 12;
            this.btnRefrescarDashboard.Text = "Refrescar resumen";
            this.btnRefrescarDashboard.UseVisualStyleBackColor = true;
            this.btnRefrescarDashboard.Click += new System.EventHandler(this.btnRefrescarDashboard_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblTituloApp);
            this.panelTop.Controls.Add(this.lblUsuarioLogueado);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1336, 125);
            this.panelTop.TabIndex = 14;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.btnCategorias);
            this.panelLeft.Controls.Add(this.btnProductos);
            this.panelLeft.Controls.Add(this.btnVentas);
            this.panelLeft.Controls.Add(this.btnListadoVentas);
            this.panelLeft.Controls.Add(this.btnClientes);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 125);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(200, 617);
            this.panelLeft.TabIndex = 15;
            // 
            // lblTituloApp
            // 
            this.lblTituloApp.AutoSize = true;
            this.lblTituloApp.Location = new System.Drawing.Point(572, 30);
            this.lblTituloApp.Name = "lblTituloApp";
            this.lblTituloApp.Size = new System.Drawing.Size(127, 20);
            this.lblTituloApp.TabIndex = 1;
            this.lblTituloApp.Text = "Gestor Móvil Chip";
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 742);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.btnRefrescarDashboard);
            this.Controls.Add(this.lblStockBajo);
            this.Controls.Add(this.lblTituloStockBajo);
            this.Controls.Add(this.lblVentasMes);
            this.Controls.Add(this.lblTituloVentasMes);
            this.Controls.Add(this.lblVentasHoy);
            this.Controls.Add(this.lblTituloVentasHoy);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMenuPrincipal";
            this.Activated += new System.EventHandler(this.FormMenuPrincipal_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMenuPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FormMenuPrincipal_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuarioLogueado;
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
        private System.Windows.Forms.Button btnRefrescarDashboard;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblTituloApp;
    }
}