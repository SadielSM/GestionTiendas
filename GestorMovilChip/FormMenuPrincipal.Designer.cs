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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuPrincipal));
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTituloApp = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.tblMainDashboard = new System.Windows.Forms.TableLayoutPanel();
            this.grpUltimasVentas = new System.Windows.Forms.GroupBox();
            this.dgvUltimasVentas = new System.Windows.Forms.DataGridView();
            this.tblDashboard = new System.Windows.Forms.TableLayoutPanel();
            this.panelCardStock = new System.Windows.Forms.Panel();
            this.panelCardMes = new System.Windows.Forms.Panel();
            this.panelCardHoy = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLeft.SuspendLayout();
            this.panelDashboard.SuspendLayout();
            this.tblMainDashboard.SuspendLayout();
            this.grpUltimasVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUltimasVentas)).BeginInit();
            this.tblDashboard.SuspendLayout();
            this.panelCardStock.SuspendLayout();
            this.panelCardMes.SuspendLayout();
            this.panelCardHoy.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsuarioLogueado
            // 
            this.lblUsuarioLogueado.AutoSize = true;
            this.lblUsuarioLogueado.Location = new System.Drawing.Point(107, 85);
            this.lblUsuarioLogueado.Name = "lblUsuarioLogueado";
            this.lblUsuarioLogueado.Size = new System.Drawing.Size(83, 20);
            this.lblUsuarioLogueado.TabIndex = 0;
            this.lblUsuarioLogueado.Text = "Bienvenido";
            // 
            // btnCategorias
            // 
            this.btnCategorias.AutoSize = true;
            this.btnCategorias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategorias.Location = new System.Drawing.Point(0, 179);
            this.btnCategorias.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnCategorias.Size = new System.Drawing.Size(200, 38);
            this.btnCategorias.TabIndex = 1;
            this.btnCategorias.Text = "Categorias";
            this.btnCategorias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.Location = new System.Drawing.Point(0, 103);
            this.btnProductos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnProductos.Size = new System.Drawing.Size(200, 36);
            this.btnProductos.TabIndex = 2;
            this.btnProductos.Text = "Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentas.Location = new System.Drawing.Point(0, 20);
            this.btnVentas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnVentas.Size = new System.Drawing.Size(200, 38);
            this.btnVentas.TabIndex = 3;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnListadoVentas
            // 
            this.btnListadoVentas.AutoSize = true;
            this.btnListadoVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnListadoVentas.Location = new System.Drawing.Point(0, 58);
            this.btnListadoVentas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnListadoVentas.Name = "btnListadoVentas";
            this.btnListadoVentas.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnListadoVentas.Size = new System.Drawing.Size(200, 45);
            this.btnListadoVentas.TabIndex = 4;
            this.btnListadoVentas.Text = "Listado de Ventas";
            this.btnListadoVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListadoVentas.UseVisualStyleBackColor = true;
            this.btnListadoVentas.Click += new System.EventHandler(this.btnListadoVentas_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.Location = new System.Drawing.Point(0, 139);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnClientes.Size = new System.Drawing.Size(200, 40);
            this.btnClientes.TabIndex = 5;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // lblTituloVentasHoy
            // 
            this.lblTituloVentasHoy.AutoSize = true;
            this.lblTituloVentasHoy.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloVentasHoy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloVentasHoy.Location = new System.Drawing.Point(0, 0);
            this.lblTituloVentasHoy.Name = "lblTituloVentasHoy";
            this.lblTituloVentasHoy.Size = new System.Drawing.Size(156, 28);
            this.lblTituloVentasHoy.TabIndex = 6;
            this.lblTituloVentasHoy.Text = "Ventas de hoy: ";
            // 
            // lblVentasHoy
            // 
            this.lblVentasHoy.AutoSize = true;
            this.lblVentasHoy.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVentasHoy.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentasHoy.Location = new System.Drawing.Point(0, 28);
            this.lblVentasHoy.Name = "lblVentasHoy";
            this.lblVentasHoy.Size = new System.Drawing.Size(126, 54);
            this.lblVentasHoy.TabIndex = 7;
            this.lblVentasHoy.Text = "0.00€";
            this.lblVentasHoy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloVentasMes
            // 
            this.lblTituloVentasMes.AutoSize = true;
            this.lblTituloVentasMes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloVentasMes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloVentasMes.Location = new System.Drawing.Point(0, 0);
            this.lblTituloVentasMes.Name = "lblTituloVentasMes";
            this.lblTituloVentasMes.Size = new System.Drawing.Size(159, 28);
            this.lblTituloVentasMes.TabIndex = 8;
            this.lblTituloVentasMes.Text = "Ventas del mes:";
            // 
            // lblVentasMes
            // 
            this.lblVentasMes.AutoSize = true;
            this.lblVentasMes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVentasMes.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentasMes.Location = new System.Drawing.Point(0, 28);
            this.lblVentasMes.Name = "lblVentasMes";
            this.lblVentasMes.Size = new System.Drawing.Size(126, 54);
            this.lblVentasMes.TabIndex = 9;
            this.lblVentasMes.Text = "0.00€";
            // 
            // lblTituloStockBajo
            // 
            this.lblTituloStockBajo.AutoSize = true;
            this.lblTituloStockBajo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloStockBajo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloStockBajo.Location = new System.Drawing.Point(0, 0);
            this.lblTituloStockBajo.Name = "lblTituloStockBajo";
            this.lblTituloStockBajo.Size = new System.Drawing.Size(255, 28);
            this.lblTituloStockBajo.TabIndex = 10;
            this.lblTituloStockBajo.Text = "Productos con stock bajo:";
            // 
            // lblStockBajo
            // 
            this.lblStockBajo.AutoSize = true;
            this.lblStockBajo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStockBajo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockBajo.Location = new System.Drawing.Point(0, 28);
            this.lblStockBajo.Name = "lblStockBajo";
            this.lblStockBajo.Size = new System.Drawing.Size(46, 54);
            this.lblStockBajo.TabIndex = 11;
            this.lblStockBajo.Text = "0";
            // 
            // btnRefrescarDashboard
            // 
            this.btnRefrescarDashboard.AutoSize = true;
            this.btnRefrescarDashboard.Location = new System.Drawing.Point(1172, 73);
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
            this.panelTop.Controls.Add(this.pictureBox1);
            this.panelTop.Controls.Add(this.btnRefrescarDashboard);
            this.panelTop.Controls.Add(this.lblTituloApp);
            this.panelTop.Controls.Add(this.lblUsuarioLogueado);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1336, 125);
            this.panelTop.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EManager.Properties.Resources.logotipo;
            this.pictureBox1.Location = new System.Drawing.Point(13, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // lblTituloApp
            // 
            this.lblTituloApp.AutoSize = true;
            this.lblTituloApp.Location = new System.Drawing.Point(107, 37);
            this.lblTituloApp.Name = "lblTituloApp";
            this.lblTituloApp.Size = new System.Drawing.Size(82, 20);
            this.lblTituloApp.TabIndex = 1;
            this.lblTituloApp.Text = "E-Manager";
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.btnCategorias);
            this.panelLeft.Controls.Add(this.btnClientes);
            this.panelLeft.Controls.Add(this.btnProductos);
            this.panelLeft.Controls.Add(this.btnListadoVentas);
            this.panelLeft.Controls.Add(this.btnVentas);
            this.panelLeft.Controls.Add(this.label1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 125);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(200, 617);
            this.panelLeft.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 6;
            // 
            // panelDashboard
            // 
            this.panelDashboard.Controls.Add(this.tblMainDashboard);
            this.panelDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashboard.Location = new System.Drawing.Point(200, 125);
            this.panelDashboard.Name = "panelDashboard";
            this.panelDashboard.Size = new System.Drawing.Size(1136, 617);
            this.panelDashboard.TabIndex = 16;
            // 
            // tblMainDashboard
            // 
            this.tblMainDashboard.ColumnCount = 1;
            this.tblMainDashboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMainDashboard.Controls.Add(this.grpUltimasVentas, 0, 1);
            this.tblMainDashboard.Controls.Add(this.tblDashboard, 0, 0);
            this.tblMainDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMainDashboard.Location = new System.Drawing.Point(0, 0);
            this.tblMainDashboard.Name = "tblMainDashboard";
            this.tblMainDashboard.RowCount = 2;
            this.tblMainDashboard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tblMainDashboard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMainDashboard.Size = new System.Drawing.Size(1136, 617);
            this.tblMainDashboard.TabIndex = 14;
            // 
            // grpUltimasVentas
            // 
            this.grpUltimasVentas.Controls.Add(this.dgvUltimasVentas);
            this.grpUltimasVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUltimasVentas.Location = new System.Drawing.Point(3, 183);
            this.grpUltimasVentas.Name = "grpUltimasVentas";
            this.grpUltimasVentas.Size = new System.Drawing.Size(1130, 431);
            this.grpUltimasVentas.TabIndex = 10;
            this.grpUltimasVentas.TabStop = false;
            this.grpUltimasVentas.Text = "Últimas ventas";
            // 
            // dgvUltimasVentas
            // 
            this.dgvUltimasVentas.AllowUserToAddRows = false;
            this.dgvUltimasVentas.AllowUserToDeleteRows = false;
            this.dgvUltimasVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUltimasVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUltimasVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUltimasVentas.Location = new System.Drawing.Point(3, 23);
            this.dgvUltimasVentas.Name = "dgvUltimasVentas";
            this.dgvUltimasVentas.ReadOnly = true;
            this.dgvUltimasVentas.RowHeadersVisible = false;
            this.dgvUltimasVentas.RowHeadersWidth = 51;
            this.dgvUltimasVentas.RowTemplate.Height = 24;
            this.dgvUltimasVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUltimasVentas.Size = new System.Drawing.Size(1124, 405);
            this.dgvUltimasVentas.TabIndex = 0;
            // 
            // tblDashboard
            // 
            this.tblDashboard.ColumnCount = 3;
            this.tblDashboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblDashboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblDashboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tblDashboard.Controls.Add(this.panelCardStock, 2, 0);
            this.tblDashboard.Controls.Add(this.panelCardMes, 1, 0);
            this.tblDashboard.Controls.Add(this.panelCardHoy, 0, 0);
            this.tblDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDashboard.Location = new System.Drawing.Point(3, 3);
            this.tblDashboard.Name = "tblDashboard";
            this.tblDashboard.RowCount = 2;
            this.tblDashboard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.4023F));
            this.tblDashboard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.597701F));
            this.tblDashboard.Size = new System.Drawing.Size(1130, 174);
            this.tblDashboard.TabIndex = 13;
            // 
            // panelCardStock
            // 
            this.panelCardStock.Controls.Add(this.lblStockBajo);
            this.panelCardStock.Controls.Add(this.lblTituloStockBajo);
            this.panelCardStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCardStock.Location = new System.Drawing.Point(755, 3);
            this.panelCardStock.Name = "panelCardStock";
            this.panelCardStock.Size = new System.Drawing.Size(372, 160);
            this.panelCardStock.TabIndex = 2;
            // 
            // panelCardMes
            // 
            this.panelCardMes.Controls.Add(this.lblVentasMes);
            this.panelCardMes.Controls.Add(this.lblTituloVentasMes);
            this.panelCardMes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCardMes.Location = new System.Drawing.Point(379, 3);
            this.panelCardMes.Name = "panelCardMes";
            this.panelCardMes.Size = new System.Drawing.Size(370, 160);
            this.panelCardMes.TabIndex = 1;
            // 
            // panelCardHoy
            // 
            this.panelCardHoy.Controls.Add(this.lblVentasHoy);
            this.panelCardHoy.Controls.Add(this.lblTituloVentasHoy);
            this.panelCardHoy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCardHoy.Location = new System.Drawing.Point(3, 3);
            this.panelCardHoy.Name = "panelCardHoy";
            this.panelCardHoy.Size = new System.Drawing.Size(370, 160);
            this.panelCardHoy.TabIndex = 0;
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 742);
            this.Controls.Add(this.panelDashboard);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.Activated += new System.EventHandler(this.FormMenuPrincipal_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMenuPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FormMenuPrincipal_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelDashboard.ResumeLayout(false);
            this.tblMainDashboard.ResumeLayout(false);
            this.grpUltimasVentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUltimasVentas)).EndInit();
            this.tblDashboard.ResumeLayout(false);
            this.panelCardStock.ResumeLayout(false);
            this.panelCardStock.PerformLayout();
            this.panelCardMes.ResumeLayout(false);
            this.panelCardMes.PerformLayout();
            this.panelCardHoy.ResumeLayout(false);
            this.panelCardHoy.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.TableLayoutPanel tblDashboard;
        private System.Windows.Forms.Panel panelCardStock;
        private System.Windows.Forms.Panel panelCardMes;
        private System.Windows.Forms.Panel panelCardHoy;
        private System.Windows.Forms.GroupBox grpUltimasVentas;
        private System.Windows.Forms.DataGridView dgvUltimasVentas;
        private System.Windows.Forms.TableLayoutPanel tblMainDashboard;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}