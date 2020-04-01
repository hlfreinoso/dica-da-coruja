using DicaDaCoruja.Entidades;
using System;
using System.Data.SqlClient;

namespace DicaDaCoruja.Dados
{
    public class SelectHomePainel
    {
        public HomePainel ObterHomePainel()
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT PNL.FOTO, CASE WHEN PNL.LINK='' THEN FRN.LINK ELSE PNL.LINK END AS LINK FROM DBPAINEL PNL, DBFORNECEDOR FRN WHERE PNL.FRN_ID=FRN.FRN_ID AND PNL.DINI <= GETDATE() AND DATEADD(D,1,PNL.DFIM) >= GETDATE() AND PNL.SPNL='A' AND FRN.SFOR = 'A' ORDER BY NEWID()";
                Conexao.Conectar();
                var reader = command.ExecuteReader();
                HomePainel SelectPainel = null;
                SelectPainel = new HomePainel();
                if (reader.Read())
                {
                    SelectPainel.PainelFoto1 = reader["FOTO"].ToString();
                    SelectPainel.PainelLink1 = reader["LINK"].ToString();
                }
                if (reader.Read())
                {
                    SelectPainel.PainelFoto2 = reader["FOTO"].ToString();
                    SelectPainel.PainelLink2 = reader["LINK"].ToString();
                }
                if (reader.Read())
                {
                    SelectPainel.PainelFoto3 = reader["FOTO"].ToString();
                    SelectPainel.PainelLink3 = reader["LINK"].ToString();
                }
                if (reader.Read())
                {
                    SelectPainel.PainelFoto4 = reader["FOTO"].ToString();
                    SelectPainel.PainelLink4 = reader["LINK"].ToString();
                }
                if (reader.Read())
                {
                    SelectPainel.PainelFoto5 = reader["FOTO"].ToString();
                    SelectPainel.PainelLink5 = reader["LINK"].ToString();
                }
                if (reader.Read())
                {
                    SelectPainel.PainelFoto6 = reader["FOTO"].ToString();
                    SelectPainel.PainelLink6 = reader["LINK"].ToString();
                }
                reader.Close();
                return SelectPainel;
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
