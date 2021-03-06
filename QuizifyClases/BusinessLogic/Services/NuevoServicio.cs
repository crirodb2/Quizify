using System;
using System.Collections.Generic;
using Quizify.Entities;
using Quizify.Persistence;
using System.Data;
using Quizify;

namespace Quizify.Services
{
    public class NuevoServicio {
        DALAlumno alumno = new DALAlumno();
        DALProfesor profesor = new DALProfesor();
        DALPregunta pregunta = new DALPregunta();
        DALExamen examen = new DALExamen();
        DALCurso curso = new DALCurso();
        Hilos hilos = new Hilos();
        Fachada fachada = new Fachada();

        private static NuevoServicio service;
        public static NuevoServicio getServicio()
        {
            if (service == null) service = new NuevoServicio();
            return service;
        }

        //Métodos Alumno
        public void AddAlumno(Alumno al) {
            try { alumno.Add(al); } 
            catch(MySql.Data.MySqlClient.MySqlException) { throw new Exception("Este alumno ya existe."); }
        }
        public Alumno GetAlumno(string id) {
            Alumno al = alumno.Get(id);
            if(al is null) { throw new Exception("Este alumno no existe."); }
            return al;
        }
        public void EliminarAlumno(string id){
            alumno.Eliminar(id);
        }
        public (DataTable, DataTable) GetExamenesAlumno (string al) {
            return fachada.GetExamenesAlumno(al);
        }
        public void EliminarNotificacion(int id_notif, string correo) {
            alumno.EliminarNotificacion(id_notif,correo);
        }

        public (DataTable, DataTable) GetExamenesByDificultadAlumno(string al, string dificultad)
        {
            return alumno.GetExamenesByDificultadAlumno(al, dificultad);
        }

        //Métodos Profesor
        public void AddProfesor(Profesor prof) {
            try { profesor.Add(prof); } 
            catch(MySql.Data.MySqlClient.MySqlException) { throw new Exception("Este profesor ya existe."); }
        }
        public Profesor GetProfesor(string id) {
            Profesor prof = profesor.Get(id);
            if(prof is null) { throw new Exception("Este profesor no existe."); }
            return prof;
        }
        public void EliminarProfesor(string id){
            profesor.Eliminar(id);
        }
        public DataTable GetExamenesProfesor(string prof) {
            return fachada.GetExamenesProfesor(prof);
        }
        public void EnviarMensaje(string mensaje, string curso, string prof) {
            profesor.EnviarMensaje(curso,prof,mensaje);
        }
        public void AlterarBonos(string id, int bonos)
        {
            profesor.AlterarBonos(id, bonos);
        }

        //Métodos Curso
        public void AddCurso(Curso cur) {
            try { curso.Add(cur); } 
            catch(MySql.Data.MySqlClient.MySqlException ex) { 
                if(ex.Number == 1062) { throw new Exception("Este curso ya existe."); }
                if(ex.Number == 1452) { throw new Exception("Ese profesor no existe."); }
                else { throw new Exception("Error de integridad, código: " + ex.Number); }
            }
        }
        public Curso GetCurso(string id, string autor) {
            Curso cur = curso.Get(id, autor);
            if(cur is null) { throw new Exception("Este curso no existe o no es impartido por el profesor seleccionado."); }
            return cur;
        }
        public void AddAlumnoACurso(string al, string cur, string prof) {
            try { curso.AddAlumnoACurso(al,cur,prof); }
            catch(MySql.Data.MySqlClient.MySqlException ex) { throw new Exception("El alumno seleccionado ya está en este curso, o el curso no existe" + ex.Message.ToString()); }
            catch(InvalidOperationException) { throw new Exception("Ese curso está lleno"); }
        }
        public void EliminarAlumnoDeCurso(string al, string cur, string prof) {
            curso.EliminarAlumnoDeCurso(al,cur,prof);
        }
        public List<string> GetCursosAlumno(string id) {
            return curso.GetCursosAlumno(id);
        }
        public List<string> GetCursosProfesor(string id) {
            return curso.GetCursosProfesor(id);
        }
        public List<string> GetAlumnosDeCurso(string cur, string prof) {
            return curso.GetAlumnosDeCurso(cur,prof);
        }
        public void EliminarCurso(string cur, string prof)
        {
            curso.Eliminar(cur, prof);
        }
        public void BorrarseDeCurso(string alumno, string codigo_curso, string profesor) {
            curso.BorrarseDeCurso(alumno, codigo_curso, profesor);
        }

