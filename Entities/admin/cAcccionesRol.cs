using System.ComponentModel.DataAnnotations;

namespace coreBasicNet5.Entities
{
    public class cAcccionesRol
    {
        public int idRegla
        {
            get;
            set;
        }
        public int? idReglaRol
        {
            get;
            set;
        }
        public string palabraClave
        {
            get;
            set;
        }
        public bool isActivo
        {
            get;
            set;
        }
        public bool isAgregar
        {
            get;
            set;
        }
        public bool isEditar
        {
            get;
            set;
        }
        public bool isEliminar
        {
            get;
            set;
        }

    }
}