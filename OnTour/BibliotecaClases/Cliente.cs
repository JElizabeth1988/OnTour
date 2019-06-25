using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public enum Comuna
    {
         Cerrillos,Cerro_Navia,Conchalí,El_Bosque,Estación_Central,Huechuraba,Independencia,
         La_Cisterna,La_Florida,La_Granja,La_Pintana,La_Reina,Las_Condes,Lo_Barnechea,Lo_Espejo,
         Lo_Prado,Macul,Maipú,Ñunoa,Padre_Hurtado,Pedro_Aguirre_Cerda,Peñalolén,Pirque,Providencia,
         Pudahuel,Puente_Alto,Quilicura,Quinta_Normal,Recoleta,Renca,San_Bernardo,San_Joaquín,
         San_José_de_Maipo,San_Miguel, San_Ramón, Santiago, Vitacura

    }

    public enum Curso
    {
        Primero_Básico, Segundo_Básico, Tercero_Básico, Cuarto_Básico, Quinto_Básico, Sexto_Básico,
        Séptimo_Básico, Octavo_Básico, Primero_Medio, Segundo_Medio,Tercero_Medio,Cuarto_Medio

    }
    public enum Letra
    {
        A,B,C,D,E,F,G,H

    }

    public class Cliente
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

        private string _apPaternoApod;

        public string ApPaternoApod
        {
            get { return _apPaternoApod; }
            set { _apPaternoApod = value; }
        }

        private string _apMaternoApod;

        public string ApMaternoApod
        {
            get { return _apPaternoApod; }
            set { _apPaternoApod = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _direccion;

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        private int _telefono;

        public int Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private string _establecimiento;

        public string Establecimiento
        {
            get { return _establecimiento; }
            set { _establecimiento = value; }
        }

        public Comuna _Comuna { get; set; }

        public Curso _Curso { get; set; }
        public Letra _Letra { get; set; }

        public string Representante { get; set; }

        public string RutAlumno { get; set; }
        public string NombreAlum { get; set; }

        public Cliente()
        {

        }
    }
}
