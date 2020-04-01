using DicaDaCoruja.Entidades;
using System.Data.SqlClient;

namespace DicaDaCoruja.Dados
{
    public class UpdateCommand
    {
        public AlertMenssagem GerarUpdate(string ValTabela, string ValID, string ValCampo, string ValAtualizar)
        {
            string ValCommand = "";
            AlertMenssagem Menssagem = null;
            Menssagem = new AlertMenssagem();
            try
            {
                if (ValTabela == "ANUNCIOS")
                {
                    ValCommand = "UPDATE DBANUNCIOS SET " + ValCampo + "=" + ValAtualizar + " WHERE ANU_ID=" + ValID;
                }
                else if (ValTabela == "PAINEL")
                {
                    ValCommand = "UPDATE DBPAINEL SET " + ValCampo + "=" + ValAtualizar + " WHERE PNL_ID=" + ValID;
                }
                else if (ValTabela == "PRODUTOS")
                {
                    ValCommand = "UPDATE DBPRODUTO SET " + ValCampo + "=" + ValAtualizar + " WHERE PRD_ID=" + ValID;
                }
                else if (ValTabela == "FORNECEDOR")
                {
                    ValCommand = "UPDATE DBFORNECEDOR SET " + ValCampo + "=" + ValAtualizar + " WHERE FRN_ID=" + ValID;
                }
                else if (ValTabela == "CATEGORIA")
                {
                    ValCommand = "UPDATE DBCATEGORIA SET " + ValCampo + "=" + ValAtualizar + " WHERE CAT_ID=" + ValID;
                }
                else if (ValTabela == "CIDADE")
                {
                    ValCommand = "UPDATE DBCIDADE SET " + ValCampo + "=" + ValAtualizar + " WHERE CID_ID=" + ValID;
                }
                SqlCommand comando = new SqlCommand(ValCommand, Conexao.connection);
                Conexao.Conectar();
                comando.ExecuteNonQuery();
                Menssagem.ValMenssage = "Registro atualizado com sucesso";
                return Menssagem;
            }
            catch
            {
                Menssagem.ValMenssage = "Não foi possível atualizar o registro";
                return Menssagem;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}
