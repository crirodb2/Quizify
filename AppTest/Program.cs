﻿using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Quizify.Entities;
using Quizify.Persistence;
using System.Globalization;
using Quizify.Services;

namespace AppTest {
    class Program {
        
        static void Main(string[] args) {

            DALAlumno alumno = new DALAlumno();
            DALProfesor profesor = new DALProfesor();
            DALPregunta pregunta = new DALPregunta();
            DALExamen examen = new DALExamen();
            DALCurso curso = new DALCurso();

            NuevoServicio service = new NuevoServicio();

            int x = examen.UltimoIdExamen()+1;
            Examen Calificado = new Examen(9, "demo", "demo", "demo", "anton@gmail.com", 50, 
            DateTime.Now, DateTime.Now, DateTime.Now.AddDays(1), 1, 1, 1, 1, examen.GetListaPreguntas(0), "", "demo");

            service.AddExamen(Calificado);
        }
    }
}