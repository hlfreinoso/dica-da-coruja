using System;
using System.Data.SqlClient;
using DicaDaCoruja.Entidades;

namespace DicaDaCoruja.Dados
{
    public class SelectHomeAnuncio
    {
        public HomeAnuncios ObterHomeAnuncio(string CorDoAnuncio)
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = Conexao.connection;
                command.CommandText = "SELECT TOP 4 ANU.PREC, PRO.FOTO, PRO.PROD, CONVERT(VARCHAR(10),ANU.DFIM,103) AS DFIM, FRN.FORN, CASE WHEN ANU.LINK='' THEN FRN.LINK ELSE ANU.LINK END AS LINK, PRO.PDES FROM DBANUNCIOS ANU, DBFORNECEDOR FRN, DBPRODUTO PRO WHERE ANU.TIPO = @COR AND ANU.SANU = 'A' AND ANU.DINI <= GETDATE() AND DATEADD(D,1,ANU.DFIM) >= GETDATE() AND ANU.FRN_ID = FRN.FRN_ID AND FRN.SFOR='A' AND ANU.PRD_ID = PRO.PRD_ID AND PRO.SPRD = 'A' ORDER BY NEWID()";
                command.Parameters.AddWithValue("@COR", CorDoAnuncio);
                Conexao.Conectar();
                var reader = command.ExecuteReader();
                HomeAnuncios SelectAnuncio = null;
                if (reader.Read())
                {
                    SelectAnuncio = new HomeAnuncios();
                    SelectAnuncio.AnuncioPreco1 = "R$" + reader["PREC"].ToString();
                    SelectAnuncio.AnuncioFoto1 = reader["FOTO"].ToString();
                    SelectAnuncio.AnuncioProduto1 = reader["PROD"].ToString();
                    SelectAnuncio.AnuncioDataFim1 = "Válido até: " + reader["DFIM"].ToString();
                    SelectAnuncio.AnuncioFornecedor1 = reader["FORN"].ToString();
                    SelectAnuncio.AnuncioLink1 = reader["LINK"].ToString();
                    SelectAnuncio.AnuncioTitle1 = reader["PDES"].ToString();
                }
                if (reader.Read())
                {
                    SelectAnuncio.AnuncioPreco2 = "R$" + reader["PREC"].ToString();
                    SelectAnuncio.AnuncioFoto2 = reader["FOTO"].ToString();
                    SelectAnuncio.AnuncioProduto2 = reader["PROD"].ToString();
                    SelectAnuncio.AnuncioDataFim2 = "Válido até: " + reader["DFIM"].ToString();
                    SelectAnuncio.AnuncioFornecedor2 = reader["FORN"].ToString();
                    SelectAnuncio.AnuncioLink2 = reader["LINK"].ToString();
                    SelectAnuncio.AnuncioTitle2 = reader["PDES"].ToString();
                }
                if (reader.Read())
                {
                    SelectAnuncio.AnuncioPreco3 = "R$" + reader["PREC"].ToString();
                    SelectAnuncio.AnuncioFoto3 = reader["FOTO"].ToString();
                    SelectAnuncio.AnuncioProduto3 = reader["PROD"].ToString();
                    SelectAnuncio.AnuncioDataFim3 = "Válido até: " + reader["DFIM"].ToString();
                    SelectAnuncio.AnuncioFornecedor3 = reader["FORN"].ToString();
                    SelectAnuncio.AnuncioLink3 = reader["LINK"].ToString();
                    SelectAnuncio.AnuncioTitle3 = reader["PDES"].ToString();
                }
                if (reader.Read())
                {
                    SelectAnuncio.AnuncioPreco4 = "R$" + reader["PREC"].ToString();
                    SelectAnuncio.AnuncioFoto4 = reader["FOTO"].ToString();
                    SelectAnuncio.AnuncioProduto4 = reader["PROD"].ToString();
                    SelectAnuncio.AnuncioDataFim4 = "Válido até: " + reader["DFIM"].ToString();
                    SelectAnuncio.AnuncioFornecedor4 = reader["FORN"].ToString();
                    SelectAnuncio.AnuncioLink4 = reader["LINK"].ToString();
                    SelectAnuncio.AnuncioTitle4 = reader["PDES"].ToString();
                }
                reader.Close();
                return SelectAnuncio;
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
