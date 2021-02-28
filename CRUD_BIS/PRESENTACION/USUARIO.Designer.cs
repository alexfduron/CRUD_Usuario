namespace CRUD_BIS.PRESENTACION
{
    partial class USUARIO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USUARIO));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_linea = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_Buscar = new System.Windows.Forms.TextBox();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_Borrar = new System.Windows.Forms.Button();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 152);
            this.panel1.TabIndex = 0;
            // 
            // panel_linea
            // 
            this.panel_linea.BackColor = System.Drawing.Color.White;
            this.panel_linea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_linea.Location = new System.Drawing.Point(0, 40);
            this.panel_linea.Margin = new System.Windows.Forms.Padding(0);
            this.panel_linea.Name = "panel_linea";
            this.panel_linea.Size = new System.Drawing.Size(387, 5);
            this.panel_linea.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Consolas", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(561, 107);
            this.label1.TabIndex = 1;
            this.label1.Text = "USUARIO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(761, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 152);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel_linea);
            this.panel3.Controls.Add(this.txt_Buscar);
            this.panel3.Controls.Add(this.btn_Buscar);
            this.panel3.Controls.Add(this.btn_Borrar);
            this.panel3.Controls.Add(this.btn_Agregar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(200, 107);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(561, 45);
            this.panel3.TabIndex = 4;
            // 
            // txt_Buscar
            // 
            this.txt_Buscar.BackColor = System.Drawing.Color.Black;
            this.txt_Buscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Buscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.txt_Buscar.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Buscar.ForeColor = System.Drawing.Color.White;
            this.txt_Buscar.Location = new System.Drawing.Point(0, 0);
            this.txt_Buscar.Margin = new System.Windows.Forms.Padding(0);
            this.txt_Buscar.Name = "txt_Buscar";
            this.txt_Buscar.Size = new System.Drawing.Size(387, 40);
            this.txt_Buscar.TabIndex = 4;
            this.txt_Buscar.TextChanged += new System.EventHandler(this.txt_Buscar_TextChanged);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Buscar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Buscar.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Buscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_Buscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Buscar.Image = global::CRUD_BIS.Properties.Resources.buscar_2;
            this.btn_Buscar.Location = new System.Drawing.Point(387, 0);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(58, 45);
            this.btn_Buscar.TabIndex = 5;
            this.btn_Buscar.UseVisualStyleBackColor = false;
            // 
            // btn_Borrar
            // 
            this.btn_Borrar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Borrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Borrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Borrar.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Borrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_Borrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btn_Borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Borrar.Image = global::CRUD_BIS.Properties.Resources.borrador;
            this.btn_Borrar.Location = new System.Drawing.Point(445, 0);
            this.btn_Borrar.Name = "btn_Borrar";
            this.btn_Borrar.Size = new System.Drawing.Size(58, 45);
            this.btn_Borrar.TabIndex = 6;
            this.btn_Borrar.UseVisualStyleBackColor = false;
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Agregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Agregar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Agregar.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Agregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_Agregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MidnightBlue;
            this.btn_Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Agregar.Image = global::CRUD_BIS.Properties.Resources.mas_2;
            this.btn_Agregar.Location = new System.Drawing.Point(503, 0);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(58, 45);
            this.btn_Agregar.TabIndex = 7;
            this.btn_Agregar.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::CRUD_BIS.Properties.Resources.cancelar;
            this.button1.Location = new System.Drawing.Point(100, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 100);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 100);
            this.panel4.TabIndex = 1;
            // 
            // USUARIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(961, 505);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "USUARIO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel_linea;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.TextBox txt_Buscar;
        private System.Windows.Forms.Button btn_Borrar;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
    }
}