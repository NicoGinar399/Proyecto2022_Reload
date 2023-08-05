using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface ILogicaJuego
    {
        void AltaJuego(EntidadesCompartidas.Juego pJuego, EntidadesCompartidas.Administrador pLogueo);

        EntidadesCompartidas.Juego BuscarJuego(int pCodigoJuego, EntidadesCompartidas.Administrador pLogueo);

        void ModificarJuego(EntidadesCompartidas.Juego pJuego, EntidadesCompartidas.Administrador pLogueo);

        void BajaJuego(EntidadesCompartidas.Juego pJuego, EntidadesCompartidas.Administrador pLogueo);

        List<EntidadesCompartidas.Juego> ListadeJuegosConPreguntas();

        List<EntidadesCompartidas.Juego> ListadoDeJuegosVacios(EntidadesCompartidas.Administrador pLogueo);

        List<EntidadesCompartidas.Juego> ListadoDeJuegosNuncaUsados(EntidadesCompartidas.Administrador pLogueo);
    }
}
