using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    internal class LogicaPregunta: Interfaces.ILogicaPregunta
    {
        //singleton
        private static LogicaPregunta _instancia;
        private LogicaPregunta() { }
        public static LogicaPregunta GetInstance()
        {
            if (_instancia == null)
                _instancia = new LogicaPregunta();
            return _instancia;
        }

        public List<EntidadesCompartidas.Pregunta> ListadoPreguntasNuncaUsadas()
        {
            return Persistencia.FabricaPersistencia.getPPregunta().ListadoPreguntasNuncaUsadas();
        }
        public void EliminarPreguntaAsignada(EntidadesCompartidas.Juego pJuego, EntidadesCompartidas.Administrador pLogueo, EntidadesCompartidas.Pregunta pPregunta)
        {
            Persistencia.FabricaPersistencia.getPPregunta().EliminarPreguntaAsignada(pJuego, pLogueo, pPregunta);
        }
        public void AsignarPreguntasAJuego(EntidadesCompartidas.Pregunta pPregunta, EntidadesCompartidas.Administrador pLogueo, EntidadesCompartidas.Juego pJuego)
        {
            Persistencia.FabricaPersistencia.getPPregunta().AsignarPreguntasAJuego(pPregunta, pLogueo, pJuego);
        }
        public void AltaPregunta(EntidadesCompartidas.Pregunta pPregunta, EntidadesCompartidas.Administrador pLogueo)
        {
            Persistencia.FabricaPersistencia.getPPregunta().AltaPregunta(pPregunta, pLogueo);
        }
        public List<EntidadesCompartidas.Pregunta> ListadoConPreguntasAsignadas(int codigoJuego, EntidadesCompartidas.Administrador pLogueo)
        {
            return Persistencia.FabricaPersistencia.getPPregunta().ListadoConPreguntasAsignadas(codigoJuego, pLogueo);
        }
        public EntidadesCompartidas.Pregunta BuscarPregunta(string pCodigoPregunta, EntidadesCompartidas.Administrador pLogueo)
        {
            return (Persistencia.FabricaPersistencia.getPPregunta().BuscarPregunta(pCodigoPregunta, pLogueo));
        }
    }
}
