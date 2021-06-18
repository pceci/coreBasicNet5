using System;
using System.IO;
using System.Reflection;


namespace coreBasicNet5.Codigo
{
    public class Log
    {
        public static void LogErrorFile(string pantalla, string mensaje)
        {
            DateTime now = DateTime.Now;
            string nombreFile = now.Year.ToString("0000") + now.Month.ToString("00") + now.Day.ToString("00") + ".txt";
            Log.saveInFile("fecha: " + now.ToString() + " - pantalla: " + pantalla + " - mensaje :" + mensaje, nombreFile);
        }
        public static void LogError(MethodBase method, Exception pException, DateTime pFechaActual, params object[] values)
        {
            try
            {
                ParameterInfo[] parms = method.GetParameters();
                object[] namevalues = new object[2 * parms.Length];

                string Parameters = string.Empty;
                if (values.Length > 0)
                {
                    for (int i = 0, j = 0; i < parms.Length; i++, j += 2)
                    {
                        Parameters += "<" + parms[i].Name + ">";
                        /*if (values[i].GetType() == typeof(List<System.Data.SqlClient.SqlParameter>))
                        {
                            List<System.Data.SqlClient.SqlParameter> list = (List<System.Data.SqlClient.SqlParameter>)values[i];
                            for (int y = 0; y < list.Count; y++)
                            {
                                Parameters += String.Format("codProductoNombre = {0} || cantidad = {1} || IdTransfer = {2} || isOferta = {3}", list[y].codProductoNombre, list[y].cantidad, list[y].IdTransfer, list[y].isOferta);
                            }
                        }
                        else
                        { */
                        Parameters += values[i];
                        // }
                        Parameters += "</" + parms[i].Name + ">";
                    }
                }
                grabarLog_generico(method.Name, pException, pFechaActual, Parameters, "WEB");

            }
            catch (Exception ex)
            {
                LogErrorFile(MethodBase.GetCurrentMethod().ToString(), ex.ToString());
            }
        }
        public static void grabarLog_generico(string nombre, Exception pException, DateTime pFechaActual, string Parameters, string pTipo)
        {
            try
            {
                bool isNotGeneroError = capaAdmin.spError(nombre, Parameters, pException.Data != null ? pException.Data.ToString() : null,
                     pException.HelpLink != null ? pException.HelpLink.ToString() : null,
                     pException.InnerException != null ? pException.InnerException.ToString() : null,
                     pException.Message != null ? pException.Message.ToString() : null,
                    pException.Source != null ? pException.Source.ToString() : null,
                   pException.StackTrace != null ? pException.StackTrace.ToString() : null, DateTime.Now, pTipo);
            }
            catch (Exception ex)
            {
                LogErrorFile(MethodBase.GetCurrentMethod().ToString(), ex.ToString());
            }
        }
        public static void saveInFile(string pMensaje, string pNombreArchivo)
        {
            AccesoDisco.GrabarArchivo(pMensaje, pNombreArchivo, coreBasicNet5.Codigo.Helper.getPathSiteWeb + coreBasicNet5.Codigo.Helper.getPathLog);
        }
    }
}