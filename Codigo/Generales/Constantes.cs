namespace coreBasicNet5.Codigo
{
    public static class Constantes
    {
        // public static string cArchivo_LogErrorTxt
        // {
        //     get { return @"LogError.txt"; }
        // }
        public static string cSQL_INSERT
        {
            get { return "INSERT"; }
        }
        public static string cSQL_UPDATE
        {
            get { return "UPDATE"; }
        }
        public static string cSQL_SELECT
        {
            get { return "SELECT"; }
        }
        public static string cSQL_COMBO
        {
            get { return "COMBO"; }
        }
        public static string cSQL_ESTADO
        {
            get { return "ESTADO"; }
        }
        public static string cSQL_DELETE
        {
            get { return "DELETE"; }
        }
        public static string cSQL_CAMBIOCONTRASEÑA
        {
            get { return "CAMBIOCONTRASEÑA"; }
        }
        //public static string cSQL_ESCONTRASEÑACORRECTA
        //{
        //    get { return "ESCONTRASEÑACORRECTA"; }
        //}
        public static string cSQL_PUBLICAR
        {
            get { return "PUBLICAR"; }
        }
        public static string cSQL_SUBIR
        {
            get { return "SUBIR"; }
        }
        public static string cSQL_BAJAR
        {
            get { return "BAJAR"; }
        }

        public static string cDESC
        {
            get { return "DESC"; }
        }
        public static string cASC
        {
            get { return "ASC"; }
        }
        public static int cACCION_ALTA
        {
            get { return 1; }
        }
        public static int cACCION_MODIFICACION
        {
            get { return 2; }
        }
        public static int cACCION_CAMBIOESTADO
        {
            get { return 3; }
        }
        public static int cACCION_CAMBIOCONTRASEÑA
        {
            get { return 4; }
        }
        public static int cACCION_CAMBIOORDEN
        {
            get { return 5; }
        }
        public static int cACCION_ISPUBLICAR
        {
            get { return 6; }
        }
        public static int cACCION_ELIMINAR
        {
            get { return 7; }
        }
        public static int cESTADO_SINESTADO
        {
            get { return 1; }
        }
        public static int cESTADO_ACTIVO
        {
            get { return 2; }
        }
        public static int cESTADO_INACTIVO
        {
            get { return 3; }
        }
        public static int cESTADO_SINLEER
        {
            get { return 4; }
        }
        public static int cESTADO_LEIDO
        {
            get { return 5; }
        }
        public static string cESTADO_STRING_SINESTADO
        {
            get { return "Sin Estado"; }
        }
        public static string cESTADO_STRING_ACTIVO
        {
            get { return "Activo"; }
        }
        public static string cESTADO_STRING_INACTIVO
        {
            get { return "Inactivo"; }
        }
    }
}