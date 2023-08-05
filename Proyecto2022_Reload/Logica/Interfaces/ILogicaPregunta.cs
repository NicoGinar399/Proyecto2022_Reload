using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface ILogicaPregunta
    {
        List<EntidadesCompartidas.Pregunta> ListadoPreguntasNuncaUsadas();

        void EliminarPreguntaAsignada(EntidadesCompartidas.Juego pJuego, EntidadesCompartidas.Administrador pLogueo, EntidadesCompartidas.Pregunta pPregunta);

        void AsignarPreguntasAJuego(EntidadesCompartidas.Pregunta pPregunta, EntidadesCompartidas.Administrador pLogueo, EntidadesCompartidas.Juego pJuego);

        void AltaPregunta(EntidadesCompartidas.Pregunta pPregunta, EntidadesCompartidas.Administrador pLogueo);

        List<EntidadesCompartidas.Pregunta> ListadoConPreguntasAsignadas(int codigoJuego, EntidadesCompartidas.Administrador pLogueo);

        EntidadesCompartidas.Pregunta BuscarPregunta(string pCodigoPregunta, EntidadesCompartidas.Administrador pLogueo);
    }
}
