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
    /// Lógica de interacción para wpfAgregarContrato.xaml
    /// </summary>
    public partial class wpfAgregarContrato : MetroWindow
    {
        DaoContrato dao;
        public wpfAgregarContrato()
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

            txtNumContrato.Text = DateTime.Now.ToString("yyyyMMddHHmmss");

            dao = new DaoContrato();
        }

        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente c = new DaoCliente().
                    BuscarCliente(txtRut.Text);
                if (c != null)
                {

                    txtRut.Text = c.RutApoderado;
                    txtNombre.Text = c.Nombre + " " + c.ApPaternoApod+" "+ c.ApMaternoApod;
                    txtColegio.Text = c.Establecimiento;
                    txtCurso.Text = c._Curso + " " + c._Letra;
                    

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

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNumContrato.Clear();
            txtNumContrato.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
            txtRut.Clear();
            txtNombre.Clear();
            txtColegio.Clear();
            txtCurso.Clear();
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

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string numero = txtNumContrato.Text;
                string rut=txtRut.Text;
                string nombre=  txtNombre.Text;
                string fecha= dpFecha.Text ;
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

                string curso = txtCurso.Text;
                string colegio = txtColegio.Text;

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
                    Fecha = fecha,
                    act = acti,
                    dest = des,
                    serv = serv,
                    ValorServicio = ValorServ,
                    ValorActividad = ValorAct,
                    ValorTotal = calculo(),
                    seguros = seguro,
                    Curso = curso,
                    Colegio=colegio
                

                };
                bool resp = dao.Agregar(c);
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

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
        public async void Buscar()
        {
            try
            {

                Cliente c = new DaoCliente().BuscarCliente(txtRut.Text);
                if (c != null)
                {
                    //txtRut.Text = c.RutApoderado;
                    txtNombre.Text = c.Nombre + " " + c.ApPaternoApod;
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
