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
    /// Lógica de interacción para WpfCorreo.xaml
    /// </summary>
    public partial class WpfCorreo : MetroWindow
    {
        public WpfCorreo()
        {
            InitializeComponent();
            cboPara.Items.Add("juan.perez@gmail.com");
            cboPara.Items.Add("colegiobuenaventura@gmail.com");
            cboPara.Items.Add("pamela_carrasco@hotmail.com");
            cboPara.Items.Add("kps88765@outlook.com");
            cboPara.Items.Add("hh5p@colegioelprado.cl");

            btnSalir.Visibility = Visibility.Hidden;
        }

        private async void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            
            var x =
            await this.ShowMessageAsync("Advertencia", "¿Seguro que Desea Salir? \n Se descartarán todos los cambios",
                    MessageDialogStyle.AffirmativeAndNegative);
            if (x == MessageDialogResult.Affirmative)
            {
               
                this.Close();
                
            }
            else
            {

            }
        }

        private async void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (cboPara.Text == "" && txtAsunto.Text==""  )
            {
                await this.ShowMessageAsync("Mensaje:",
                                        string.Format("Ingrese campos: Destinatario y Asunto "));

            }

            else
            {
                var x = await this.ShowProgressAsync("Por Favor Espere... ", "Enviando Correo Electrónico...");

                await Task.Delay(3000);
                btnCancelar.Visibility = Visibility.Hidden;
                btnSalir.Visibility = Visibility.Visible;

                x.SetCancelable(false);

                await this.ShowMessageAsync("Mensaje:", "Correo ELectrónico Enviado!");
                await x.CloseAsync().ConfigureAwait(false);
                
            }

            
        }

    

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RichTxt_mensaje.Document.Blocks.Clear();
            txtAsunto.Clear();
            cboPara.Items.Clear();
            btnSalir.Visibility = Visibility.Hidden;
            btnCancelar.Visibility = Visibility.Visible;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
