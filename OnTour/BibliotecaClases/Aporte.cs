using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class Aporte
    {
        private String _rutApoderado;

        public String RutApoderado
        {
            get { return _rutApoderado; }
            set { _rutApoderado = value; }
        }

        private String _nombre;

        public String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        private string _establecimiento;

        public string Establecimiento
        {
            get { return _establecimiento; }
            set { _establecimiento = value; }
        }

        public string curso { get; set; }

        public string seguros { get; set; }
        public int ValorTotal { get; set; }
        public string act { get; set; }
        public string dest { get; set; }
        public string serv { get; set; }

        //public int apEfectuado { get; set; }
        //public int aporteNuevo { get; set; }
        public int Saldo { get; set; }
        public Aporte()
        {

        }
    }
}