        //Métodos pregunta
        public void AddPregunta(Pregunta2 preg) {
            try { pregunta.Add(preg); } 
            catch(MySql.Data.MySqlClient.MySqlException ex) { 
                if(ex.Number == 1062) { throw new Exception("Esta pregunta ya existe."); }
                else { throw new Exception("Error crítico, código: " + ex.Number); }
            }
        }
        public Pregunta2 GetPregunta(int id, int ver) {
            try { return pregunta.Get(id, ver); }
            catch(MySql.Data.MySqlClient.MySqlException) { throw new Exception("Esta pregunta no existe"); }
        }
        public void EliminarPregunta(int id, int ver) {
            pregunta.Eliminar(id, ver);
        }
        public DataTable GetPreguntas(List<dynamic> filtros) {
            return pregunta.GetPreguntas(filtros); 
        }
        public int UltimoIdPregunta() {
            return pregunta.UltimoIdPregunta();
        }
        public int UltimaVersionPregunta(int id) {
            return pregunta.UltimaVerPregunta(id);
        }

        //Métodos examen
        public void AddExamen(Examen exam) {
            try { examen.Add(exam); } 
            catch(MySql.Data.MySqlClient.MySqlException ex) { 
                if(ex.Number == 1062) { throw new Exception("Este examen ya existe."); }
                if(ex.Number == 1452) { throw new Exception("Ese profesor no existe."); }
                else { throw new Exception("Error de integridad, código: " + ex.Number); }
            }
        }
        public Examen GetExamen(int id) {
            Examen exam = examen.Get(id);
            if(exam is null) { throw new Exception("Este examen no existe."); }
            return exam;
        }
        public int UltimoIdExamen() {
            return examen.UltimoIdExamen();
        }
        public void SubirRespuestas(List<dynamic> respuestas) {
            try { examen.SubirRespuestas(respuestas); }
            catch(MySql.Data.MySqlClient.MySqlException ex) { throw new Exception("Error de integridad, código: " + ex.Number); }
        }
        public void AnularPregunta(int id_ex, int id_preg) {
            examen.AnularPregunta(id_ex,id_preg);
        }
        public void ActualizarEstadoQuizes() {
            examen.ActualizarEstadoQuizes();
        }
        public void PublicarNotas(int ex_id) {
            examen.PublicarNotas(ex_id);
        }
        public double GetNota(string id_alumno, int id_ex) {
            return examen.GetNota(id_alumno,id_ex);
        }
        public double GetPuntuacionDePregunta(int id_ex, int id_preg) {
            return examen.GetPuntuacionDePregunta(id_ex, id_preg);
        }
        public void GenerarExamen(string profesor, string codigo_curso, int num_preguntas, int tiempo, DateTime fechaini, DateTime fechafin,
        int intentos, int volveratras, int erroresrestan, int mostrarresultados, bool esrecu, string dific) {
            try {
                fachada.GenerarExamen(profesor, codigo_curso, num_preguntas, tiempo, fechaini, fechafin, intentos, 
                volveratras, erroresrestan, mostrarresultados, esrecu, dific);
            } catch(Exception e) { throw new Exception(e.ToString()); }
        }
        public List<dynamic> EstadisticasExamen(int id_ex) {
            return examen.EstadisticasExamen(id_ex);
        } //devuelve {nº envios, nota media, desviación típica, Lista con las notas}
        public void CancelarExamen(int id) {
            examen.Eliminar(id);
        }
        public void FinalizarExamen(int id) {
            examen.FinalizarExamen(id);
        }
        public void CalcularNotaExamen(int id_ex, string correo) {
            fachada.CalcularNotaExamen(id_ex, correo);
        }
        public DataTable GetExamenByDificultad(List<dynamic> filtros)
        {
            return examen.GetExamenesByDificultad(filtros);
        }
        public void EliminarPreguntaDeExamen(int id_ex, int id_preg) {
            examen.EliminarPreguntaDeExamen(id_ex,id_preg);
        }
        public DataTable EstadisticasExamenPreguntas(int id_ex) {
            return fachada.EstadisticasExamenPreguntas(id_ex);
        }
        public DataTable GetPreguntasDesarrolloExamen(int id_ex) {
            return examen.GetPreguntasDesarrolloExamen(id_ex);
        }
        public void CalificarDesarrollo(int id_ex, int id_preg, int ver_preg, string alumno, double nota) {
            examen.CalificarDesarrollo(id_ex, id_preg, ver_preg, alumno, nota);
        }
        public double GetNotaPregunta(int id_ex, int id_preg, string alumno) {
            return examen.GetNotaPregunta(id_ex,id_preg,alumno);
        }

        //Otros métodos
        public string GetTipoEntidad(string usuario) {
            try { 
                GetAlumno(usuario); 
                return "alumno"; 
            }
            catch(Exception) { 
                try { GetProfesor(usuario); return "profesor"; }
                catch(Exception e) { throw new Exception(e.ToString()); }    
            }
        }
        public DataTable GetAllAlumnos() {
            return alumno.GetAllAlumnos();
        }
        public void HiloEstadoQuizes() {
            hilos.HiloEstadoQuizes();
        }
    }   
}