using System.Collections.Generic;
using coreBasicNet5.Entities;
using coreBasicNet5.Entities.Authenticate;

namespace coreBasicNet5.Business
{
    public interface IAdminService
    {
        User InicioSession(string pNombreLogin, string pPassword, string pIp, string pHostName, string pUserAgent);
        cRol GetOneRol(int id);

        List<cRol> GetAllRol();

        cRol AddRol(cRol rol);
        cRol EditRol(int id, cRol rol);

        void DeleteRol(int id);
        cRegla GetOneRegla(int id);

        List<cRegla> GetAllRegla();

        cRegla AddRegla(cRegla regla);
        cRegla EditRegla(int id, cRegla regla);

        void DeleteRegla(int id);

        List<cListaCheck> GetAllReglaPorNivel();
        List<int> GetAllIdReglasHijas(int pIdRegla, List<cRegla> pListaRegla);
        cUsuario GetOneUsuario(int id);
        List<cUsuario> GetAllUsuario();
        cUsuario AddUsuario(cUsuario usuario);
        cUsuario EditUsuario(int id, cUsuario usuario);
        void DeleteUsuario(int id);
        List<cReglaPorRol> GetAllReglasRol(int id);
        bool EditReglasRol(int pIdRol, List<cReglaPorRol> lista);

    }
}