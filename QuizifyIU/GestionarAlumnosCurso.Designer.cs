﻿namespace QuizifyIU
{
    partial class GestionarAlumnosCurso
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
            this.tablaAlumnoCurso = new System.Windows.Forms.DataGridView();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaAlumnoCurso)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaAlumnoCurso
            // 
            this.tablaAlumnoCurso.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.tablaAlumnoCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaAlumnoCurso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Correo,
            this.Nombre,
            this.Apellidos});
            this.tablaAlumnoCurso.Location = new System.Drawing.Point(66, 61);
            this.tablaAlumnoCurso.MultiSelect = false;
            this.tablaAlumnoCurso.Name = "tablaAlumnoCurso";
            this.tablaAlumnoCurso.RowHeadersVisible = false;
            this.tablaAlumnoCurso.RowTemplate.Height = 25;
            this.tablaAlumnoCurso.Size = new System.Drawing.Size(414, 186);
            this.tablaAlumnoCurso.TabIndex = 0;
            // 
            // Correo
            // 
            this.Correo.HeaderText = "Correo";
            this.Correo.Name = "Correo";
            this.Correo.Width = 150;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 110;
            // 
            // Apellidos
            // 
            this.Apellidos.HeaderText = "Apellidos";
            this.Apellidos.Name = "Apellidos";
            this.Apellidos.Width = 150;
            // 
            // bEliminar
            // 
            this.bEliminar.Location = new System.Drawing.Point(405, 274);
            this.bEliminar.Name = "bEliminar";
            this.bEliminar.Size = new System.Drawing.Size(75, 23);
            this.bEliminar.TabIndex = 2;
            this.bEliminar.Text = "Eliminar";
            this.bEliminar.UseVisualStyleBackColor = true;
            this.bEliminar.Click += new System.EventHandler(this.bEliminar_Click);
            // 
            // GestionarAlumnosCurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 312);
            this.Controls.Add(this.bEliminar);
            this.Controls.Add(this.tablaAlumnoCurso);
            this.Name = "GestionarAlumnosCurso";
            this.Text = "GestionarAlumnosCurso";
            ((System.ComponentModel.ISupportInitialize)(this.tablaAlumnoCurso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaAlumnoCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellidos;
        private System.Windows.Forms.Button bEliminar;
    }
}