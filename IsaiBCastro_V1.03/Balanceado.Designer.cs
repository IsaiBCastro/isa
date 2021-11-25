
namespace IsaiBCastro_V1._03
{
    partial class Balanceado
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
            this.lblRecorridos = new System.Windows.Forms.Label();
            this.lblRecorrido = new System.Windows.Forms.Label();
            this.Recorridos = new System.Windows.Forms.ListBox();
            this.gbRecorridos = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnRecorrido = new System.Windows.Forms.Button();
            this.gbEliminar = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Carnet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDatos = new System.Windows.Forms.Button();
            this.txtCarrera = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCarnet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gpbCantidad = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtCantClientes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbRecorridos.SuspendLayout();
            this.gbEliminar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbDatos.SuspendLayout();
            this.gpbCantidad.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRecorridos
            // 
            this.lblRecorridos.AutoSize = true;
            this.lblRecorridos.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecorridos.ForeColor = System.Drawing.Color.Black;
            this.lblRecorridos.Location = new System.Drawing.Point(447, 474);
            this.lblRecorridos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecorridos.Name = "lblRecorridos";
            this.lblRecorridos.Size = new System.Drawing.Size(83, 22);
            this.lblRecorridos.TabIndex = 27;
            this.lblRecorridos.Text = "Recorrido";
            // 
            // lblRecorrido
            // 
            this.lblRecorrido.AutoSize = true;
            this.lblRecorrido.Location = new System.Drawing.Point(358, 464);
            this.lblRecorrido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecorrido.Name = "lblRecorrido";
            this.lblRecorrido.Size = new System.Drawing.Size(0, 17);
            this.lblRecorrido.TabIndex = 26;
            // 
            // Recorridos
            // 
            this.Recorridos.FormattingEnabled = true;
            this.Recorridos.ItemHeight = 16;
            this.Recorridos.Location = new System.Drawing.Point(446, 500);
            this.Recorridos.Margin = new System.Windows.Forms.Padding(4);
            this.Recorridos.Name = "Recorridos";
            this.Recorridos.Size = new System.Drawing.Size(104, 196);
            this.Recorridos.TabIndex = 25;
            // 
            // gbRecorridos
            // 
            this.gbRecorridos.Controls.Add(this.comboBox1);
            this.gbRecorridos.Controls.Add(this.btnRecorrido);
            this.gbRecorridos.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRecorridos.ForeColor = System.Drawing.Color.Black;
            this.gbRecorridos.Location = new System.Drawing.Point(13, 372);
            this.gbRecorridos.Margin = new System.Windows.Forms.Padding(4);
            this.gbRecorridos.Name = "gbRecorridos";
            this.gbRecorridos.Padding = new System.Windows.Forms.Padding(4);
            this.gbRecorridos.Size = new System.Drawing.Size(496, 94);
            this.gbRecorridos.TabIndex = 24;
            this.gbRecorridos.TabStop = false;
            this.gbRecorridos.Text = "Recorridos";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "PreOrden",
            "PosOrden",
            "InOrden"});
            this.comboBox1.Location = new System.Drawing.Point(55, 47);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(177, 29);
            this.comboBox1.TabIndex = 6;
            // 
            // btnRecorrido
            // 
            this.btnRecorrido.ForeColor = System.Drawing.Color.Black;
            this.btnRecorrido.Location = new System.Drawing.Point(287, 39);
            this.btnRecorrido.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecorrido.Name = "btnRecorrido";
            this.btnRecorrido.Size = new System.Drawing.Size(131, 42);
            this.btnRecorrido.TabIndex = 5;
            this.btnRecorrido.Text = "Recorrido";
            this.btnRecorrido.UseVisualStyleBackColor = true;
            this.btnRecorrido.Click += new System.EventHandler(this.btnRecorrido_Click);
            // 
            // gbEliminar
            // 
            this.gbEliminar.Controls.Add(this.label5);
            this.gbEliminar.Controls.Add(this.btnEliminar);
            this.gbEliminar.Controls.Add(this.textBox1);
            this.gbEliminar.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEliminar.ForeColor = System.Drawing.Color.Black;
            this.gbEliminar.Location = new System.Drawing.Point(253, 13);
            this.gbEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.gbEliminar.Name = "gbEliminar";
            this.gbEliminar.Padding = new System.Windows.Forms.Padding(4);
            this.gbEliminar.Size = new System.Drawing.Size(256, 158);
            this.gbEliminar.TabIndex = 23;
            this.gbEliminar.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(32, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ingrese el dato a eliminar:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.ForeColor = System.Drawing.Color.Black;
            this.btnEliminar.Location = new System.Drawing.Point(47, 89);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(156, 43);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(47, 53);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(152, 27);
            this.textBox1.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Carnet,
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(13, 474);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(426, 234);
            this.dataGridView1.TabIndex = 22;
            // 
            // Carnet
            // 
            this.Carnet.HeaderText = "Carnet";
            this.Carnet.MinimumWidth = 6;
            this.Carnet.Name = "Carnet";
            this.Carnet.ReadOnly = true;
            this.Carnet.Width = 125;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Carrera";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Total";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.txtPago);
            this.gbDatos.Controls.Add(this.label6);
            this.gbDatos.Controls.Add(this.btnDatos);
            this.gbDatos.Controls.Add(this.txtCarrera);
            this.gbDatos.Controls.Add(this.label4);
            this.gbDatos.Controls.Add(this.txtCarnet);
            this.gbDatos.Controls.Add(this.label2);
            this.gbDatos.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDatos.ForeColor = System.Drawing.Color.Black;
            this.gbDatos.Location = new System.Drawing.Point(13, 170);
            this.gbDatos.Margin = new System.Windows.Forms.Padding(4);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Padding = new System.Windows.Forms.Padding(4);
            this.gbDatos.Size = new System.Drawing.Size(496, 194);
            this.gbDatos.TabIndex = 21;
            this.gbDatos.TabStop = false;
            // 
            // txtPago
            // 
            this.txtPago.Location = new System.Drawing.Point(240, 74);
            this.txtPago.Margin = new System.Windows.Forms.Padding(4);
            this.txtPago.Name = "txtPago";
            this.txtPago.Size = new System.Drawing.Size(155, 27);
            this.txtPago.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(120, 77);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "Pago Matricula:";
            // 
            // btnDatos
            // 
            this.btnDatos.ForeColor = System.Drawing.Color.Black;
            this.btnDatos.Location = new System.Drawing.Point(63, 126);
            this.btnDatos.Margin = new System.Windows.Forms.Padding(4);
            this.btnDatos.Name = "btnDatos";
            this.btnDatos.Size = new System.Drawing.Size(382, 49);
            this.btnDatos.TabIndex = 3;
            this.btnDatos.Text = "Guardar";
            this.btnDatos.UseVisualStyleBackColor = true;
            this.btnDatos.Click += new System.EventHandler(this.btnDatos_Click);
            // 
            // txtCarrera
            // 
            this.txtCarrera.Location = new System.Drawing.Point(329, 26);
            this.txtCarrera.Margin = new System.Windows.Forms.Padding(4);
            this.txtCarrera.Name = "txtCarrera";
            this.txtCarrera.Size = new System.Drawing.Size(159, 27);
            this.txtCarrera.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(255, 35);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Carrera:";
            // 
            // txtCarnet
            // 
            this.txtCarnet.Location = new System.Drawing.Point(89, 26);
            this.txtCarnet.Margin = new System.Windows.Forms.Padding(4);
            this.txtCarnet.Name = "txtCarnet";
            this.txtCarnet.Size = new System.Drawing.Size(159, 27);
            this.txtCarnet.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Carnet:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(446, 703);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 28);
            this.button1.TabIndex = 28;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gpbCantidad
            // 
            this.gpbCantidad.Controls.Add(this.btnAgregar);
            this.gpbCantidad.Controls.Add(this.txtCantClientes);
            this.gpbCantidad.Controls.Add(this.label1);
            this.gpbCantidad.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbCantidad.ForeColor = System.Drawing.Color.Black;
            this.gpbCantidad.Location = new System.Drawing.Point(21, 13);
            this.gpbCantidad.Margin = new System.Windows.Forms.Padding(4);
            this.gpbCantidad.Name = "gpbCantidad";
            this.gpbCantidad.Padding = new System.Windows.Forms.Padding(4);
            this.gpbCantidad.Size = new System.Drawing.Size(220, 158);
            this.gpbCantidad.TabIndex = 29;
            this.gpbCantidad.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.ForeColor = System.Drawing.Color.Black;
            this.btnAgregar.Location = new System.Drawing.Point(20, 102);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(172, 37);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Aceptar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtCantClientes
            // 
            this.txtCantClientes.Location = new System.Drawing.Point(20, 66);
            this.txtCantClientes.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantClientes.Name = "txtCantClientes";
            this.txtCantClientes.Size = new System.Drawing.Size(171, 27);
            this.txtCantClientes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(25, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cantidad Estudiantes";
            // 
            // Balanceado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.ClientSize = new System.Drawing.Size(1581, 735);
            this.Controls.Add(this.gpbCantidad);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblRecorridos);
            this.Controls.Add(this.lblRecorrido);
            this.Controls.Add(this.Recorridos);
            this.Controls.Add(this.gbRecorridos);
            this.Controls.Add(this.gbEliminar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.gbDatos);
            this.Name = "Balanceado";
            this.Text = "Balanceado";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Balanceado_Paint);
            this.gbRecorridos.ResumeLayout(false);
            this.gbEliminar.ResumeLayout(false);
            this.gbEliminar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.gpbCantidad.ResumeLayout(false);
            this.gpbCantidad.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecorridos;
        private System.Windows.Forms.Label lblRecorrido;
        private System.Windows.Forms.ListBox Recorridos;
        private System.Windows.Forms.GroupBox gbRecorridos;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnRecorrido;
        private System.Windows.Forms.GroupBox gbEliminar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Carnet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.TextBox txtPago;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDatos;
        private System.Windows.Forms.TextBox txtCarrera;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCarnet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gpbCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtCantClientes;
        private System.Windows.Forms.Label label1;
    }
}