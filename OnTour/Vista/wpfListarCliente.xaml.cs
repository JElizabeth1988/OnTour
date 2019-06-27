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
    /// Lógica de interacción para wpfListarCliente.xaml
    /// </summary>
    public partial class wpfListarCliente : MetroWindow 
    {
        Cliente cl = new Cliente();
        public wpfListarCliente()
        {
            InitializeComponent();

            cbCom.ItemsSource = Enum.GetValues(typeof
              (Comuna));
            this.cbCom.SelectedItem = null;
            try
            {

                DaoCliente dao = new DaoCliente();
                dgLista.ItemsSource = dao.Listar();
                dgLista.Items.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error!" + ex.Message);
                Logger.Mensaje(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            DaoCliente dao = new DaoCliente();
            dgLista.ItemsSource = dao.Listar();
            dgLista.Items.Refresh();
        }

        private async void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                string rut = txtFiltroRut.Text;

                List<Cliente> lc = new DaoCliente()
                    .FiltroRut(rut);
                dgLista.ItemsSource = lc;
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al filtrar la Información"));
                /*MessageBox.Show("error al Filtrar Información");*/
                Logger.Mensaje(ex.Message);

                dgLista.Items.Refresh();
            }
        }

        private async void btnFiltrarTipo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Comuna com = (Comuna)cbCom.SelectedItem;
                List<Cliente> lf = new DaoCliente()
                    .FiltroEmp(com);
                dgLista.ItemsSource = lf;
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error al filtrar la Información"));
                /*MessageBox.Show("error al Filtrar Información");*/
                Logger.Mensaje(ex.Message);
                dgLista.Items.Refresh();
            }
        }
    
    }
}
