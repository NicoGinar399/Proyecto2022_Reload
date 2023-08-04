using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace Persistencia.Clases
{
    internal class PersistenciaJuego : Interfaces.IPersistenciaJuego
    {
        //singleton
        private static PersistenciaJuego _instancia;
        private PersistenciaJuego() { }
        public static PersistenciaJuego GetInstance()
        {
            if (_instancia == null)
                _instancia = new PersistenciaJuego();
            return _instancia;
        }
        public void AltaJuego(EntidadesCompartidas.Juego pJuego, EntidadesCompartidas.Administrador pLogueo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pLogueo)); //aca deberia pasar el usuario logueado

            //defino sp
            SqlCommand _comando;
            _comando = new SqlCommand("AltaJuego", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@Dificultad", pJuego.Dificultad);
            _comando.Parameters.AddWithValue("@UsuarioLogueo", pJuego.Administrador.UsuarioLogueo);


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
                int _codJuego = Convert.ToInt32(_ParmRetorno.Value);
                if (_codJuego == -1)
                    throw new Exception("Error numero 1");

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
        public void BajaJuego(EntidadesCompartidas.Juego pJuego, EntidadesCompartidas.Administrador pLogueo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pLogueo));

            SqlCommand _comando = new SqlCommand("BajaJuego", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoJuego", pJuego.CodigoJuego);
            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            try
            {
                _cnn.Open();
                _comando.ExecuteNonQuery();
                int _codJuego = Convert.ToInt32(_ParmRetorno.Value);
                if (_codJuego == -1)
                    throw new Exception("Juego con jugada realizada, no se puede eliminar: Error numero 1");
                else if (_codJuego == -2)
                    throw new Exception("No existe el juego: Error numero 2");
                else if (_codJuego == -3)
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
        public void ModificarJuego(EntidadesCompartidas.Juego pJuego, EntidadesCompartidas.Administrador pLogueo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand _comando;
            _comando = new SqlCommand("ModificarJuego", _cnn);

            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoJuego", pJuego.CodigoJuego);
            _comando.Parameters.AddWithValue("@Dificultad", pJuego.Dificultad);
            _comando.Parameters.AddWithValue("@UsuarioLogueo", pJuego.Administrador.UsuarioLogueo);

            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            try
            {
                _cnn.Open();

                _comando.ExecuteNonQuery();

                int _codJuego = Convert.ToInt32(_ParmRetorno.Value);
                if (_codJuego == -1)
                    throw new Exception("Error numero 1");
                else if (_codJuego == -2)
                    throw new Exception("Error numero 2");
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
        public EntidadesCompartidas.Juego BuscarJuego(int pCodigoJuego, EntidadesCompartidas.Administrador pLogueo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pLogueo));
            EntidadesCompartidas.Juego unJuego = null;
            SqlCommand _comando;
            _comando = new SqlCommand("BuscarJuego", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoJuego", pCodigoJuego);
            try
            {
                //conecto a la bd
                _cnn.Open();
                SqlDataReader lector = _comando.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Read();
                    /*EntidadesCompartidas.Administrador unaAdministrador = PersistenciaAdministrador.BuscarTodosAdminsitrador((string)lector["UsuarioLogueo"]);*///PersistenciaCategoriaPregunta.BuscarTodosCategoria((string)_lector["CodigoCategoria"]);
                    unJuego = new EntidadesCompartidas.Juego(pCodigoJuego, (DateTime)lector["Fecha"], (string)lector["Dificultad"], (PersistenciaAdministrador.BuscarTodosAdminsitrador((string)lector["UsuarioLogueo"])));//(EntidadesCompartidas.Administrador)lector["UsuarioLogueo"]);
                    //habria que ver el ultimo dato del lector
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
            return unJuego;
        }
        public List<EntidadesCompartidas.Juego> ListadeJuegosConPreguntas()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.CnnLogin);

            SqlCommand _comando = new SqlCommand("ListadeJuegosConPreguntas", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            List<EntidadesCompartidas.Juego> _Lista = new List<EntidadesCompartidas.Juego>();
            EntidadesCompartidas.Juego _unJuego = null;

            try
            {
                //me conecto
                _cnn.Open();

                //ejecuto consulta
                SqlDataReader _lector = _comando.ExecuteReader();

                //verifico si hay telefonos
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        int _codigoJuego = (int)_lector["CodigoJuego"];
                        DateTime _fecha = (DateTime)_lector["Fecha"];
                        string _Dificultad = (string)_lector["Dificultad"];
                        EntidadesCompartidas.Administrador unAdmin = PersistenciaAdministrador.BuscarTodosAdminsitrador((string)_lector["UsuarioLogueo"]);//(EntidadesCompartidas.Administrador)_lector["UsuarioLogueo"];
                        _unJuego = new EntidadesCompartidas.Juego(_codigoJuego, _fecha, _Dificultad, unAdmin);
                        _Lista.Add(_unJuego);
                    }
                }

                _lector.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }

            //retorno la lista de clientes
            return _Lista;
        }
        public List<EntidadesCompartidas.Juego> ListadoDeJuegosVacios(EntidadesCompartidas.Administrador pLogueo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pLogueo));

            SqlCommand _comando = new SqlCommand("JuegosVacios", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            List<EntidadesCompartidas.Juego> _Lista = new List<EntidadesCompartidas.Juego>();
            EntidadesCompartidas.Juego _unJuego = null;

            try
            {
                //me conecto
                _cnn.Open();

                //ejecuto consulta
                SqlDataReader _lector = _comando.ExecuteReader();

                //verifico si hay telefonos
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        int _codigoJuego = (int)_lector["CodigoJuego"];
                        DateTime _fecha = (DateTime)_lector["Fecha"];
                        string _Dificultad = (string)_lector["Dificultad"];
                        EntidadesCompartidas.Administrador unAdmin = PersistenciaAdministrador.BuscarTodosAdminsitrador((string)_lector["UsuarioLogueo"]);
                        _unJuego = new EntidadesCompartidas.Juego(_codigoJuego, _fecha, _Dificultad, unAdmin);
                        _Lista.Add(_unJuego);
                    }
                }

                _lector.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }

            //retorno la lista de clientes
            return _Lista;
        }
        public List<EntidadesCompartidas.Juego> ListadoDeJuegosNuncaUsados(EntidadesCompartidas.Administrador pLogueo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pLogueo));

            SqlCommand _comando = new SqlCommand("JuegosNuncaUsados", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            List<EntidadesCompartidas.Juego> _Lista = new List<EntidadesCompartidas.Juego>();
            EntidadesCompartidas.Juego _unJuego = null;

            try
            {
                //me conecto
                _cnn.Open();

                //ejecuto consulta
                SqlDataReader _lector = _comando.ExecuteReader();

                //verifico si hay telefonos
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        int _codigoJuego = (int)_lector["CodigoJuego"];
                        DateTime _fecha = (DateTime)_lector["Fecha"];
                        string _Dificultad = (string)_lector["Dificultad"];
                        EntidadesCompartidas.Administrador unAdmin = PersistenciaAdministrador.BuscarTodosAdminsitrador((string)_lector["UsuarioLogueo"]);
                        _unJuego = new EntidadesCompartidas.Juego(_codigoJuego, _fecha, _Dificultad, unAdmin);
                        _Lista.Add(_unJuego);
                    }
                }

                _lector.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }

            //retorno la lista de clientes
            return _Lista;
        }
    }
}
