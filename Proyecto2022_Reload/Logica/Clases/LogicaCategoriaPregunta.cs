using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    internal class LogicaCategoriaPregunta: Interfaces.ILogicaCategoriaPregunta
    {
        //singleton
        private static LogicaCategoriaPregunta _instancia;
        private LogicaCategoriaPregunta() { }
        public static LogicaCategoriaPregunta GetInstance()
        {
            if (_instancia == null)
                _instancia = new LogicaCategoriaPregunta();
            return _instancia;
        }

        //operaciones interface
        public void AltaCategoria(EntidadesCompartidas.CategoriaPregunta pCategoria, EntidadesCompartidas.Administrador pLogueo)
        {
            Persistencia.FabricaPersistencia.getPCategoriaPreguntas().AltaCategoria(pCategoria, pLogueo);
        }
        public void BajaCategoria(EntidadesCompartidas.CategoriaPregunta pCategoria, EntidadesCompartidas.Administrador pLogueo)
        {
            Persistencia.FabricaPersistencia.getPCategoriaPreguntas().BajaCategoria(pCategoria, pLogueo);
        }
        public void ModificarCategoria(EntidadesCompartidas.CategoriaPregunta pCategoria, EntidadesCompartidas.Administrador pLogueo)
        {
            Persistencia.FabricaPersistencia.getPCategoriaPreguntas().ModificarCategoria(pCategoria, pLogueo);
        }
        public EntidadesCompartidas.CategoriaPregunta BuscarCategoria(String pCodigoCategoria, EntidadesCompartidas.Administrador pLogueo)
        {
            return (Persistencia.FabricaPersistencia.getPCategoriaPreguntas().BuscarCategoria(pCodigoCategoria, pLogueo));
        }
        public List<EntidadesCompartidas.CategoriaPregunta> ListarCategorias(EntidadesCompartidas.Administrador pLogueo)
        {
            return (Persistencia.FabricaPersistencia.getPCategoriaPreguntas().ListarCategorias(pLogueo));
        }
    }
}
