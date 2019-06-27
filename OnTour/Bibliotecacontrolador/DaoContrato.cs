using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaClases;

namespace Bibliotecacontrolador
{
    public class DaoContrato
    {
        private static List<Contrato> contratos;
        public DaoContrato()
        {
            if (contratos == null)
            {
                contratos = new List<Contrato>();
            }
        }

        //metodos customer C.R.U.D.
        // Agregar
        public bool Agregar(Contrato con)
        {
            if (ExisteContrato(con.NumeroContrato) == false)
            {
                contratos.Add(con);
                return true;
            }
            return false;


        }

        private bool ExisteContrato(object num)
        {
            foreach (Contrato item in contratos)
            {
                if (item.NumeroContrato.Equals(num))
                {
                    return true;
                }
            }
            return false;
        }


        //Listar
        public List<Contrato> Listar()
        {
            return contratos;
        }

        //Eliminar
        public bool Eliminar(string num)
        {
            foreach (Contrato item in contratos)
            {
                if (item.NumeroContrato.Equals(num))
                {
                    contratos.Remove(item);
                    return true;
                }
            }
            return false;

        }

        //Buscar
        public Contrato Buscar(string num)
        {
            foreach (Contrato item in contratos)
            {
                if (item.NumeroContrato.Equals(num))
                {
                    return item;
                }
            }
            return null;
        }

        //Buscar
        public Contrato BuscarRut(string rut)
        {
            foreach (Contrato item in contratos)
            {
                if (item.RutCliente.Equals(rut))
                {
                    return item;
                }
            }
            return null;
        }

        //Modificar
        public bool Modificar(Contrato nuevoContrato)
        {
            foreach (Contrato item in contratos)
            {
                if (item.NumeroContrato.Equals(nuevoContrato.NumeroContrato))
                {
                    contratos.Remove(item);//remueve el cliente
                    contratos.Add(nuevoContrato);//agrega los nuevos datos
                    return true;
                }
            }
            return false;
        }

        public List<Contrato> FiltroRut(string rut)
        {
            List<Contrato> cl = contratos.Where(x => x.RutCliente == rut).
                ToList();
            return cl;
        }

        public List<Contrato> FiltroCont(string num)
        {
            List<Contrato> cl = contratos.Where(x => x.NumeroContrato == num).
                ToList();
            return cl;
        }
       
    

}
}
