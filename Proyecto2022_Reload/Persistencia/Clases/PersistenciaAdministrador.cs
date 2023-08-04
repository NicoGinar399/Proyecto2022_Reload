using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace Persistencia.Clases
{
    internal class PersistenciaAdministrador: Interfaces.IPersistenciaAdministrador
    {
        //singleton
        private static PersistenciaAdministrador _instancia;
        private PersistenciaAdministrador() { }
        public static PersistenciaAdministrador GetInstance()
        {
            if (_instancia == null)
                _instancia = new PersistenciaAdministrador();
            return _instancia;
        }
        public EntidadesCompartidas.Administrador Logueo(string pUsuLogueo, string pContrasenia)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.CnnLogin);
            EntidadesCompartidas.Administrador unAdministrador = null;
            SqlCommand _comando;
            _comando = new SqlCommand("LoginAdmin", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@UsuarioLogueo", pUsuLogueo);
            _comando.Parameters.AddWithValue("@Contrasenia", pContrasenia);
            try
            {
                //conecto a la bd
                _cnn.Open();
                SqlDataReader lector = _comando.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Read();
                    unAdministrador = new EntidadesCompartidas.Administrador(pUsuLogueo, pContrasenia, (string)lector["NombreCompleto"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return unAdministrador;
        }
        //operaciones
        internal static EntidadesCompartidas.Administrador BuscarTodosAdminsitrador(String pUsuario)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.CnnLogin);
            EntidadesCompartidas.Administrador unAdministrador = null;
            SqlCommand _comando;
            _comando = new SqlCommand("BuscarTodosLosAdministradores", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@UsuarioLogueo", pUsuario);
            try
            {
                //conecto a la bd
                _cnn.Open();
                SqlDataReader lector = _comando.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Read();
                    unAdministrador = new EntidadesCompartidas.Administrador(pUsuario, (string)lector["Contrasenia"], (string)lector["NombreCompleto"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return unAdministrador;
        }

        public EntidadesCompartidas.Administrador BuscarAdministrador(String pUsuario, EntidadesCompartidas.Administrador pLogueo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pLogueo));
            EntidadesCompartidas.Administrador unAdministrador = null;
            SqlCommand _comando;
            _comando = new SqlCommand("BuscarAdministrador", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@UsuarioLogueo", pUsuario);
            try
            {
                //conecto a la bd
                _cnn.Open();
                SqlDataReader lector = _comando.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Read();
                    unAdministrador = new EntidadesCompartidas.Administrador(pUsuario, (string)lector["Contrasenia"], (string)lector["NombreCompleto"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return unAdministrador;
        }
        public void ModificarAdministrador(EntidadesCompartidas.Administrador pAdmin, EntidadesCompartidas.Administrador pLogueo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pAdmin));
            SqlCommand _comando;
            _comando = new SqlCommand("ModificarAdministrador", _cnn);

            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@UsuarioLogueo", pAdmin.UsuarioLogueo);
            _comando.Parameters.AddWithValue("@Contrasenia", pAdmin.Contrasenia);
            _comando.Parameters.AddWithValue("@NombreCompleto", pAdmin.NombreCompleto);

            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            try
            {
                _cnn.Open();

                _comando.ExecuteNonQuery();

                int _codAdmin = Convert.ToInt32(_ParmRetorno.Value);
                if (_codAdmin == -1)
                    throw new Exception("Error numero 1");
                else if (_codAdmin == -2)
                    throw new Exception("Error numero 2");
                else if (_codAdmin == -3)
                    throw new Exception("Error numero 3");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }

        }

        public void BajaAdministrador(EntidadesCompartidas.Administrador pAdmin, EntidadesCompartidas.Administrador pLogueo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pAdmin));

            SqlCommand _comando = new SqlCommand("BajaAdministrador", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@UsuarioLogueo", pAdmin.UsuarioLogueo);
            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();
                //tiene 5 return diferente en caso de error, no se si deberia tener uno para cada uno
                int _codAdmin = Convert.ToInt32(_ParmRetorno.Value);
                if (_codAdmin == -1)
                    throw new Exception("Error numero 1");
                else if (_codAdmin == -2)
                    throw new Exception("Error numero 2");
                else if (_codAdmin == -3)
                    throw new Exception("Error numero 3");
                else if (_codAdmin == -2)
                    throw new Exception("Error numero 4");
                else if (_codAdmin == -3)
                    throw new Exception("Error numero 5");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
        }
        public void AltaAdministrador(EntidadesCompartidas.Administrador pAdmin, EntidadesCompartidas.Administrador pLogueo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pAdmin)); //aca deberia pasar el usuario logueado

            //defino sp
            SqlCommand _comando;
            _comando = new SqlCommand("AltaAdministrador", _cnn);

            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@UsuarioLogueo", pAdmin.UsuarioLogueo);
            _comando.Parameters.AddWithValue("@Contrasenia", pAdmin.Contrasenia);
            _comando.Parameters.AddWithValue("@NombreCompleto", pAdmin.NombreCompleto);

            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            try
            {
                //conecto a la bd
                _cnn.Open();

                //ejecuto comando de creacion de usuario SQLserver
                _comando.ExecuteNonQuery();

                //verifico si hay errores
                int _codAdmin = Convert.ToInt32(_ParmRetorno.Value);
                if (_codAdmin == -1)
                    throw new Exception("Error numero 1");
                else if (_codAdmin == -2)
                    throw new Exception("Error numero 2");
                else if (_codAdmin == -3)
                    throw new Exception("Error numero 3");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }

        }
    }
}
