using System.Collections.Generic;
using coreBasicNet5.Entities;
using coreBasicNet5.Entities.Authenticate;
using System.Linq;

namespace coreBasicNet5.Business
{
    public class AdminService : IAdminService
    {
        public static List<cRol> DataSourceRol = new List<cRol>(new[] {
          new cRol() { id = 1, rol_Nombre = "Hola" },
          new cRol() { id = 2, rol_Nombre = "Mundo"},
          new cRol() { id = 3, rol_Nombre = "Lala" },
      });
        public static List<cRegla> DataSourceRegla = new List<cRegla>(new[] {
          new cRegla() { id = 1, rgl_Descripcion= "Raiz" , rgl_PalabraClave= "raiz",rgl_IsAgregarSoporta = true,rgl_IsEditarSoporta=true,rgl_IsEliminarSoporta=true,rgl_codReglaPadre=null },
          new cRegla() { id =2, rgl_Descripcion= "Gestión rol" , rgl_PalabraClave= "gestionrol",rgl_IsAgregarSoporta = true,rgl_IsEditarSoporta=true,rgl_IsEliminarSoporta=true,rgl_codReglaPadre=1 },
          new cRegla() { id = 3, rgl_Descripcion= "Gestión regla" , rgl_PalabraClave= "gestionregla",rgl_IsAgregarSoporta = true,rgl_IsEditarSoporta=true,rgl_IsEliminarSoporta=true,rgl_codReglaPadre=1 }
      });

        public static List<cUsuario> DataSourceUsuario = new List<cUsuario>(new[] {
          new cUsuario() { id = 1, usu_codRol = 1, usu_nombre= "Juan" , usu_apellido= "Perez", usu_mail = "juan@mail.com",usu_login="resl" ,usu_codCliente=1,usu_estado  =1},
          new cUsuario() { id = 2, usu_codRol = 2, usu_nombre= "Pedro" , usu_apellido= "Lopez", usu_mail = "pedro@mail.com",usu_login="pedro" ,usu_estado  =1},
          new cUsuario() { id = 3, usu_codRol = 1, usu_nombre= "Lisa" , usu_apellido= "Rodriguez", usu_mail = "lisa@mail.com",usu_login="lista" ,usu_codCliente=2,usu_estado  =1}
      });
        public User InicioSession(string pNombreLogin, string pPassword, string pIp, string pHostName, string pUserAgent)
        {
            return new User();
        }
        public cRol GetOneRol(int id) => DataSourceRol.Where(m => m.id == id).FirstOrDefault();

        public List<cRol> GetAllRol() { return DataSourceRol; }

        public cRol AddRol(cRol rol)
        {
            rol.id = DataSourceRol.Count() + 1;
            DataSourceRol.Add(rol);
            return rol;
        }
        public cRol EditRol(int id, cRol pRol)
        {
            if (id != pRol.id)
            {
                return null;
            }
            DataSourceRol.FirstOrDefault(x => x.id == id).rol_Nombre = pRol.rol_Nombre;
            return DataSourceRol.FirstOrDefault(x => x.id == id);
        }

        public void DeleteRol(int id)
        {
            DataSourceRol.RemoveAll(c => c.id == id);
        }
        public cRegla GetOneRegla(int id) => DataSourceRegla.Where(m => m.id == id).FirstOrDefault();
        public List<cRegla> GetAllRegla() { return DataSourceRegla; }
        public cRegla AddRegla(cRegla regla)
        {
            regla.id = DataSourceRegla.Count() + 1;
            DataSourceRegla.Add(regla);
            return regla;
        }
        public cRegla EditRegla(int id, cRegla regla)
        {
            if (id != regla.id)
            {
                return null;
            }
            DataSourceRegla.FirstOrDefault(x => x.id == id).rgl_Descripcion = regla.rgl_Descripcion;
            DataSourceRegla.FirstOrDefault(x => x.id == id).rgl_PalabraClave = regla.rgl_PalabraClave;
            DataSourceRegla.FirstOrDefault(x => x.id == id).rgl_IsAgregarSoporta = regla.rgl_IsAgregarSoporta;
            DataSourceRegla.FirstOrDefault(x => x.id == id).rgl_IsEditarSoporta = regla.rgl_IsEditarSoporta;
            DataSourceRegla.FirstOrDefault(x => x.id == id).rgl_IsEliminarSoporta = regla.rgl_IsEliminarSoporta;
            DataSourceRegla.FirstOrDefault(x => x.id == id).rgl_codReglaPadre = regla.rgl_codReglaPadre;
            return DataSourceRegla.FirstOrDefault(x => x.id == id);
        }

