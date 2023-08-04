using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Interfaces
{
    public interface IPersistenciaCategoriaPreguntas
    {
        void AltaCategoria(EntidadesCompartidas.CategoriaPregunta pCategoria, EntidadesCompartidas.Administrador pLogueo);

        EntidadesCompartidas.CategoriaPregunta BuscarCategoria(String pCodigoCategoria, EntidadesCompartidas.Administrador pLogueo);

        void ModificarCategoria(EntidadesCompartidas.CategoriaPregunta pCategoria, EntidadesCompartidas.Administrador pLogueo);

        void BajaCategoria(EntidadesCompartidas.CategoriaPregunta pCategoria, EntidadesCompartidas.Administrador pLogueo);

        List<EntidadesCompartidas.CategoriaPregunta> ListarCategorias(EntidadesCompartidas.Administrador pLogueo);
    }
}
