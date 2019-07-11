﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using Bibliotecacontrolador;
namespace Vista
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        public Login()
        {
            InitializeComponent();
            txtUsuario.Focus();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtUsuario.Text == "admin" && pbContrasenia.Password == "admin")
                {
                    await this.ShowMessageAsync("Mensaje:",
                         string.Format("Bienvenido!"));
                    MainWindow _ver = new MainWindow();
                    this.Close();
                    _ver.ShowDialog();
                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                                         string.Format("Datos Inorrectos!"));
                }
            }
            catch (Exception ex)
            {

                Logger.Mensaje(ex.Message);
            }
            
        }
    }
}
