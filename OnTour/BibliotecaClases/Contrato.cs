using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public enum Servicio
    {
        Alojamiento, Alimentacion,Guía, Información,Transporte, Salud

    }

    public enum Actividad
    {
        Balnearios, Piscina, Kanopi,Parques_Acuáticos, Instalaciones_Deportivas, Zoológicos,
        Senderismo,Rapell,Tirolina,Canoas, Airsoft

    }
    public enum Destino
    {
        Carretera_Austral,Cajón_Del_Maipo,Chiloé,Huilo_Huilo,Isla_De_Pascua,Iquique,Laguna_San_Rafael,Parque_Nacional_Lauca,
        San_Pedro_de_Atacama,Torres_Del_Paine, Valparaíso

    }
    public class Contrato
    {
        public string NumeroContrato { get; set; }
        public string RutCliente { get; set; }
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public int ValorServicio { get; set; }
        public int ValorActividad { get; set; }
        public string seguros { get; set; }
        public int ValorTotal { get; set; }
        public Actividad act { get; set; }
        public Destino dest { get; set; }
        public Servicio serv { get; set; }

        public Contrato()
        {

        }
    }
}
