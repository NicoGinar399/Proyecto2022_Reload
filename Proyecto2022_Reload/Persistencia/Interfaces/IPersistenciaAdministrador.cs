﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Interfaces
{
    public interface IPersistenciaAdministrador
    {
        void AltaAdministrador(EntidadesCompartidas.Administrador pAdmin, EntidadesCompartidas.Administrador pLogueo);

        EntidadesCompartidas.Administrador BuscarAdministrador(String pUsuario, EntidadesCompartidas.Administrador pLogueo);

        void ModificarAdministrador(EntidadesCompartidas.Administrador pAdmin, EntidadesCompartidas.Administrador pLogueo);

        void BajaAdministrador(EntidadesCompartidas.Administrador pAdmin, EntidadesCompartidas.Administrador pLogueo);

        EntidadesCompartidas.Administrador Logueo(string pUsuLogueo, string pContrasenia);
    }
}
