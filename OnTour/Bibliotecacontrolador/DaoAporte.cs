using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaClases;

namespace Bibliotecacontrolador
{
    public class DaoAporte
    {
        private static List<Aporte> Aportes;
        public DaoAporte()
        {
            if (Aportes == null)
            {
                Aportes = new List<Aporte>();
            }
        }

        //metodos customer C.R.U.D.
        // Agregar
        public bool Agregar(Aporte ap)
        {
            if (ExisteAporte(ap.RutApoderado) == false)
            {
                Aportes.Add(ap);
                return true;
            }
            return false;


        }

        private bool ExisteAporte(object rut)
        {
            foreach (Aporte item in Aportes)
            {
                if (item.RutApoderado.Equals(rut))
                {
                    return true;
                }
            }
            return false;
        }

        //Listar
        public List<Aporte> Listar()
        {
            return Aportes;
        }

      
        //Buscar
        public Aporte Buscar(string rut)
        {
            foreach (Aporte item in Aportes)
            {
                if (item.RutApoderado.Equals(rut))
                {
                    return item;
                }
            }
            return null;
        }



       

    }
}
