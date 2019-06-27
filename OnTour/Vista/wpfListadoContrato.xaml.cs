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
    /// Lógica de interacción para wpfListadoContrato.xaml
    /// </summary>
    public partial class wpfListadoContrato : MetroWindow
    {
        wpfAgregarContrato con = new wpfAgregarContrato();
        public wpfListadoContrato()
        {
            InitializeComponent();
            try
            {

                DaoContrato dao = new DaoContrato();
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
            DaoContrato dao = new DaoContrato();
            dgLista.ItemsSource = dao.Listar();
            dgLista.Items.Refresh();
        }

        private async void btnFiltrar_Click (object sender, RoutedEventArgs e)
        {
            try
            {

                string rut = txtFiltroRut.Text;

                List<Contrato> lc = new DaoContrato()
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

                string num = txtFiltroNum.Text;

                List<Contrato> lc = new DaoContrato()
                    .FiltroCont(num);
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
    }
}
