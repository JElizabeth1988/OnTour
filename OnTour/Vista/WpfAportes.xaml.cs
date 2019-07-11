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
    /// Lógica de interacción para WpfAportes.xaml
    /// </summary>
    public partial class WpfAportes : MetroWindow
    {
        DaoAporte dao;
        public WpfAportes()
        {
            InitializeComponent();
            dao = new DaoAporte();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //METODO CALCULO
        public int calculo()
        {

            int valorfalta = int.Parse(labelTotal.Content.ToString()) - int.Parse(txtAporte.Text);
            
            return valorfalta;
        }


        //BOTON CALCULO CONTRATO

        private async void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                txtSaldo.Text = calculo().ToString();
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Debe ingresar valor "));
                Logger.Mensaje(ex.Message);
            }

        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string rut = txtRut.Text;
                string nombre = labelNombre.Content.ToString();
                string cole = labelColegio.Content.ToString();
                string curso = labelCurso.Content.ToString();
                string acti = labelActividad.Content.ToString();
                string segu = labelSeguro.Content.ToString();
                string servi = labelServicio.Content.ToString();
                string des = label_Destino.Content.ToString();
                int total = int.Parse(labelTotal.Content.ToString());
                int saldo = calculo();

                Aporte c = new Aporte()
                {
                    RutApoderado = rut,
                    Nombre = nombre,
                    Establecimiento = cole,
                    curso = curso,
                    act = acti,
                    seguros = segu,
                    serv = servi,
                    dest = des,
                    ValorTotal =total,
                    //apEfectuado = int.Parse(txtAporteEfectuado.Text),
                   // aporteNuevo = int.Parse(txtAporte.Text),
                    Saldo = saldo

                };
                bool resp = dao.Agregar(c);
                await this.ShowMessageAsync("Mensaje:",
                      string.Format(resp ? "Guardado" : "No Guardado"));
                /*MessageBox.Show(resp ? "Guardado" : "No Guardado");*/

            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error de ingreso de datos"));
                /*MessageBox.Show("Error de ingreso de datos");*/
                Logger.Mensaje(ex.Message);

            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtRut.Clear();
            labelNombre.Content = string.Empty;
            labelColegio.Content = string.Empty;
            labelCurso.Content = string.Empty;
            labelActividad.Content = string.Empty;
            labelSeguro.Content = string.Empty;
            labelServicio.Content = string.Empty;
            label_Destino.Content = string.Empty;
            labelTotal.Content = string.Empty;
            txtAporte.Clear();
            //txtAporteEfectuado.Clear();
            txtSaldo.Clear();
        }

        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contrato c = new DaoContrato().
                    BuscarRut(txtRut.Text);
                if (c != null)
                {

                    txtRut.Text = c.RutCliente;
                    labelNombre.Content = c.Nombre;
                    labelColegio.Content = c.Colegio;
                    labelCurso.Content = c.Curso;
                    labelActividad.Content = c.act;
                    labelSeguro.Content = c.seguros;
                    labelServicio.Content = c.serv;
                    label_Destino.Content = c.dest;
                    labelTotal.Content = c.ValorTotal;

                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                     string.Format("Cliente no encontrado"));
                    /*MessageBox.Show("Cliente no Encontrado");*/
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al Buscar"));
                /*MessageBox.Show("Error al buscar");*/
                Logger.Mensaje(ex.Message);

            }
        }
    }
}
