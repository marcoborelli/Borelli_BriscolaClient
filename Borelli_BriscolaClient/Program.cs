﻿using System;
using System.Windows.Forms;
using Borelli_BriscolaClient.view;

namespace Borelli_BriscolaClient {
    internal static class Program {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
