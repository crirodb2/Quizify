﻿using Quizify.Entities;
using Quizify.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuizifyIU
{
    public partial class GestionarCurso : Form
    {
        private NuevoServicio servicio;
        private dynamic usuario;
        GestionarAlumnosCurso formGestionarAl;
        public GestionarCurso(NuevoServicio servicio, dynamic user)
        {
            InitializeComponent();
            this.servicio = servicio;
            usuario = user;

            actualizarTabla();
        }

        private void bVolver_Click(object sender, EventArgs e)
        {
            AbrirFormCurso(new CursoForm(servicio, usuario));
        }

        private void AbrirFormCurso(object formCurso)
        {
            if (this.panelGestionarCurso.Controls.Count > 0)
                this.panelGestionarCurso.Controls.RemoveAt(0);
            Form fC = formCurso as Form;
            fC.TopLevel = false;
            fC.Dock = DockStyle.Fill;
            this.panelGestionarCurso.Controls.Add(fC);
            this.panelGestionarCurso.Tag = fC;
            fC.BringToFront();
            fC.Show();
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            EliminarCurso();
            actualizarTabla();
        }

        private void bAñadir_Click(object sender, EventArgs e)
        {
            profeAñadeAlumno();
        }

        private void profeAñadeAlumno()
        {
            try
            {
                string curso = tablaDatoCurso.SelectedRows[0].Cells["Código"].Value.ToString();
                string alumno = alumnoBox.Text;
                string profesor = usuario.nombre;
                Alumno al = servicio.GetAlumno(alumno); //Si no existe el alunmo, lanza la excepcion
                servicio.AddAlumnoACurso(curso, alumno, profesor);
                Curso objCurso = servicio.GetCurso(curso, profesor);
                objCurso.GetListaAlumnos().Add(curso);
            } catch (Exception ex)
            {
                DialogResult aviso = MessageBox.Show(this, ex.Message.ToString(),
                                                          "Error", MessageBoxButtons.OK,
                                                          MessageBoxIcon.Error); return;
            }
        }

        private void EliminarCurso()
        {/*
            string curso = tablaDatoCurso.SelectedRows[0].Cells["Código"].Value.ToString();
            string profesor = usuario.nombre;
            DialogResult avisoBorrarCurso = MessageBox.Show(this, "¿Estás seguro de que quieres borrar este curso?",
                                                          "Borrar curso", MessageBoxButtons.OK,
                                                          MessageBoxIcon.Question);
            if (avisoBorrarCurso == DialogResult.OK) { 
                servicio.EliminarCurso(curso, profesor);
                actualizarTabla();
            }*/
        }

        private void tablaCurso_doble_click(object sender, DataGridViewCellEventArgs e)
        {
            string codCurso = tablaDatoCurso.SelectedRows[0].Cells["Código"].Value.ToString();
            string profe = usuario.correo;
            Curso curso = servicio.GetCurso(codCurso, profe);
            formGestionarAl = new GestionarAlumnosCurso(servicio, formGestionarAl, curso, usuario);
            formGestionarAl.ShowDialog();
        }

        private void actualizarTabla()
        {
            try
            {
                BindingList<object> bindingListMisCursos = new BindingList<object>();

                List<string> lista = servicio.GetCursosProfesor(usuario.correo);

                foreach (string x in lista)
                {
                    Curso cu = servicio.GetCurso(x, usuario.correo);

                    bindingListMisCursos.Add(new
                    {
                        cod = cu.GetCodigo(),
                        nombre = cu.GetNombre(),
                        numAl = cu.GetNumAlumnos(),
                        fechaCreado = cu.GetFechaCreacion()
                    }); ;

                }
                tablaDatoCurso.DataSource = bindingListMisCursos;
            } catch(Exception ex)
            {
                DialogResult aviso = MessageBox.Show(this, ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
        }
    }
}
