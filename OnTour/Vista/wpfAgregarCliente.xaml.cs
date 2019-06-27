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

            cboComuna.SelectedIndex = 0;
            cboCurso.SelectedIndex = 0;
            cboCursoLetra.SelectedIndex = 0;


            dao = new DaoCliente();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
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
                String rut = txtRut.Text;
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
                      string.Format("Ingrese sólo valores numéricos"));
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

                }

                string rutAlum = txtRut_alumno.Text ;
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

        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente c = new DaoCliente().
                    Buscar(txtRut.Text);
                if (c != null)
                {
                    txtRut.Text = c.RutApoderado;
                    txtNombre.Text = c.Nombre;
                    txtApPaterno.Text = c.ApPaternoApod;
                    txtApMaterno.Text = c.ApMaternoApod;
                    txtEmail.Text = c.Email;
                    txtDireccion.Text = c.Direccion;
                    cboComuna.Text = c._Comuna.ToString();
                    txtTelefono.Text = c.Telefono.ToString();
                    txtEstablecimiento.Text = c.Establecimiento;
                    cboComuna.Text = c._Comuna.ToString();
                    cboCurso.Text =  c._Curso.ToString();
                    cboCursoLetra.Text = c._Letra.ToString();
                    txtRut_alumno.Text = c.RutAlumno;
                    txtNombre_alumno.Text = c.NombreAlum;
                    if (c.Representante== "Si")
                    {
                        rbsi.IsChecked = true;
                        rbNo.IsChecked = false;
                    }

                    if (c.Representante == "No")
                    {
                        rbNo.IsChecked = true;
                        rbsi.IsChecked = false;
                    }
                    txtRut.IsEnabled = false;

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

        
    }
}
