using System.ComponentModel.DataAnnotations;

namespace coreBasicNet5.Entities
{
    public class cRegla : IEntityBase
    {
        [Display(Name = "Código")]
        public int id { get { return rgl_codRegla; } set { rgl_codRegla = value; } }
        public int rgl_codRegla { get; set; }
        public string rgl_Descripcion { get; set; }
        public string rgl_PalabraClave { get; set; }
        public bool? rgl_IsAgregarSoporta { get; set; }
        public bool? rgl_IsEditarSoporta { get; set; }
        public bool? rgl_IsEliminarSoporta { get; set; }
        public int? rgl_codReglaPadre { get; set; }
    }
}