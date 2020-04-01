using DicaDaCoruja.Entidades;
using System;
using System.Data.SqlClient;

namespace DicaDaCoruja.Dados
{
    public class SelectNumProduto
    {
        public AlertMenssagem ChecarNumero()
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT 'PRD'+REPLICATE('0',10 - LEN(CAST(ISNULL(MAX(PRD_ID) + 1, 1) AS CHAR)))+CAST(ISNULL(MAX(PRD_ID) + 1, 1) AS CHAR) FROM DBPRODUTO";
                Conexao.Conectar();
                var reader = command.ExecuteReader();
                AlertMenssagem Menssagem = null;
                Menssagem = new AlertMenssagem();
                if (reader.Read())
                {
                    Menssagem.ValMenssage = reader[0].ToString();
                }
                reader.Close();
                return Menssagem;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}
