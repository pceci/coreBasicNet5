using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using coreBasicNet5.Entities;
using coreBasicNet5.Entities.Authenticate;
using System.Xml.Linq;

namespace coreBasicNet5.Codigo
{
    public class capaAdmin
    {
        public static DataSet spInicioSession(string pNombreLogin, string pPassword, string pIp, string pHostName, string pUserAgent)
        {
            BaseDataAccess db = new BaseDataAccess(Helper.getConnectionStringSQL);
            List<SqlParameter> l = new List<SqlParameter>();
            l.Add(db.GetParameter("login", pNombreLogin));
            l.Add(db.GetParameter("Password", pPassword));
            l.Add(db.GetParameter("Ip", pIp));
            l.Add(db.GetParameter("Host", pHostName));
            l.Add(db.GetParameter("UserName", pUserAgent));
            DataSet ds = db.GetDataSet("seg.spInicioSession", l);
            return ds;
        }
        public static User InicioSession(string pNombreLogin, string pPassword, string pIp, string pHostName, string pUserAgent)
        {
            User o = null;
            DataSet dsResultado = spInicioSession(pNombreLogin, pPassword, pIp, pHostName, pUserAgent);
            if (dsResultado != null && dsResultado.Tables.Count > 0 && dsResultado.Tables[0].Rows.Count > 0)
            {
                o = ConvertToUser(dsResultado.Tables[0].Rows[0]);
            }
            return o;
        }
        public static bool spError(string err_Nombre, string err_Parameters, string err_Data, string err_HelpLink, string err_InnerException, string err_Message, string err_Source, string err_StackTrace, DateTime err_fecha, string err_tipo)
        {
            BaseDataAccess db = new BaseDataAccess(Helper.getConnectionStringSQL);
            List<SqlParameter> l = new List<SqlParameter>();
            l.Add(db.GetParameter("err_Nombre", err_Nombre));
            l.Add(db.GetParameter("err_Parameters", err_Parameters));
            l.Add(db.GetParameter("err_Data", err_Data));
            l.Add(db.GetParameter("err_HelpLink", err_HelpLink));
            l.Add(db.GetParameter("err_InnerException", err_InnerException));
            l.Add(db.GetParameter("err_Message", err_Message));
            l.Add(db.GetParameter("err_Source", err_Source));
            l.Add(db.GetParameter("err_StackTrace", err_StackTrace));
            l.Add(db.GetParameter("err_fecha", err_fecha));
            l.Add(db.GetParameter("err_tipo", err_tipo));
            int result = db.ExecuteNonQuery_forError("seg.spError", l);
            return result > 0;
        }
        public static DataSet GestiónRol(int? rol_codRol, string rol_Nombre, string filtro, string accion)
        {
            BaseDataAccess db = new BaseDataAccess(Helper.getConnectionStringSQL);
            List<SqlParameter> l = new List<SqlParameter>();
            l.Add(db.GetParameter("rol_codRol", rol_codRol));
            l.Add(db.GetParameter("rol_Nombre", rol_Nombre));
            l.Add(db.GetParameter("filtro", filtro));
            l.Add(db.GetParameter("accion", accion));
            DataSet ds = db.GetDataSet("seg.spGestionRol", l);
            return ds;
        }
        public static DataSet GestiónRegla(int? rgl_codRegla, string rgl_Descripcion, string rgl_PalabraClave, bool? rgl_IsAgregarSoporta, bool? rgl_IsEditarSoporta, bool? rgl_IsEliminarSoporta, int? rgl_codReglaPadre, string filtro, string accion)
        {
            BaseDataAccess db = new BaseDataAccess(Helper.getConnectionStringSQL);
            List<SqlParameter> l = new List<SqlParameter>();
            l.Add(db.GetParameter("rgl_codRegla", rgl_codRegla));
            l.Add(db.GetParameter("rgl_Descripcion", rgl_Descripcion));
            l.Add(db.GetParameter("rgl_PalabraClave", rgl_PalabraClave));
            l.Add(db.GetParameter("rgl_IsAgregarSoporta", rgl_IsAgregarSoporta));
            l.Add(db.GetParameter("rgl_IsEditarSoporta", rgl_IsEditarSoporta));
            l.Add(db.GetParameter("rgl_IsEliminarSoporta", rgl_IsEliminarSoporta));
            l.Add(db.GetParameter("rgl_codReglaPadre", rgl_codReglaPadre));
            l.Add(db.GetParameter("filtro", filtro));
            l.Add(db.GetParameter("accion", accion));
            DataSet ds = db.GetDataSet("seg.spGestionRegla", l);
            return ds;
        }
        public static DataSet GestiónRoleRegla(int? rrr_codRol, int? rrr_codRegla, string pXML, string accion)
        {
            BaseDataAccess db = new BaseDataAccess(Helper.getConnectionStringSQL);
            List<SqlParameter> l = new List<SqlParameter>();
            l.Add(db.GetParameter("rrr_codRol", rrr_codRol));
            l.Add(db.GetParameter("rrr_codRegla", rrr_codRegla));
            l.Add(db.GetParameter("strXML", pXML));
            l.Add(db.GetParameter("accion", accion));
            DataSet ds = db.GetDataSet("seg.spGestionRelacionRoleRegla", l);
            return ds;
        }
        public static DataSet GestiónUsuario(int? usu_codigo, int? usu_codRol, int? usu_codCliente, string usu_nombre, string usu_apellido, string usu_mail, string usu_login, string usu_psw, string usu_observacion, int? usu_codUsuarioUltMov, int? usu_codAccion, int? usu_estado, string filtro, string accion)
        {
            BaseDataAccess db = new BaseDataAccess(Helper.getConnectionStringSQL);
            List<SqlParameter> l = new List<SqlParameter>();
            l.Add(db.GetParameter("usu_codigo", usu_codigo));
            l.Add(db.GetParameter("usu_codRol", usu_codRol));
            l.Add(db.GetParameter("usu_codCliente", usu_codCliente));
            l.Add(db.GetParameter("usu_nombre", usu_nombre));
            l.Add(db.GetParameter("usu_apellido", usu_apellido));
            l.Add(db.GetParameter("usu_mail", usu_mail));
            l.Add(db.GetParameter("usu_login", usu_login));
            l.Add(db.GetParameter("usu_psw", usu_psw));
            l.Add(db.GetParameter("usu_observacion", usu_observacion));
            l.Add(db.GetParameter("usu_codUsuarioUltMov", usu_codUsuarioUltMov));
            l.Add(db.GetParameter("usu_codAccion", usu_codAccion));
            l.Add(db.GetParameter("usu_estado", usu_estado));
            l.Add(db.GetParameter("filtro", filtro));
            l.Add(db.GetParameter("accion", accion));
            DataSet ds = db.GetDataSet("seg.spGestionUsuario", l);
            return ds;
        }
        public static DataTable RecuperarTodasAccionesRol(int IdRol)
        {
            BaseDataAccess db = new BaseDataAccess(Helper.getConnectionStringSQL);
            List<SqlParameter> l = new List<SqlParameter>();
            l.Add(db.GetParameter("IdRol", IdRol));
            return db.GetDataTable("seg.spRecuperarAccionesUsuario", l);
        }
        public static DataTable getDataTableRecuperarTodasReglasPorNivel()
        {
            BaseDataAccess db = new BaseDataAccess(Helper.getConnectionStringSQL);
            List<SqlParameter> l = new List<SqlParameter>();
            return db.GetDataTable("seg.spRecuperarTodasReglasPorNiveles", l);
        }
        public static List<cRol> RecuperarTodasRoles(string pFiltro)
        {
            List<cRol> lista = new List<cRol>();
            DataSet dsResultado = GestiónRol(null, null, pFiltro, Constantes.cSQL_SELECT);
            if (dsResultado != null && dsResultado.Tables.Count > 0)
            {
                foreach (DataRow item in dsResultado.Tables[0].Rows)
                {
                    cRol o = ConvertToRol(item);
                    lista.Add(o);
                }
            }
            return lista;
        }
        public static int InsertarActualizarRol(int rol_codRol, string rol_Nombre)
        {
            string accion = rol_codRol == 0 ? Constantes.cSQL_INSERT : Constantes.cSQL_UPDATE;
            DataSet dsResultado = GestiónRol(rol_codRol, rol_Nombre, null, accion);
            int resultado = -1;
            if (rol_codRol == 0)
            {
                if (dsResultado != null && dsResultado.Tables.Count > 0)
                {
                    if (dsResultado.Tables[0].Rows[0]["rol_codRol"] != DBNull.Value)
                    {
                        resultado = Convert.ToInt32(dsResultado.Tables[0].Rows[0]["rol_codRol"]);
                    }
                }
            }
            else
            {
                resultado = rol_codRol;
            }
            return resultado;
        }
        public static cRol RecuperarRolPorId(int pIdRol)
        {
            DataSet dsResultado = GestiónRol(pIdRol, null, null, Constantes.cSQL_SELECT);
            if (dsResultado != null && dsResultado.Tables.Count > 0)
            {
                foreach (DataRow item in dsResultado.Tables[0].Rows)
                {
                    cRol o = ConvertToRol(item);
                    return o;
                }
            }
            return null;
        }
        public static void EliminarRol(int rol_codRol)
        {
            DataSet dsResultado = GestiónRol(rol_codRol, null, null, Constantes.cSQL_DELETE);
        }
        public static void EliminarRegla(int rgl_codRegla)
        {
            DataSet dsResultado = GestiónRegla(rgl_codRegla, null, null, null, null, null, null, null, Constantes.cSQL_DELETE);
        }
        public static void EliminarUsuario(int usu_codigo)
        {
            DataSet dsResultado = GestiónUsuario(usu_codigo, null, null, null, null, null, null, null, null, null, null, null, null, Constantes.cSQL_DELETE);
        }
        public static List<cRegla> RecuperarTodasReglas(string pFiltro)
        {
            List<cRegla> lista = new List<cRegla>();
            DataSet dsResultado = GestiónRegla(null, null, null, null, null, null, null, pFiltro, Constantes.cSQL_SELECT);
            if (dsResultado != null && dsResultado.Tables.Count > 0)
            {
                foreach (DataRow item in dsResultado.Tables[0].Rows)
                {
                    lista.Add(ConvertToRegla(item));
                }
            }
            return lista;
        }
        public static cRegla RecuperarReglaPorId(int pIdRegla)
        {
            cRegla obj = null;
            DataSet dsResultado = GestiónRegla(pIdRegla, null, null, null, null, null, null, null, Constantes.cSQL_SELECT);
            if (dsResultado != null && dsResultado.Tables.Count > 0)
            {
                foreach (DataRow item in dsResultado.Tables[0].Rows)
                {
                    obj = ConvertToRegla(item);
                    break;
                }
            }
            return obj;
        }
        public static int InsertarActualizarRegla(int rgl_codRegla, string rgl_Descripcion, string rgl_PalabraClave, bool? rgl_IsAgregarSoporta, bool? rgl_IsEditarSoporta, bool? rgl_IsEliminarSoporta, int? rgl_codReglaPadre)
        {
            string accion = rgl_codRegla == 0 ? Constantes.cSQL_INSERT : Constantes.cSQL_UPDATE;
            DataSet dsResultado = GestiónRegla(rgl_codRegla, rgl_Descripcion, rgl_PalabraClave, rgl_IsAgregarSoporta, rgl_IsEditarSoporta, rgl_IsEliminarSoporta, rgl_codReglaPadre, null, accion);
            int resultado = -1;
            if (rgl_codRegla == 0)
            {
                if (dsResultado != null && dsResultado.Tables.Count > 0)
                {
                    if (dsResultado.Tables[0].Rows[0]["rgl_codRegla"] != DBNull.Value)
                    {
                        resultado = Convert.ToInt32(dsResultado.Tables[0].Rows[0]["rgl_codRegla"]);
                    }
                }
            }
            else
            {
                resultado = rgl_codRegla;
            }
            return resultado;
        }
        public static List<cCombo> RecuperarTodasReglas_Combo()
        {
            List<cCombo> lista = new List<cCombo>();
            DataSet dsResultado = GestiónRegla(null, null, null, null, null, null, null, null, Constantes.cSQL_COMBO);
            if (dsResultado != null && dsResultado.Tables.Count > 0)
            {
                foreach (DataRow item in dsResultado.Tables[0].Rows)
                {
                    cCombo obj = new cCombo();
                    if (item.Table.Columns.Contains("rgl_codRegla") && item["rgl_codRegla"] != DBNull.Value)
                    {
                        obj.id = Convert.ToInt32(item["rgl_codRegla"]);
                    }
                    if (item.Table.Columns.Contains("rgl_Descripcion") && item["rgl_Descripcion"] != DBNull.Value)
                    {
                        obj.nombre = item["rgl_Descripcion"].ToString();
                    }
                    lista.Add(obj);
                }
            }
            return lista;
        }
        public static void InsertarActualizarRelacionRolRegla(int pIdRol, string pXML)
        {
            DataSet dsResultado = GestiónRoleRegla(pIdRol, null, pXML, Constantes.cSQL_UPDATE);
        }

