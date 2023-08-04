using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace Persistencia.Clases
{
    internal class PersistenciaCategoriaPregunta: Interfaces.IPersistenciaCategoriaPreguntas
    {
        //singleton
        private static PersistenciaCategoriaPregunta _instancia;
        private PersistenciaCategoriaPregunta() { }
        public static PersistenciaCategoriaPregunta GetInstance()
        {
            if (_instancia == null)
                _instancia = new PersistenciaCategoriaPregunta();
            return _instancia;
        }
        public void AltaCategoria(EntidadesCompartidas.CategoriaPregunta pCategoria, EntidadesCompartidas.Administrador pLogueo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pLogueo)); //aca deberia pasar el usuario logueado

            //defino sp
            SqlCommand _comando;
            _comando = new SqlCommand("AltaCategoria", _cnn);

            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoCategoria", pCategoria.CodigoCategoria);
            _comando.Parameters.AddWithValue("@Nombre", pCategoria.Nombre);


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
        public void BajaCategoria(EntidadesCompartidas.CategoriaPregunta pCategoria, EntidadesCompartidas.Administrador pLogueo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pLogueo));

            SqlCommand _comando = new SqlCommand("BajaCategoria", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoCategoria", pCategoria.CodigoCategoria);
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
        public void ModificarCategoria(EntidadesCompartidas.CategoriaPregunta pCategoria, EntidadesCompartidas.Administrador pLogueo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand _comando;
            _comando = new SqlCommand("ModificarCategoria", _cnn);

            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoCategoria", pCategoria.CodigoCategoria);
            _comando.Parameters.AddWithValue("@Nombre", pCategoria.Nombre);

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
        public EntidadesCompartidas.CategoriaPregunta BuscarCategoria(String pCodigoCategoria, EntidadesCompartidas.Administrador pLogueo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pLogueo));
            EntidadesCompartidas.CategoriaPregunta unaCategoriaPregunta = null;
            SqlCommand _comando;
            _comando = new SqlCommand("BuscarCategoria", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoCategoria", pCodigoCategoria);
            try
            {
                //conecto a la bd
                _cnn.Open();
                SqlDataReader lector = _comando.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Read();
                    unaCategoriaPregunta = new EntidadesCompartidas.CategoriaPregunta(pCodigoCategoria, (string)lector["Nombre"]);
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
            return unaCategoriaPregunta;
        }
        internal static EntidadesCompartidas.CategoriaPregunta BuscarTodosCategoria(String pCodigoCategoria)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.CnnLogin);
            EntidadesCompartidas.CategoriaPregunta unaCategoriaPregunta = null;
            SqlCommand _comando;
            _comando = new SqlCommand("BuscarTodosCategoria", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoCategoria", pCodigoCategoria);
            try
            {
                //conecto a la bd
                _cnn.Open();
                SqlDataReader lector = _comando.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Read();
                    unaCategoriaPregunta = new EntidadesCompartidas.CategoriaPregunta(pCodigoCategoria, (string)lector["Nombre"]);
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
            return unaCategoriaPregunta;
        }
        public List<EntidadesCompartidas.CategoriaPregunta> ListarCategorias(EntidadesCompartidas.Administrador pLogueo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pLogueo));
            EntidadesCompartidas.CategoriaPregunta _categoriaPregunta = null;
            List<EntidadesCompartidas.CategoriaPregunta> _lista = new List<EntidadesCompartidas.CategoriaPregunta>();

            SqlCommand _comando = new SqlCommand("ListarCategorias", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        _categoriaPregunta = new EntidadesCompartidas.CategoriaPregunta((string)_lector["CodigoCategoria"], (string)_lector["Nombre"]);
                        _lista.Add(_categoriaPregunta);
                    }
                }
                _lector.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return _lista;
        }
    }
}
