using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace Persistencia.Clases
{
    internal class PersistenciaPregunta: Interfaces.IPersistenciaPregunta
    {
        //singleton
        private static PersistenciaPregunta _instancia;
        private PersistenciaPregunta() { }
        public static PersistenciaPregunta GetInstance()
        {
            if (_instancia == null)
                _instancia = new PersistenciaPregunta();
            return _instancia;
        }

        public List<EntidadesCompartidas.Pregunta> ListadoPreguntasNuncaUsadas()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.CnnLogin);

            SqlCommand _comando = new SqlCommand("ListadoPreguntasNuncaUsadas", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            List<EntidadesCompartidas.Pregunta> _Lista = new List<EntidadesCompartidas.Pregunta>();
            EntidadesCompartidas.Pregunta _unaPregunta = null;

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
                        string _codigoPregunta = (string)_lector["CodigoPregunta"];
                        int _puntaje = (int)_lector["Puntaje"];
                        string _texto = (string)_lector["Texto"];
                        //string _codigoCategoria = (string)_lector["CodigoCategoria"];
                        EntidadesCompartidas.CategoriaPregunta unaCategoria = PersistenciaCategoriaPregunta.BuscarTodosCategoria((string)_lector["CodigoCategoria"]);//.BuscarCategoria((string)_lector[""], (EntidadesCompartidas.CategoriaPregunta)_lector["CodigoCategoria"]);
                        _unaPregunta = new EntidadesCompartidas.Pregunta(_codigoPregunta, _puntaje, _texto, PersistenciaRespuesta.GetInstancia().ListarRespuestas(_codigoPregunta), unaCategoria);
                        _Lista.Add(_unaPregunta);
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
        public List<EntidadesCompartidas.Pregunta> ListadoConPreguntasAsignadas(int codigoJuego, EntidadesCompartidas.Administrador pLogueo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pLogueo));
            SqlCommand _comando = new SqlCommand("JuegosConPreguntasAsignadas", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoJuego", codigoJuego);
            List<EntidadesCompartidas.Pregunta> _Lista = new List<EntidadesCompartidas.Pregunta>();
            EntidadesCompartidas.Pregunta _unaPregunta = null;
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
                        string _codigoPregunta = (string)_lector["CodigoPregunta"];
                        int _puntaje = (int)_lector["Puntaje"];
                        string _texto = (string)_lector["Texto"];
                        EntidadesCompartidas.CategoriaPregunta unaCategoria = PersistenciaCategoriaPregunta.BuscarTodosCategoria((string)_lector["CodigoCategoria"]);
                        _unaPregunta = new EntidadesCompartidas.Pregunta(_codigoPregunta, _puntaje, _texto, PersistenciaRespuesta.GetInstancia().ListarRespuestas(_codigoPregunta), unaCategoria);
                        _Lista.Add(_unaPregunta);
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
        public void EliminarPreguntaAsignada(EntidadesCompartidas.Juego pJuego, EntidadesCompartidas.Administrador pLogueo, EntidadesCompartidas.Pregunta pPregunta)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pLogueo));

            SqlCommand _comando = new SqlCommand("EliminarPreguntaAsignada", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoJuego", pJuego.CodigoJuego);
            _comando.Parameters.AddWithValue("@CodigoPregunta", pPregunta.CodigoPregunta);
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

        public void AsignarPreguntasAJuego(EntidadesCompartidas.Pregunta pPregunta, EntidadesCompartidas.Administrador pLogueo, EntidadesCompartidas.Juego pJuego)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pLogueo));

            SqlCommand _comando = new SqlCommand("AsignarPreguntasAJuego", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoJuego", pJuego.CodigoJuego);
            _comando.Parameters.AddWithValue("@CodigoPregunta", pPregunta.CodigoPregunta);
            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);
            try
            {
                // conecto a la bd
                _cnn.Open();
                _comando.ExecuteNonQuery(); //se ejecuta dentro de la TRN logica

                //verifico si hay errores
                int _Codcli = Convert.ToInt32(_ParmRetorno.Value);
                if (_Codcli == -1)
                    throw new Exception("Cliente ya existente");
                else if (_Codcli == -2)
                    throw new Exception("Error No Especificado");
                else if (_Codcli == -3)
                    throw new Exception("Error No Especificado");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }

        }
        public void AltaPregunta(EntidadesCompartidas.Pregunta pPregunta, EntidadesCompartidas.Administrador pLogueo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pLogueo));

            //defino sp
            SqlCommand _comando;
            _comando = new SqlCommand("AltaPregunta", _cnn);

            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoPregunta", pPregunta.CodigoPregunta);
            _comando.Parameters.AddWithValue("@Puntaje", pPregunta.Puntaje);
            _comando.Parameters.AddWithValue("@Texto", pPregunta.Texto);
            _comando.Parameters.AddWithValue("@CodigoCategoria", pPregunta.CodigoCategoria.CodigoCategoria);


            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);
            SqlTransaction _miTransaccion = null;

            try
            {
                //conecto a la bd
                _cnn.Open();

                _miTransaccion = _cnn.BeginTransaction();
                _comando.Transaction = _miTransaccion;
                //ejecuto comando de creacion de usuario SQLserver
                _comando.ExecuteNonQuery();

                //verifico si hay errores
                int _codPreg = Convert.ToInt32(_ParmRetorno.Value);
                if (_codPreg == -1)
                    throw new Exception("Error numero 1");
                else if (_codPreg == -2)
                    throw new Exception("Error No Especificado");

                foreach (EntidadesCompartidas.Respuesta unaRespuesta in pPregunta.ListaRespuesta)
                {
                    PersistenciaRespuesta.GetInstancia().Alta(unaRespuesta, pPregunta.CodigoPregunta, _miTransaccion);
                }

                _miTransaccion.Commit();
            }
            catch (Exception ex)
            {
                _miTransaccion.Rollback();
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }
        }
        public EntidadesCompartidas.Pregunta BuscarPregunta(string pCodigoPregunta, EntidadesCompartidas.Administrador pLogueo)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn(pLogueo));
            EntidadesCompartidas.Pregunta unaPregunta = null;
            SqlCommand _comando;
            _comando = new SqlCommand("BuscarPregunta", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@codigoPregunta", pCodigoPregunta);
            try
            {
                //conecto a la bd
                _cnn.Open();
                SqlDataReader lector = _comando.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Read();
                    unaPregunta = new EntidadesCompartidas.Pregunta(pCodigoPregunta, Convert.ToInt32(lector["puntaje"]), (string)lector["texto"], PersistenciaRespuesta.GetInstancia().ListarRespuestas(pCodigoPregunta), (PersistenciaCategoriaPregunta.BuscarTodosCategoria((string)lector["CodigoCategoria"])));
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
            return unaPregunta;
        }
    }
}