        public static List<cReglaPorRol> RecuperarRelacionRolReglasPorRol(int pIdRol)
        {
            List<cReglaPorRol> listaResultado = new List<cReglaPorRol>();
            DataSet dsResultado = GestiónRoleRegla(pIdRol, null, null, Constantes.cSQL_SELECT);
            if (dsResultado != null && dsResultado.Tables.Count > 0)
            {
                foreach (DataRow item in dsResultado.Tables[0].Rows)
                {
                    listaResultado.Add(ConvertToReglaPorRol(item));
                }
            }
            return listaResultado;
        }
        //
        public static List<int> RecuperarTodosIdReglasHijas(int pIdRegla, List<cRegla> pListaRegla)
        {
            List<int> listaHijas = new List<int>();
            if (pListaRegla != null)
            {
                List<cRegla> listaRegla = pListaRegla.Where(x => x.rgl_codReglaPadre == pIdRegla).ToList();
                foreach (cRegla item in listaRegla)
                {
                    listaHijas.Add(item.rgl_codRegla);
                }
            }
            return listaHijas;
        }
        public static cListaAcccionesRol RecuperarTodasAccionesPorIdRol(int pIdRol)
        {
            DataTable tablaAcciones = RecuperarTodasAccionesRol(pIdRol);
            cListaAcccionesRol listaAcciones = new cListaAcccionesRol();
            foreach (DataRow item in tablaAcciones.Rows)
            {
                listaAcciones.Agregar(ConvertToAcccionesRol(item));
            }
            return listaAcciones;
        }
        public static List<cListaCheck> RecuperarTodasReglasPorNivel()
        {
            List<cRegla> listaReglaParametro = RecuperarTodasReglas(string.Empty);
            List<cListaCheck> listaResultado = new List<cListaCheck>();
            DataTable tabla = getDataTableRecuperarTodasReglasPorNivel();
            if (tabla != null)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    listaResultado.Add(ConvertListaCheck(tabla.Rows[i], listaReglaParametro));
                }
            }
            return listaResultado;
        }
        public static int InsertarActualizarUsuario(int usu_codigo, int usu_codRol, int? usu_codCliente, string usu_nombre, string usu_apellido, string usu_mail, string usu_login, string usu_psw, string usu_observacion, int? usu_codUsuarioUltMov)
        {
            string accion = usu_codigo == 0 ? Constantes.cSQL_INSERT : Constantes.cSQL_UPDATE;
            int codigoAccion = usu_codigo == 0 ? Constantes.cACCION_ALTA : Constantes.cACCION_MODIFICACION;
            int? codigoEstado = usu_codigo == 0 ? Constantes.cESTADO_ACTIVO : (int?)null;
            DataSet dsResultado = GestiónUsuario(usu_codigo, usu_codRol, usu_codCliente, usu_nombre, usu_apellido, usu_mail, usu_login, usu_psw, usu_observacion, usu_codUsuarioUltMov, codigoAccion, codigoEstado, null, accion);
            int resultado = -1;
            if (usu_codigo == 0)
            {
                if (dsResultado != null && dsResultado.Tables.Count > 0)
                {
                    if (dsResultado.Tables[0].Rows.Count > 0 && dsResultado.Tables[0].Rows[0]["usu_codigo"] != DBNull.Value)
                    {
                        resultado = Convert.ToInt32(dsResultado.Tables[0].Rows[0]["usu_codigo"]);
                    }
                }
            }
            else
            {
                resultado = usu_codigo;
            }
            return resultado;
        }
        public static List<cUsuario> RecuperarTodosUsuarios(string pFiltro)
        {
            List<cUsuario> lista = new List<cUsuario>();
            DataSet dsResultado = GestiónUsuario(null, null, null, null, null, null, null, null, null, null, null, null, pFiltro, Constantes.cSQL_SELECT);
            if (dsResultado != null && dsResultado.Tables.Count > 0)
            {
                foreach (DataRow item in dsResultado.Tables[0].Rows)
                {
                    lista.Add(ConvertToUsuario(item));
                }
            }
            return lista;
        }
        public static cUsuario RecuperarUsuarioPorId(int pIdUsuario)
        {
            cUsuario obj = null;
            DataSet dsResultado = GestiónUsuario(pIdUsuario, null, null, null, null, null, null, null, null, null, null, null, null, Constantes.cSQL_SELECT);
            if (dsResultado != null && dsResultado.Tables.Count > 0)
            {
                foreach (DataRow item in dsResultado.Tables[0].Rows)
                {
                    obj = ConvertToUsuario(item);
                    break;
                }
            }
            return obj;
        }
        public static void CambiarEstadoUsuarioPorId(int pIdUsuario, int pIdEstado, int pIdUsuarioEnSession)
        {
            GestiónUsuario(pIdUsuario, null, null, null, null, null, null, null, null, pIdUsuarioEnSession, Constantes.cACCION_CAMBIOESTADO, pIdEstado, null, Constantes.cSQL_ESTADO);
        }
        public static void CambiarContraseñaUsuario(int pIdUsuario, string pConstraseña, int? pIdUsuarioEnSession)
        {
            DataSet dsResultado = GestiónUsuario(pIdUsuario, null, null, null, null, null, null, pConstraseña, null, pIdUsuarioEnSession, Constantes.cACCION_CAMBIOCONTRASEÑA, null, null, Constantes.cSQL_CAMBIOCONTRASEÑA);
        }
        public static bool IsGrabarReglaRol(int pIdRol, List<cReglaPorRol> lista)
        {
            if (lista != null && lista.Count > 0)
            {
                string strXML = string.Empty;
                strXML += "<Root>";
                foreach (cReglaPorRol item in lista)
                {
                    List<XAttribute> listaAtributos = new List<XAttribute>();

                    listaAtributos.Add(new XAttribute("idRegla", item.idRegla));
                    listaAtributos.Add(new XAttribute("idRelacionReglaRol", item.idRelacionReglaRol));
                    listaAtributos.Add(new XAttribute("isActivo", item.isActivo));

                    if (item.isAgregado == null)
                    {

                    }
                    else
                    {
                        listaAtributos.Add(new XAttribute("isAgregado", item.isAgregado));
                    }
                    if (item.isEditado == null)
                    {
                    }
                    else
                    {
                        listaAtributos.Add(new XAttribute("isEditado", item.isEditado));
                    }
                    if (item.isEliminado == null)
                    {
                    }
                    else
                    {
                        listaAtributos.Add(new XAttribute("isEliminado", item.isEliminado));
                    }

                    XElement nodo = new XElement("Regla", listaAtributos);
                    strXML += nodo.ToString();
                }
                strXML += "</Root>";
                string parameXML = strXML;

                InsertarActualizarRelacionRolRegla(pIdRol, parameXML);
                return true;
            }
            return false;
        }
        public static List<cReglaPorRol> RecuperarTodasReglasRolPorIdRol(int pIdRol)
        {
            DataTable tablaAcciones = RecuperarTodasAccionesRol(pIdRol);
            List<cReglaPorRol> l = new List<cReglaPorRol>();
            foreach (DataRow item in tablaAcciones.Rows)
            {
                l.Add(ConvertToReglasRol(item));
            }
            return l;
        }
        public static cReglaPorRol ConvertToReglasRol(DataRow pItem)
        {
            cReglaPorRol acRol = new cReglaPorRol();
            if (pItem.Table.Columns.Contains("rgl_codRegla") && pItem["rgl_codRegla"] != DBNull.Value)
            {
                acRol.idRegla = Convert.ToInt32(pItem["rgl_codRegla"]);
            }
            if (pItem.Table.Columns.Contains("rrr_codRelacionRolRegla") && pItem["rrr_codRelacionRolRegla"] != DBNull.Value)
            {
                acRol.idRelacionReglaRol = Convert.ToInt32(pItem["rrr_codRelacionRolRegla"]);
            }
            if (pItem.Table.Columns.Contains("rrr_IsActivo") && pItem["rrr_IsActivo"] != DBNull.Value)
            {
                acRol.isActivo = Convert.ToBoolean(pItem["rrr_IsActivo"]);
            }
            else
            {
                acRol.isActivo = false;
            }
            if (pItem.Table.Columns.Contains("rrr_IsAgregar") && pItem["rrr_IsAgregar"] != DBNull.Value)
            {
                acRol.isAgregar = Convert.ToBoolean(pItem["rrr_IsAgregar"]);
            }
            else
            {
                acRol.isAgregar = false;
            }
            if (pItem.Table.Columns.Contains("rrr_IsEditar") && pItem["rrr_IsEditar"] != DBNull.Value)
            {
                acRol.isEditar = Convert.ToBoolean(pItem["rrr_IsEditar"]);
            }
            else
            {
                acRol.isEditar = false;
            }
            if (pItem.Table.Columns.Contains("rrr_IsEliminar") && pItem["rrr_IsEliminar"] != DBNull.Value)
            {
                acRol.isEliminar = Convert.ToBoolean(pItem["rrr_IsEliminar"]);
            }
            else
            {
                acRol.isEliminar = false;
            }
            return acRol;
        }
        public static string obtenerStringEstado(int pIdEstado)
        {
            string resultado = string.Empty;
            switch (pIdEstado.ToString())
            {
                case "1":
                    return Constantes.cESTADO_STRING_SINESTADO;
                case "2":
                    return Constantes.cESTADO_STRING_ACTIVO;
                case "3":
                    return Constantes.cESTADO_STRING_INACTIVO;
                default:
                    break;
            }
            return resultado;
        }
        public static cUsuario ConvertToUsuario(DataRow pItem)
        {
            cUsuario obj = new cUsuario();
            if (pItem.Table.Columns.Contains("usu_codigo") && pItem["usu_codigo"] != DBNull.Value)
            {
                obj.usu_codigo = Convert.ToInt32(pItem["usu_codigo"]);
            }
            if (pItem.Table.Columns.Contains("usu_codRol") && pItem["usu_codRol"] != DBNull.Value)
            {
                obj.usu_codRol = Convert.ToInt32(pItem["usu_codRol"]);
            }
            if (pItem.Table.Columns.Contains("usu_codCliente") && pItem["usu_codCliente"] != DBNull.Value)
            {
                obj.usu_codCliente = Convert.ToInt32(pItem["usu_codCliente"]);
                if (pItem.Table.Columns.Contains("cli_nombre") && pItem["cli_nombre"] != DBNull.Value)
                {
                    obj.cli_nombre = pItem["cli_nombre"].ToString();
                }
            }
            else
            {
                obj.usu_codCliente = null;
            }
            if (pItem.Table.Columns.Contains("usu_nombre") && pItem["usu_nombre"] != DBNull.Value)
            {
                obj.usu_nombre = pItem["usu_nombre"].ToString();
            }
            if (pItem.Table.Columns.Contains("usu_apellido") && pItem["usu_apellido"] != DBNull.Value)
            {
                obj.usu_apellido = pItem["usu_apellido"].ToString();
            }
            if (pItem.Table.Columns.Contains("NombreYapellido") && pItem["NombreYapellido"] != DBNull.Value)
            {
                obj.NombreYapellido = pItem["NombreYapellido"].ToString();
            }
            if (pItem.Table.Columns.Contains("usu_login") && pItem["usu_login"] != DBNull.Value)
            {
                obj.usu_login = pItem["usu_login"].ToString();
            }
            if (pItem.Table.Columns.Contains("usu_mail") && pItem["usu_mail"] != DBNull.Value)
            {
                obj.usu_mail = pItem["usu_mail"].ToString();
            }
            if (pItem.Table.Columns.Contains("usu_pswDesencriptado") && pItem["usu_pswDesencriptado"] != DBNull.Value)
            {
                obj.usu_pswDesencriptado = pItem["usu_pswDesencriptado"].ToString();
            }
            if (pItem.Table.Columns.Contains("rol_Nombre") && pItem["rol_Nombre"] != DBNull.Value)
            {
                obj.rol_Nombre = pItem["rol_Nombre"].ToString();
            }
            if (pItem.Table.Columns.Contains("usu_observacion") && pItem["usu_observacion"] != DBNull.Value)
            {
                obj.usu_observacion = pItem["usu_observacion"].ToString();
            }
            if (pItem.Table.Columns.Contains("usu_estado") && pItem["usu_estado"] != DBNull.Value)
            {
                obj.usu_estado = Convert.ToInt32(pItem["usu_estado"]);
                obj.usu_estadoToString = obtenerStringEstado(obj.usu_estado);
            }
            return obj;
        }
        public static cListaCheck ConvertListaCheck(DataRow pItem, List<cRegla> pListaReglaParametro)
        {
            cListaCheck obj = new cListaCheck();
            if (pItem.Table.Columns.Contains("rgl_codRegla") && pItem["rgl_codRegla"] != DBNull.Value)
            {
                obj.id = Convert.ToInt32(pItem["rgl_codRegla"]);
            }
            if (pItem.Table.Columns.Contains("rgl_Descripcion") && pItem["rgl_Descripcion"] != DBNull.Value)
            {
                obj.descripcion = pItem["rgl_Descripcion"].ToString();
            }
            if (pItem.Table.Columns.Contains("rgl_PalabraClave") && pItem["rgl_PalabraClave"] != DBNull.Value)
            {
                obj.palabra = pItem["rgl_PalabraClave"].ToString();
            }
            if (pItem.Table.Columns.Contains("Level") && pItem["Level"] != DBNull.Value)
            {
                obj.Nivel = Convert.ToInt32(pItem["Level"]);
            }
            if (pItem.Table.Columns.Contains("rgl_codReglaPadre") && pItem["rgl_codReglaPadre"] != DBNull.Value)
            {
                obj.idPadreRegla = Convert.ToInt32(pItem["rgl_codReglaPadre"]);
            }
            else
            {
                obj.idPadreRegla = null;
            }
            if (pItem.Table.Columns.Contains("rgl_codRegla") && pItem["rgl_codRegla"] != DBNull.Value)
            {
                obj.listaIdHijas = RecuperarTodosIdReglasHijas(Convert.ToInt32(pItem["rgl_codRegla"]), pListaReglaParametro);
            }
            obj.isGraficada = false;
            if (pItem.Table.Columns.Contains("rgl_IsAgregarSoporta") && pItem["rgl_IsAgregarSoporta"] != DBNull.Value && Convert.ToBoolean(pItem["rgl_IsAgregarSoporta"]))
            {
                obj.checkAgregar = 0;
            }
            else
            {
                obj.checkAgregar = -1;
            }
            if (pItem.Table.Columns.Contains("rgl_IsEditarSoporta") && pItem["rgl_IsEditarSoporta"] != DBNull.Value && Convert.ToBoolean(pItem["rgl_IsEditarSoporta"]))
            {
                obj.checkEditar = 0;
            }
            else
            {
                obj.checkEditar = -1;
            }
            if (pItem.Table.Columns.Contains("rgl_IsEliminarSoporta") && pItem["rgl_IsEliminarSoporta"] != DBNull.Value && Convert.ToBoolean(pItem["rgl_IsEliminarSoporta"]))
            {
                obj.checkEliminar = 0;
            }
            else
            {
                obj.checkEliminar = -1;
            }
            return obj;
        }
        public static cAcccionesRol ConvertToAcccionesRol(DataRow pItem)
        {
            cAcccionesRol acRol = new cAcccionesRol();
            if (pItem.Table.Columns.Contains("rgl_codRegla") && pItem["rgl_codRegla"] != DBNull.Value)
            {
                acRol.idRegla = Convert.ToInt32(pItem["rgl_codRegla"]);
            }
            if (pItem.Table.Columns.Contains("rgl_PalabraClave") && pItem["rgl_PalabraClave"] != DBNull.Value)
            {
                acRol.palabraClave = pItem["rgl_PalabraClave"].ToString();
            }
            if (pItem.Table.Columns.Contains("rrr_codRelacionRolRegla") && pItem["rrr_codRelacionRolRegla"] != DBNull.Value)
            {
                acRol.idReglaRol = Convert.ToInt32(pItem["rrr_codRelacionRolRegla"]);
            }
            if (pItem.Table.Columns.Contains("rrr_IsActivo") && pItem["rrr_IsActivo"] != DBNull.Value)
            {
                acRol.isActivo = Convert.ToBoolean(pItem["rrr_IsActivo"]);
            }
            else
            {
                acRol.isActivo = false;
            }
            if (pItem.Table.Columns.Contains("rrr_IsAgregar") && pItem["rrr_IsAgregar"] != DBNull.Value)
            {
                acRol.isAgregar = Convert.ToBoolean(pItem["rrr_IsAgregar"]);
            }
            else
            {
                acRol.isAgregar = false;
            }
            if (pItem.Table.Columns.Contains("rrr_IsEditar") && pItem["rrr_IsEditar"] != DBNull.Value)
            {
                acRol.isEditar = Convert.ToBoolean(pItem["rrr_IsEditar"]);
            }
            else
            {
                acRol.isEditar = false;
            }
            if (pItem.Table.Columns.Contains("rrr_IsEliminar") && pItem["rrr_IsEliminar"] != DBNull.Value)
            {
                acRol.isEliminar = Convert.ToBoolean(pItem["rrr_IsEliminar"]);
            }
            else
            {
                acRol.isEliminar = false;
            }
            return acRol;
        }
        public static cReglaPorRol ConvertToReglaPorRol(DataRow pItem)
        {
            cReglaPorRol obj = new cReglaPorRol();
            if (pItem.Table.Columns.Contains("rrr_codRegla") && pItem["rrr_codRegla"] != DBNull.Value)
            {
                obj.idRegla = Convert.ToInt32(pItem["rrr_codRegla"]);
            }
            if (pItem.Table.Columns.Contains("rrr_codRelacionRolRegla") && pItem["rrr_codRelacionRolRegla"] != DBNull.Value)
            {
                obj.idRelacionReglaRol = Convert.ToInt32(pItem["rrr_codRelacionRolRegla"]);
            }
            if (pItem.Table.Columns.Contains("rrr_IsActivo") && pItem["rrr_IsActivo"] != DBNull.Value)
            {
                obj.isActivo = Convert.ToBoolean(pItem["rrr_IsActivo"]);
            }
            if (pItem.Table.Columns.Contains("rrr_IsAgregar") && pItem["rrr_IsAgregar"] != DBNull.Value)
            {
                obj.isAgregar = Convert.ToBoolean(pItem["rrr_IsAgregar"]);
            }
            if (pItem.Table.Columns.Contains("rrr_IsEditar") && pItem["rrr_IsEditar"] != DBNull.Value)
            {
                obj.isEditar = Convert.ToBoolean(pItem["rrr_IsEditar"]);
            }
            if (pItem.Table.Columns.Contains("rrr_IsEliminar") && pItem["rrr_IsEliminar"] != DBNull.Value)
            {
                obj.isEliminar = Convert.ToBoolean(pItem["rrr_IsEliminar"]);
            }
            return obj;
        }
        public static cRol ConvertToRol(DataRow pItem)
        {
            cRol o = new cRol();
            if (pItem.Table.Columns.Contains("rol_codRol") && pItem["rol_codRol"] != DBNull.Value)
            {
                o.rol_codRol = Convert.ToInt32(pItem["rol_codRol"]);
            }
            if (pItem.Table.Columns.Contains("rol_Nombre") && pItem["rol_Nombre"] != DBNull.Value)
            {
                o.rol_Nombre = pItem["rol_Nombre"].ToString();
            }
            return o;
        }
        public static cRegla ConvertToRegla(DataRow pItem)
        {
            cRegla obj = new cRegla();
            if (pItem.Table.Columns.Contains("rgl_codRegla") && pItem["rgl_codRegla"] != DBNull.Value)
            {
                obj.rgl_codRegla = Convert.ToInt32(pItem["rgl_codRegla"]);
            }
            if (pItem.Table.Columns.Contains("rgl_Descripcion") && pItem["rgl_Descripcion"] != DBNull.Value)
            {
                obj.rgl_Descripcion = pItem["rgl_Descripcion"].ToString();
            }
            if (pItem.Table.Columns.Contains("rgl_PalabraClave") && pItem["rgl_PalabraClave"] != DBNull.Value)
            {
                obj.rgl_PalabraClave = pItem["rgl_PalabraClave"].ToString();
            }
            if (pItem.Table.Columns.Contains("rgl_IsAgregarSoporta") && pItem["rgl_IsAgregarSoporta"] != DBNull.Value)
            {
                obj.rgl_IsAgregarSoporta = Convert.ToBoolean(pItem["rgl_IsAgregarSoporta"]);
            }
            if (pItem.Table.Columns.Contains("rgl_IsEditarSoporta") && pItem["rgl_IsEditarSoporta"] != DBNull.Value)
            {
                obj.rgl_IsEditarSoporta = Convert.ToBoolean(pItem["rgl_IsEditarSoporta"]);
            }
            if (pItem.Table.Columns.Contains("rgl_IsEliminarSoporta") && pItem["rgl_IsEliminarSoporta"] != DBNull.Value)
            {
                obj.rgl_IsEliminarSoporta = Convert.ToBoolean(pItem["rgl_IsEliminarSoporta"]);
            }
            if (pItem.Table.Columns.Contains("rgl_codReglaPadre") && pItem["rgl_codReglaPadre"] != DBNull.Value)
            {
                obj.rgl_codReglaPadre = Convert.ToInt32(pItem["rgl_codReglaPadre"]);
            }
            return obj;
        }
        public static User ConvertToUser(DataRow pItem)
        {
            User o = new User();
            if (pItem.Table.Columns.Contains("usu_codigo") && pItem["usu_codigo"] != DBNull.Value)
            {
                o.usu_codigo = Convert.ToInt32(pItem["usu_codigo"]);
            }
            if (pItem.Table.Columns.Contains("usu_codRol") && pItem["usu_codRol"] != DBNull.Value)
            {
                o.usu_codRol = Convert.ToInt32(pItem["usu_codRol"]);
            }
            if (pItem.Table.Columns.Contains("cli_codigo") && pItem["cli_codigo"] != DBNull.Value)
            {
                o.cli_codigo = Convert.ToInt32(pItem["cli_codigo"]);
            }
            if (pItem.Table.Columns.Contains("usu_estado") && pItem["usu_estado"] != DBNull.Value)
            {
                o.cli_codigo = Convert.ToInt32(pItem["usu_estado"]);
            }
            if (pItem.Table.Columns.Contains("usu_login") && pItem["usu_login"] != DBNull.Value)
            {
                o.usu_login = pItem["usu_login"].ToString();
            }
            if (pItem.Table.Columns.Contains("usu_nombre") && pItem["usu_nombre"] != DBNull.Value)
            {
                o.usu_login = pItem["usu_nombre"].ToString();
            }
            if (pItem.Table.Columns.Contains("usu_apellido") && pItem["usu_apellido"] != DBNull.Value)
            {
                o.usu_login = pItem["usu_apellido"].ToString();
            }

            return o;
        }
    }
}