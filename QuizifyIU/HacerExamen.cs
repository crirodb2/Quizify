﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Quizify.Entities;
using Quizify.Services;

namespace QuizifyIU
{
    public partial class HacerExamen : Form
    {
        private Servicio servicio;
        public HacerExamen(Servicio servicio)
        {
            InitializeComponent();
            this.servicio = servicio;
        }
    }
}
