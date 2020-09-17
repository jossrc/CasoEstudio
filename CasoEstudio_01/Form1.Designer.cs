namespace CasoEstudio_01
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtSumilla = new System.Windows.Forms.TextBox();
            this.txtAñoEdicion = new System.Windows.Forms.TextBox();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.btnRegistrarLibro = new System.Windows.Forms.Button();
            this.dgLibro = new System.Windows.Forms.DataGridView();
            this.colTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAutor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAño = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgLibro)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Titulo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Autor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Año de edición";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sumilla";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Estado";
            // 
            // txtEstado
            // 
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(219, 175);
            this.txtEstado.Multiline = true;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(268, 25);
            this.txtEstado.TabIndex = 8;
            // 
            // txtSumilla
            // 
            this.txtSumilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSumilla.Location = new System.Drawing.Point(219, 221);
            this.txtSumilla.Multiline = true;
            this.txtSumilla.Name = "txtSumilla";
            this.txtSumilla.Size = new System.Drawing.Size(268, 176);
            this.txtSumilla.TabIndex = 9;
            // 
            // txtAñoEdicion
            // 
            this.txtAñoEdicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAñoEdicion.Location = new System.Drawing.Point(219, 125);
            this.txtAñoEdicion.Multiline = true;
            this.txtAñoEdicion.Name = "txtAñoEdicion";
            this.txtAñoEdicion.Size = new System.Drawing.Size(268, 25);
            this.txtAñoEdicion.TabIndex = 10;
            // 
            // txtAutor
            // 
            this.txtAutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAutor.Location = new System.Drawing.Point(219, 77);
            this.txtAutor.Multiline = true;
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(268, 25);
            this.txtAutor.TabIndex = 11;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(219, 24);
            this.txtTitulo.Multiline = true;
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(268, 25);
            this.txtTitulo.TabIndex = 12;
            // 
            // btnRegistrarLibro
            // 
            this.btnRegistrarLibro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarLibro.Location = new System.Drawing.Point(157, 436);
            this.btnRegistrarLibro.Name = "btnRegistrarLibro";
            this.btnRegistrarLibro.Size = new System.Drawing.Size(204, 41);
            this.btnRegistrarLibro.TabIndex = 13;
            this.btnRegistrarLibro.Text = "Registrar Libro";
            this.btnRegistrarLibro.UseVisualStyleBackColor = true;
            this.btnRegistrarLibro.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgLibro
            // 
            this.dgLibro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLibro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTitulo,
            this.colAutor,
            this.colAño,
            this.colEstado});
            this.dgLibro.Location = new System.Drawing.Point(516, 24);
            this.dgLibro.Name = "dgLibro";
            this.dgLibro.Size = new System.Drawing.Size(563, 412);
            this.dgLibro.TabIndex = 14;
            // 
            // colTitulo
            // 
            this.colTitulo.HeaderText = "Título";
            this.colTitulo.Name = "colTitulo";
            this.colTitulo.Width = 150;
            // 
            // colAutor
            // 
            this.colAutor.HeaderText = "Autor";
            this.colAutor.Name = "colAutor";
            this.colAutor.Width = 150;
            // 
            // colAño
            // 
            this.colAño.HeaderText = "Año de Edición";
            this.colAño.Name = "colAño";
            this.colAño.Width = 120;
            // 
            // colEstado
            // 
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 524);
            this.Controls.Add(this.dgLibro);
            this.Controls.Add(this.btnRegistrarLibro);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.txtAutor);
            this.Controls.Add(this.txtAñoEdicion);
            this.Controls.Add(this.txtSumilla);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Registro de Libros";
            ((System.ComponentModel.ISupportInitialize)(this.dgLibro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtSumilla;
        private System.Windows.Forms.TextBox txtAñoEdicion;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Button btnRegistrarLibro;
        private System.Windows.Forms.DataGridView dgLibro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAño;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
    }
}

