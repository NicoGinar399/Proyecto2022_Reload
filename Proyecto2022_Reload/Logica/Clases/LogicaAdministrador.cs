using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    internal class LogicaAdministrador : Interfaces.ILogicaAdministrador
    {
        //singleton
        private static LogicaAdministrador _instancia;
        private LogicaAdministrador() { }
        public static LogicaAdministrador GetInstance()
        {
            if (_instancia == null)
                _instancia = new LogicaAdministrador();
            return _instancia;
        }

        //operaciones interface
        public void AltaAdministrador(EntidadesCompartidas.Administrador pAdmin, EntidadesCompartidas.Administrador pLogueo)
        {
            Persistencia.FabricaPersistencia.getPAdministrador().AltaAdministrador(pAdmin, pLogueo);
        }
        public void BajaAdministrador(EntidadesCompartidas.Administrador pAdmin, EntidadesCompartidas.Administrador pLogueo)
        {
            Persistencia.FabricaPersistencia.getPAdministrador().BajaAdministrador(pAdmin, pLogueo);
        }
        public void ModificarAdministrador(EntidadesCompartidas.Administrador pAdmin, EntidadesCompartidas.Administrador pLogueo)
        {
            Persistencia.FabricaPersistencia.getPAdministrador().ModificarAdministrador(pAdmin, pLogueo);
        }
        public EntidadesCompartidas.Administrador BuscarAdministrador(String pUsuario, EntidadesCompartidas.Administrador pLogueo)
        {
            return (Persistencia.FabricaPersistencia.getPAdministrador().BuscarAdministrador(pUsuario, pLogueo));
        }
        public EntidadesCompartidas.Administrador Logueo(string pUsuLogueo, string pContrasenia)
        {
            return Persistencia.FabricaPersistencia.getPAdministrador().Logueo(pUsuLogueo, pContrasenia);
        }
    }
}
