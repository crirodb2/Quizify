using System;

namespace Quizify.Entities
{
    public partial class Pregunta
    {
        public Pregunta(int Id, string Enunciado, int Dificultad, string Autor, string Tema, int ver, string CT)
        {
            ID = Id;
            version = ver;
            enunciado = Enunciado;
            dificultad = Dificultad;
            autor = Autor;
            tema = Tema;
            competenciaT = CT;
        }
        public int GetId()
        {
            return ID;
        }

        public int GetVersion()
        {
            return version;
        }
        public string GetEnunciado()
        {
            return enunciado;
        }
        public int GetDificultad()
        {
            return dificultad;
        }

        public string GetAutor()
        {
            return autor;
        }
        public string GetTipo()
        {
            return tipo;
        }

        public string GetTema()
        {
            return tema;
        }
        public void SetVersion(int ver)
        {
            version = ver;
        }
        public void SetEnunciado(string Enunciado)
        {
            enunciado = Enunciado;
        }
        
        public void SetDificultad(int Dificultad) 
        {
            dificultad = Dificultad;
        }

        public void SetAutor(string Autor)
        {
            autor = Autor;
        }

        public void SetTema(string Tema)
        {
            tema = Tema;
        }
        public void GetTipo(string Tipo)
        {
            this.tipo = Tipo;
        }

        public string GetCT()
        {
            return competenciaT;
        }

        public void SetCT(string CT)
        {
            competenciaT = CT;
        }
    }
}