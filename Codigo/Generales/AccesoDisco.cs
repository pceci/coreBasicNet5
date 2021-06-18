using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace coreBasicNet5.Codigo
{
    public class AccesoDisco
    {
        public static bool EliminarArchivo(string pRutaYNombreArchivo)
        {
            try
            {
                File.Delete(pRutaYNombreArchivo);
                return true;
            }
            catch (Exception ex)
            {
                Log.LogError(MethodBase.GetCurrentMethod(), ex, DateTime.Now, pRutaYNombreArchivo);
            }
            return false;
        }
        public static bool CopiarArchivo(string pRutaYNombreArchivoOrigen, string pRutaYNombreArchivoDestino)
        {
            try
            {
                File.Copy(pRutaYNombreArchivoOrigen, pRutaYNombreArchivoDestino);
                return true;
            }
            catch (Exception ex)
            {
                Log.LogError(MethodBase.GetCurrentMethod(), ex, DateTime.Now, pRutaYNombreArchivoOrigen, pRutaYNombreArchivoDestino);
            }
            return false;
        }
        public static void GrabarArchivo(string pMensaje, string pNombreArchivo, string pRuta)
        {
            try
            {
                string path = pRuta + "\\";
                if (Directory.Exists(path) == false)
                {
                    Directory.CreateDirectory(path);
                }
                string FilePath = path + pNombreArchivo;
                if (!File.Exists(FilePath))
                {
                    using (StreamWriter sw = File.CreateText(FilePath))
                    {
                        sw.WriteLine(pMensaje);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(FilePath))
                    {
                        sw.WriteLine(pMensaje);
                        sw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                //Log.LogError(MethodBase.GetCurrentMethod(), ex, DateTime.Now, pMensaje, pNombreArchivo, pRuta);
            }
        }
        public static List<string> LeerArchivo(string pNombreArchivoMasRuta)
        {
            List<string> l = new List<string>();
            try
            {
                StreamReader sr = new StreamReader(pNombreArchivoMasRuta);
                string line = sr.ReadLine();
                while (line != null)
                {
                    l.Add(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                Log.LogError(MethodBase.GetCurrentMethod(), ex, DateTime.Now, pNombreArchivoMasRuta);
                return null;
            }
            return l;
        }
    }
}