        public void DeleteRegla(int id)
        {
            DataSourceRegla.RemoveAll(c => c.id == id);
        }
        public List<cListaCheck> GetAllReglaPorNivel()
        {
            List<cRegla> listaReglaParametro = DataSourceRegla;
            List<cListaCheck> listaResultado = new List<cListaCheck>();
            // cargar detalle
            cListaCheck o1 = new cListaCheck();
            o1.id = 1;
            o1.descripcion = "Raiz";
            o1.palabra = "raiz";
            o1.Nivel = 10;
            o1.idPadreRegla = null;
            o1.isGraficada = false;
            o1.checkAgregar = 0;
            o1.checkEditar = 0;
            o1.checkEliminar = 0;
            o1.listaIdHijas = new List<int>();
            o1.listaIdHijas.Add(1);
            o1.listaIdHijas.Add(2);
            listaResultado.Add(o1);
            return listaResultado;
        }
        public List<int> GetAllIdReglasHijas(int pIdRegla, List<cRegla> pListaRegla)
        {
            List<int> l = new List<int>();
            l.Add(1);
            l.Add(2);
            return l;
        }
        public cUsuario GetOneUsuario(int id) => DataSourceUsuario.Where(m => m.id == id).FirstOrDefault();
        public List<cUsuario> GetAllUsuario() { return DataSourceUsuario; }
        public cUsuario AddUsuario(cUsuario usuario)
        {
            usuario.id = DataSourceRegla.Count() + 1;
            DataSourceUsuario.Add(usuario);
            return usuario;
        }
        public cUsuario EditUsuario(int id, cUsuario usuario)
        {
            if (id != usuario.id)
            {
                return null;
            }
            DataSourceUsuario.FirstOrDefault(x => x.id == id).usu_apellido = usuario.usu_apellido;
            DataSourceUsuario.FirstOrDefault(x => x.id == id).usu_nombre = usuario.usu_nombre;
            DataSourceUsuario.FirstOrDefault(x => x.id == id).usu_login = usuario.usu_login;
            DataSourceUsuario.FirstOrDefault(x => x.id == id).usu_mail = usuario.usu_mail;
            DataSourceUsuario.FirstOrDefault(x => x.id == id).usu_estado = usuario.usu_estado;
            DataSourceUsuario.FirstOrDefault(x => x.id == id).usu_observacion = usuario.usu_observacion;
            return DataSourceUsuario.FirstOrDefault(x => x.id == id);
        }
        public void DeleteUsuario(int id)
        {
            DataSourceUsuario.RemoveAll(c => c.id == id);
        }
        public List<cReglaPorRol> GetAllReglasRol(int id)
        {
            List<cReglaPorRol> l = new List<cReglaPorRol>();
            cReglaPorRol o1 = new cReglaPorRol();
            o1.idRelacionReglaRol = 1;
            o1.idRegla = 1;
            o1.isActivo = true;
            o1.isAgregado = true;
            o1.isAgregar = true;
            o1.isEditado = true;
            o1.isEditar = true;
            o1.isEliminado = true;
            o1.isEliminar = true;

            l.Add(o1);
            return l;
        }
        public bool EditReglasRol(int pIdRol, List<cReglaPorRol> lista)
        {
            return true;
        }
    }
}