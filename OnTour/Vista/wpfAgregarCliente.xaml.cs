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
    /// Lógica de interacción para wpfCliente.xaml
    /// </summary>
    public partial class wpfAgregarCliente : MetroWindow
    {
        DaoCliente dao;
       
        public wpfAgregarCliente()
        {
            InitializeComponent();
            txtDV.IsEnabled = false;

            //llenar el combo box con los datos del enumerador
            cboComuna.ItemsSource = Enum.GetValues(typeof
                (Comuna));
            this.cboComuna.SelectedItem = null;

            //llenar el combo box con los datos del enumerador
            cboCurso.ItemsSource = Enum.GetValues(typeof
                (Curso));
            this.cboCurso.SelectedItem = null;

            //llenar el combo box con los datos del enumerador
            cboCursoLetra.ItemsSource = Enum.GetValues(typeof
                (Letra));
            this.cboCursoLetra.SelectedItem = null;

            

            dao = new DaoCliente();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtDV.Clear();
            txtRut.Clear();
            txtRut.IsEnabled = true;
            txtApMaterno.Clear();
            txtNombre.Clear();
            txtApPaterno.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEstablecimiento.Clear();
            cboComuna.SelectedIndex = 0;
            cboCurso.SelectedIndex = 0;
            cboCursoLetra.SelectedIndex = 0;
            txtRut_alumno.Clear();
            txtDV_alumno.Clear();
            txtNombre_alumno.Clear();
            rbsi.IsChecked = true;
            rbNo.IsChecked = false;
       
            txtRut_alumno.IsEnabled = true;
            txtNombre_alumno.IsEnabled = true;

            txtRut.Focus();//Mover el cursor a la poscición Rut

        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String rut = txtRut.Text + "-" + txtDV.Text;
                String nombre = txtNombre.Text;
                String ApPaterno = txtApPaterno.Text;
                String ApMaterno = txtApMaterno.Text;
                String mail = txtEmail.Text;
                String direccion = txtDireccion.Text;
                String colegio = txtEstablecimiento.Text;

                int telefono = 0;
                if (int.TryParse(txtTelefono.Text, out telefono))
                {

                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                      string.Format("Ingrese un número de 9 dígitos"));
                    txtTelefono.Focus();
                    return;
                }
                Comuna comuna = (Comuna)cboComuna.SelectedItem;
                Curso curso = (Curso)cboCurso.SelectedItem;
                Letra letra = (Letra)cboCursoLetra.SelectedItem;

                string representante;
                if (rbsi.IsChecked == true)
                {
                    representante = "Si";
                                        
                }
                else
                {
                    representante = "No";
                    txtRut_alumno.IsEnabled = false;
                    txtNombre_alumno.IsEnabled = false;
                }

                string rutAlum = txtRut_alumno.Text + "-" + txtDV_alumno.Text;
                string nombreAlum = txtNombre_alumno.Text;
                Cliente c = new Cliente()
                {
                    RutApoderado = rut,
                    Nombre = nombre,
                    ApPaternoApod=ApPaterno,
                    ApMaternoApod=ApMaterno,
                    Email = mail,
                    Direccion = direccion,
                    Telefono = telefono,
                    _Comuna= comuna,
                    Establecimiento=colegio,
                    _Curso=curso,
                    _Letra=letra,
                    Representante=representante,
                    RutAlumno=rutAlum,
                    NombreAlum=nombreAlum
                    

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

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtRut_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtRut.Text.Length >= 7 && txtRut.Text.Length <= 8)
            {
                string v = new Verificar().ValidarRut(txtRut.Text);
                txtDV.Text = v;
                try
                {
                    string rutSinFormato = txtRut.Text;

                    //si el rut ingresado tiene "." o "," o "-" son ratirados para realizar la formula 
                    rutSinFormato = rutSinFormato.Replace(",", "");
                    rutSinFormato = rutSinFormato.Replace(".", "");
                    rutSinFormato = rutSinFormato.Replace("-", "");
                    string rutFormateado = String.Empty;

                    //obtengo la parte numerica del RUT
                    //string rutTemporal = rutSinFormato.Substring(0, rutSinFormato.Length - 1);
                    string rutTemporal = rutSinFormato;
                    //obtengo el Digito Verificador del RUT
                    //string dv = rutSinFormato.Substring(rutSinFormato.Length - 1, 1);

                    Int64 rut;

                    //aqui convierto a un numero el RUT si ocurre un error lo deja en CERO
                    if (!Int64.TryParse(rutTemporal, out rut))
                    {
                        rut = 0;
                    }

                    //este comando es el que formatea con los separadores de miles
                    rutFormateado = rut.ToString("N0");

                    if (rutFormateado.Equals("0"))
                    {
                        rutFormateado = string.Empty;
                    }
                    else
                    {
                        //si no hubo problemas con el formateo agrego el DV a la salida
                        // rutFormateado += "-" + dv;

                        //y hago este replace por si el servidor tuviese configuracion anglosajona y reemplazo las comas por puntos
                        rutFormateado = rutFormateado.Replace(",", ".");
                    }

                    //se pasa a mayuscula si tiene letra k
                    rutFormateado = rutFormateado.ToUpper();

                    //la salida esperada para el ejemplo es 99.999.999-K
                    txtRut.Text = rutFormateado;
                }
                catch (Exception)
                {

                }
            }
            else
            {
                txtRut.Text = "";
            }
        }

        private void txtRutAlumno_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtRut_alumno.Text.Length >= 7 && txtRut_alumno.Text.Length <= 8)
            {
                string v = new Verificar().ValidarRut(txtRut_alumno.Text);
                txtDV_alumno.Text = v;
                try
                {
                    string rutSinFormato = txtRut_alumno.Text;

                    //si el rut ingresado tiene "." o "," o "-" son ratirados para realizar la formula 
                    rutSinFormato = rutSinFormato.Replace(",", "");
                    rutSinFormato = rutSinFormato.Replace(".", "");
                    rutSinFormato = rutSinFormato.Replace("-", "");
                    string rutFormateado = String.Empty;

                    //obtengo la parte numerica del RUT
                    //string rutTemporal = rutSinFormato.Substring(0, rutSinFormato.Length - 1);
                    string rutTemporal = rutSinFormato;
                    //obtengo el Digito Verificador del RUT
                    //string dv = rutSinFormato.Substring(rutSinFormato.Length - 1, 1);

                    Int64 rut;

                    //aqui convierto a un numero el RUT si ocurre un error lo deja en CERO
                    if (!Int64.TryParse(rutTemporal, out rut))
                    {
                        rut = 0;
                    }

                    //este comando es el que formatea con los separadores de miles
                    rutFormateado = rut.ToString("N0");

                    if (rutFormateado.Equals("0"))
                    {
                        rutFormateado = string.Empty;
                    }
                    else
                    {
                        //si no hubo problemas con el formateo agrego el DV a la salida
                        // rutFormateado += "-" + dv;

                        //y hago este replace por si el servidor tuviese configuracion anglosajona y reemplazo las comas por puntos
                        rutFormateado = rutFormateado.Replace(",", ".");
                    }

                    //se pasa a mayuscula si tiene letra k
                    rutFormateado = rutFormateado.ToUpper();

                    //la salida esperada para el ejemplo es 99.999.999-K
                    txtRut_alumno.Text = rutFormateado;
                }
                catch (Exception)
                {

                }
            }
            else
            {
                txtRut_alumno.Text = "";
            }
        }

    }
}
