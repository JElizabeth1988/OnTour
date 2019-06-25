using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaClases;

namespace Bibliotecacontrolador
{
    public class DaoCliente
    {
        private static List<Cliente> clientes;

        public DaoCliente()
        {
            if (clientes == null)
            {
                clientes = new List<Cliente>();
            }
        }

        //metodos customer C.R.U.D.
        // Agregar
        public bool Agregar(Cliente cli)
        {
            if (ExisteCliente(cli.RutApoderado) == false)
            {
                clientes.Add(cli);
                return true;
            }
            return false;


        }

        private bool ExisteCliente(object rut)
        {
            foreach (Cliente item in clientes)
            {
                if (item.RutApoderado.Equals(rut))
                {
                    return true;
                }
            }
            return false;
        }

        //Listar
        public List<Cliente> Listar()
        {
            return clientes;
        }

        //Eliminar
        public bool Eliminar(String rut)
        {
            foreach (Cliente item in clientes)
            {
                if (item.RutApoderado.Equals(rut))
                {
                    clientes.Remove(item);
                    return true;
                }
            }
            return false;

        }

        //Buscar
        public Cliente Buscar(string rut)
        {
            foreach (Cliente item in clientes)
            {
                if (item.RutApoderado.Equals(rut))
                {
                    return item;
                }
            }
            return null;
        }

        //Modificar
        public bool Modificar(Cliente nuevoCliente)
        {
            foreach (Cliente item in clientes)
            {
                if (item.RutApoderado.Equals(nuevoCliente.RutApoderado))
                {
                    clientes.Remove(item);//remueve el cliente
                    clientes.Add(nuevoCliente);//agrega los nuevos datos
                    return true;
                }
            }
            return false;
        }
    }
}
