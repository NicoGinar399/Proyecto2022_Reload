using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Administrador
    {
        //nota hacer controles

        //Atributos
        private string _usuarioLogueo;
        private string _contrasenia;
        private string _nombreCompleto;

        //Propiedades
        public string UsuarioLogueo
        {
            get { return _usuarioLogueo; }
            set
            {
                if (value.Length > 0 && value.Length < 26)
                    _usuarioLogueo = value;
                else
                    throw new Exception("El usuario debe ser mayor a 0 y menor de 25 caracteres");
            }
        }
        public string Contrasenia
        {
            get { return _contrasenia; }
            set
            {
                if (value.Length <= 20)
                    _contrasenia = value;
                else
                    throw new Exception("La contraseña debe ser menor de 21 caracteres");
            }
        }
        public string NombreCompleto
        {
            get { return _nombreCompleto; }
            set
            {
                if (value.Length > 0 && value.Length <= 30)
                    _nombreCompleto = value;
                else
                    throw new Exception("La contraseña debe ser menor o igual a 30 caracteres");
            }
        }
        //Constructor
        public Administrador(string pUsuarioLogueo, string pContrasenia, string pNombreCompleto)
        {
            UsuarioLogueo = pUsuarioLogueo;
            Contrasenia = pContrasenia;
            NombreCompleto = pNombreCompleto;
        }
    }
}
