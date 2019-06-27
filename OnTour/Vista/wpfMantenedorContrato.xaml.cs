using System;
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

using BibliotecaClases;
using Bibliotecacontrolador;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para wpfMantenedorContrato.xaml
    /// </summary>
    public partial class wpfMantenedorContrato : MetroWindow
    {
        public wpfMantenedorContrato()
        {
            InitializeComponent();
        }

        private void Tile_Click_1_Click(object sender, RoutedEventArgs e)
        {
            wpfAgregarContrato ag = new wpfAgregarContrato();
            ag.Show();
        }

        private void Tile_Click_2_Click(object sender, RoutedEventArgs e)
        {
            wpfModificarContrato mo = new wpfModificarContrato();
            mo.Show();
        }

        private void Tile_Click_3_Click(object sender, RoutedEventArgs e)
        {
            wpfListadoContrato li = new wpfListadoContrato();
            li.Show();
        }

        private void Tile_Click_4_Click(object sender, RoutedEventArgs e)
        {
            wpfEliminarContrato eli = new wpfEliminarContrato();
            eli.Show();
        }
    }
}
