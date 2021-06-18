using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace coreBasicNet5.Entities
{
    public class cListaCheck
    {
        public int id { get; set; }

        public string descripcion { get; set; }

        public string palabra { get; set; }

        public int checkAgregar { get; set; }

        public int checkEditar { get; set; }

        public int checkEliminar { get; set; }

        public int? idPadreRegla { get; set; }

        public List<int> listaIdPadre { get; set; }

        public List<int> listaIdHijas { get; set; }
       // public List<cListaCheck> listaHijas { get; set; }
        public int Nivel { get; set; }

        public bool isGraficada { get; set; }
    }
}