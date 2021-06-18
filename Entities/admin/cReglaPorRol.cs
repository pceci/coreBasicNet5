using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace coreBasicNet5.Entities
{
    public class cReglaPorRol
    {
        public int idRegla { get; set; }
        public int idRelacionReglaRol { get; set; }
        public bool isActivo { get; set; }
        public bool? isAgregar { get; set; }
        public bool? isEditar { get; set; }  
        public bool? isEliminar { get; set; }
        public bool? isAgregado { get{return isAgregar;} set {isAgregar =value;} }
        public bool? isEditado { get{return isEditar;} set {isEditar =value;} }
        public bool? isEliminado { get{return isEliminar;} set {isEliminar =value;} }
    }
}