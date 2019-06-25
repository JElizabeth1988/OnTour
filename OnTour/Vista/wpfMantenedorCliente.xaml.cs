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


namespace Vista
{
    /// <summary>
    /// Lógica de interacción para wpfMantenedorCliente.xaml
    /// </summary>
    public partial class wpfMantenedorCliente : MetroWindow
    {
        public wpfMantenedorCliente()
        {
            InitializeComponent();
        }

        private void Tile_Click_1_Click(object sender, RoutedEventArgs e)
        {
            wpfAgregarCliente add = new wpfAgregarCliente();
            add.Show(); 
        }

        private void Tile_Click_2_Click(object sender, RoutedEventArgs e)
        {
            wpfModificarCliente mod = new wpfModificarCliente();
            mod.Show();

        }
    }
}
