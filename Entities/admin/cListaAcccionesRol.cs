using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace coreBasicNet5.Entities
{
   public class cListaAcccionesRol
    {
        public cListaAcccionesRol()
        {
            lista = new List<cAcccionesRol>();
        }
        public List<cAcccionesRol> lista { get; set; }

        public void Agregar(cAcccionesRol pAcccionesRol)
        {
            lista.Add(pAcccionesRol);
        }
        public cAcccionesRol Buscar(string pPalabraClave)
        {
            cAcccionesRol resultado = new cAcccionesRol();
            foreach (cAcccionesRol item in lista)
            {
                if (item.palabraClave == pPalabraClave)
                {
                    resultado = item;
                    break;
                }
            }
            return resultado;
        }
        public bool isActivo(string pPalabraClave)
        {
            return Buscar(pPalabraClave).isActivo;
        }
        public bool isAgregar(string pPalabraClave)
        {
            return Buscar(pPalabraClave).isAgregar;
        }
        public bool isEditar(string pPalabraClave)
        {
            return Buscar(pPalabraClave).isEditar;
        }
        public bool isEliminar(string pPalabraClave)
        {
            return Buscar(pPalabraClave).isEliminar;
        }
    }
}