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
    /// Lógica de interacción para wpfModificarContrato.xaml
    /// </summary>
    public partial class wpfModificarContrato : MetroWindow
    {
        DaoContrato dao;
        public wpfModificarContrato()
        {
            InitializeComponent();
            //llenar el combo box con los datos del enumerador
            cboActividad.ItemsSource = Enum.GetValues(typeof
                (Actividad));
            this.cboActividad.SelectedItem = null;

            //llenar el combo box con los datos del enumerador
            cboDestino.ItemsSource = Enum.GetValues(typeof
                (Destino));
            this.cboDestino.SelectedItem = null;

            //llenar el combo box con los datos del enumerador
            cboServicio.ItemsSource = Enum.GetValues(typeof
                (Servicio));
            this.cboServicio.SelectedItem = null;

            cboServicio.SelectedIndex = 0;
            cboDestino.SelectedIndex = 0;
            cboActividad.SelectedIndex = 0;

            dao = new DaoContrato();

        }

        private async void btnBuscarCont_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contrato c = new DaoContrato().
                    Buscar(txtNumContrato.Text);
                if (c != null)
                {
                    txtNumContrato.Text = c.NumeroContrato;
                    txtRut.Text = c.RutCliente;
                    txtNombre.Text = c.Nombre;
                    txtColegio.Text = c.Colegio;
                    txtCurso.Text = c.Curso;
                    dpFecha.Text = c.Fecha;
                    cboActividad.Text = c.act.ToString();
                    cboDestino.Text = c.dest.ToString();
                    cboServicio.Text = c.serv.ToString();
                    txtValorSer.Text = c.ValorServicio.ToString();
                    txtValorAct.Text = c.ValorActividad.ToString();
                    txtTotal.Text = c.ValorTotal.ToString();
                    if (c.seguros == "Si")
                    {
                        rbsi.IsChecked = true;
                        rbNo.IsChecked = false;
                    }

                    if (c.seguros == "No")
                    {
                        rbNo.IsChecked = true;
                        rbsi.IsChecked = false;
                    }
                    txtRut.IsEnabled = false;
                    txtNumContrato.IsEnabled = false;

                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                      string.Format("No se encontraron resultados!"));
                    /*MessageBox.Show("No se encontraron resultados!");*/
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error al Buscar Información"));
                /*MessageBox.Show("error al buscar");*/
                Logger.Mensaje(ex.Message);


            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNumContrato.Clear();
            txtNumContrato.IsEnabled = true;
            txtRut.Clear();
            txtNumContrato.IsEnabled = true;
            txtCurso.Clear();
            txtColegio.Clear();
            txtNombre.Clear();
            dpFecha.SelectedDate = null;
            cboActividad.SelectedIndex = 0;
            cboDestino.SelectedIndex = 0;
            cboServicio.SelectedIndex = 0;
            txtValorSer.Clear();
            txtValorAct.Clear();
            txtTotal.Clear();
            rbsi.IsChecked = true;
            rbNo.IsChecked = false;


            txtNumContrato.Focus();//Mover el cursor a la poscición num

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contrato c = new DaoContrato().
                    BuscarRut(txtRut.Text);
                if (c != null)
                {
                    txtNumContrato.Text = c.NumeroContrato;
                    txtRut.Text= c.RutCliente;
                    txtNombre.Text = c.Nombre;
                    txtColegio.Text = c.Colegio;
                    txtCurso.Text = c.Curso;
                    dpFecha.Text = c.Fecha;
                    cboActividad.Text = c.act.ToString();
                    cboDestino.Text = c.dest.ToString();
                    cboServicio.Text = c.serv.ToString();
                    txtValorSer.Text = c.ValorServicio.ToString();
                    txtValorAct.Text = c.ValorActividad.ToString();
                    txtTotal.Text = c.ValorTotal.ToString();
                    if (c.seguros == "Si")
                    {
                        rbsi.IsChecked = true;
                        rbNo.IsChecked = false;
                    }

                    if (c.seguros == "No")
                    {
                        rbNo.IsChecked = true;
                        rbsi.IsChecked = false;
                    }
                    txtRut.IsEnabled = false;
                    txtNumContrato.IsEnabled = false;

                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                      string.Format("No se encontraron resultados!"));
                    /*MessageBox.Show("No se encontraron resultados!");*/
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error al Buscar Información"));
                /*MessageBox.Show("error al buscar");*/
                Logger.Mensaje(ex.Message);


            }
        }


        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string numero = txtNumContrato.Text;
                string rut = txtRut.Text;
                string nombre = txtNombre.Text;
                string fecha = dpFecha.Text;
                string colegio = txtColegio.Text;
                string curso = txtCurso.Text;
                Actividad acti = (Actividad)cboActividad.SelectedItem;
                Destino des = (Destino)cboDestino.SelectedItem;
                Servicio serv = (Servicio)cboServicio.SelectedItem;
                //int valorServ = int.Parse(txtValorSer.Text);
                int ValorServ = 0;
                if (int.TryParse(txtValorSer.Text, out ValorServ))
                {

                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                      string.Format("Ingrese sólo valores numéricos"));
                    txtValorSer.Focus();
                    return;
                }
                // int valorAct = int.Parse(txtValorAct.Text);
                int ValorAct = 0;
                if (int.TryParse(txtValorAct.Text, out ValorAct))
                {

                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                      string.Format("Ingrese sólo valores numéricos"));
                    txtValorAct.Focus();
                    return;
                }
                int valorc = int.Parse(txtTotal.Text);

                string seguro;
                if (rbsi.IsChecked == true)
                {
                    seguro = "Si";
                }
                else
                {
                    seguro = "No";

                }
                Contrato c = new Contrato()
                {
                    NumeroContrato = numero,
                    RutCliente = rut,
                    Nombre = nombre,
                    Colegio= colegio,
                    Curso= curso,
                    Fecha = fecha,
                    act = acti,
                    dest = des,
                    serv = serv,
                    ValorServicio = ValorServ,
                    ValorActividad = ValorAct,
                    ValorTotal = calculo(),
                    seguros = seguro


                };
                bool resp = dao.Modificar(c);
                await this.ShowMessageAsync("Mensaje:",
                      string.Format(resp ? "Guardado" : "No Guardado"));
                /*MessageBox.Show(resp ? "Guardado" : "No Guardado");*/

            }
            catch (ArgumentException exa)//mensajes de reglas de negocios
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format((exa.Message)));
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error de ingreso de datos"));
                /*MessageBox.Show("Error de ingreso de datos");*/
                Logger.Mensaje(ex.Message);

            }

        }

        //METODO CALCULO
        public int calculo()
        {

            int valorc = int.Parse(txtValorAct.Text)
            + int.Parse(txtValorSer.Text);


            return valorc;
        }


        //BOTON CALCULO CONTRATO

        private async void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                txtTotal.Text = calculo().ToString();
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Debe ingresar valor de asistentes"));
                Logger.Mensaje(ex.Message);
            }

        }
    }
}
