using DicaDaCoruja.Entidades;
using System.Data.SqlClient;

namespace DicaDaCoruja.Dados
{
    public class InsertCommand
    {
        public AlertMenssagem GerarInsert(string ValTabela, string ValInsert1, string ValInsert2, string ValInsert3, string ValInsert4, string ValInsert5, string ValInsert6, string ValInsert7, string ValInsert8, string ValInsert9, string ValInsert10, string ValInsert11, string ValInsert12, string ValInsert13)
        {
            string ValCommand = "";
            AlertMenssagem Menssagem = null;
            Menssagem = new AlertMenssagem();
            try
            {
                if (ValTabela == "LOG")
                {
                    ValCommand = "INSERT INTO DBLOGACESSO (RQIP, VURL, DATA) VALUES ('" + ValInsert1 + "', '" + ValInsert2 + "', GETDATE())";
                }
                else if (ValTabela == "ANUNCIOS")
                {
                    ValCommand = "INSERT INTO DBANUNCIOS (PRD_ID, DINI, DFIM, PREC, FRN_ID, TIPO, LINK, CONT, VALO, PERI) VALUES (" + ValInsert1 + ", CONVERT(DATETIME,'" + ValInsert2 + "',103), CONVERT(DATETIME,'" + ValInsert3 + "',103), " + ValInsert4 + ", " + ValInsert5 + ", UPPER('" + ValInsert6.Substring(3) + "'), '" + ValInsert7 + "', (SELECT CONT FROM DBFORNECEDOR WHERE FRN_ID=" + ValInsert5 + "), (SELECT CUST FROM DBTIPO WHERE CONT=(SELECT CONT FROM DBFORNECEDOR WHERE FRN_ID = " + ValInsert5 + ") AND TIPO=UPPER('" + ValInsert6.Substring(3) + "') AND PERI=UPPER('" + ValInsert6.Substring(0, 3) + "')), UPPER('" + ValInsert6.Substring(0, 3) + "'))";
                }
                else if (ValTabela == "PAINEL")
                {
                    ValCommand = "INSERT INTO DBPAINEL (DINI, DFIM, FRN_ID, DPNL, FOTO, LINK, CONT, VALO, PERI) VALUES (CONVERT(DATETIME,'" + ValInsert1 + "',103), CONVERT(DATE, '" + ValInsert2 + "', 103), " + ValInsert3 + ", UPPER('" + ValInsert4 + "'), '" + ValInsert5 + "', '" + ValInsert6 + "', (SELECT CONT FROM DBFORNECEDOR WHERE FRN_ID=" + ValInsert3 + "), (SELECT CUST FROM DBTIPO WHERE CONT=(SELECT CONT FROM DBFORNECEDOR WHERE FRN_ID = " + ValInsert3 + ") AND TIPO=UPPER('" + ValInsert7.Substring(3) + "') AND PERI=UPPER('" + ValInsert7.Substring(0, 3) + "')), UPPER('" + ValInsert7.Substring(0, 3) + "'))";
                }
                else if (ValTabela == "PRODUTO")
                {
                    ValCommand = "INSERT INTO DBPRODUTO (CAT_ID, PROD, PDES, FOTO) VALUES (" + ValInsert1 + ", UPPER('" + ValInsert2 + "'), UPPER('" + ValInsert3 + "'), '" + ValInsert4 + "')";
                }
                else if (ValTabela == "FORNECEDOR")
                {
                    ValCommand = "INSERT INTO DBFORNECEDOR (GRUP, FORN, LOJA, CNPJ, RAZA, NCEP, RUAV, NUME, BAIR, CIDA, ESTA, LINK, CONT) VALUES (LTRIM(RTRIM(UPPER('" + ValInsert1 + "'))), LTRIM(RTRIM(UPPER('" + ValInsert2 + "'))), CAST('" + ValInsert3 + "' AS INT), UPPER('" + ValInsert4 + "'), LTRIM(RTRIM(UPPER('" + ValInsert5 + "'))), CAST('" + ValInsert6 + "' AS NUMERIC), LTRIM(RTRIM(UPPER('" + ValInsert7 + "'))), CAST('" + ValInsert8 + "' AS INT), UPPER('" + ValInsert9 + "'), UPPER('" + ValInsert10 + "'), UPPER('" + ValInsert11 + "'), '" + ValInsert12 + "', '" + ValInsert13 + "')";
                }
                else if (ValTabela == "CATEGORIA")
                {
                    ValCommand = "INSERT INTO DBCATEGORIA (CATE, CPAI) VALUES (UPPER('" + ValInsert1 + "'), UPPER('" + ValInsert2 + "'))";
                }
                else if (ValTabela == "CIDADE")
                {
                    ValCommand = "INSERT INTO DBCIDADE (CIDA, ESTA) VALUES (UPPER('" + ValInsert1 + "'), UPPER('" + ValInsert2 + "'))";
                }
                else if (ValTabela == "USUARIO")
                {
                    ValCommand = "INSERT INTO DBUSUARIO (NUSU, SENH, FRN_ID) VALUES (UPPER('" + ValInsert1 + "'), UPPER('" + ValInsert2 + "'), " + ValInsert3 + ")";
                }
                SqlCommand comando = new SqlCommand(ValCommand, Conexao.connection);
                Conexao.Conectar();
                comando.ExecuteNonQuery();
                Menssagem.ValMenssage = "Registro inserido com sucesso";
                return Menssagem;
            }
            catch
            {
                Menssagem.ValMenssage = "Não foi possível inserir o registro";
                return Menssagem;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}
