using System;
using DicaDaCoruja.Entidades;
using System.Data.SqlClient;

namespace DicaDaCoruja.Dados
{
    public class CadUsuario
    {
        public RegisterAcesso ObterUsuarioESenha(string nomeusuario, string senha)
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT * FROM DBUSUARIO WHERE NUSU=@USUARIO AND SENH=@SENHA AND SUSU='A'";
                command.Parameters.AddWithValue("@USUARIO", nomeusuario);
                command.Parameters.AddWithValue("@SENHA", senha);
                Conexao.Conectar();
                var reader = command.ExecuteReader();
                RegisterAcesso usuario = null;
                while (reader.Read())
                {
                    usuario = new RegisterAcesso();
                    usuario.Nvl_id = Convert.ToInt32(reader["NVL_ID"]);
                    usuario.Usuario = reader["NUSU"].ToString();
                    usuario.Senha = reader["SENH"].ToString();
                }
                return usuario;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}
