using System;
using System.Threading;
using Quizify.Persistence;
using System.Data;

namespace QuizifyIU
{
    public class HiloNotificaciones {

        DALAlumno dalal = new DALAlumno();

        public void HiloGetNotificaciones(string correo, Form1 aux) {
            var threadParameters = new System.Threading.ThreadStart(delegate { 
                while(true) {
                    aux.LlamarDataFetch(dalal.GetNotificaciones(correo));
                    System.Threading.Thread.Sleep(1000);
                } 
            });
            var thread2 = new System.Threading.Thread(threadParameters);
            thread2.Start();
        }
    }
}