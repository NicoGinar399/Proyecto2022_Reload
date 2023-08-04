using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Interfaces
{
    public interface IPersistenciaPregunta
    {
        void AltaPregunta(EntidadesCompartidas.Pregunta pPregunta, EntidadesCompartidas.Administrador pLogueo);

        void AsignarPreguntasAJuego(EntidadesCompartidas.Pregunta pPregunta, EntidadesCompartidas.Administrador pLogueo, EntidadesCompartidas.Juego pJuego);
        void EliminarPreguntaAsignada(EntidadesCompartidas.Juego pJuego, EntidadesCompartidas.Administrador pLogueo, EntidadesCompartidas.Pregunta pPregunta);

        List<EntidadesCompartidas.Pregunta> ListadoPreguntasNuncaUsadas();
        List<EntidadesCompartidas.Pregunta> ListadoConPreguntasAsignadas(int codigoJuego, EntidadesCompartidas.Administrador pLogueo);

        EntidadesCompartidas.Pregunta BuscarPregunta(string pCodigoPregunta, EntidadesCompartidas.Administrador pLogueo);
    }
}
