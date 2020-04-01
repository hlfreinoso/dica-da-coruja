using System;
using System.Data.SqlClient;
using DicaDaCoruja.Entidades;

namespace DicaDaCoruja.Dados
{
    public class SelectPesquisaAnuncio
    {
        public PesquisaAnuncios ObterPesquisaAnuncio(string Ordenar, string Cidade, string Fornecedor, string Classe, string Pesquisa, int NumPage)
        {
            try
            {
                var command = new SqlCommand();
                string Val1;
                string Val2;
                string Val3;
                string Val4;
                string Val5;
                command.Connection = Conexao.connection;
                if (Ordenar == "ASCE")
                {
                    Val1 = "ANU.PREC, ";
                }
                else if (Ordenar == "DESC")
                {
                    Val1 = "ANU.PREC DESC, ";
                }
                else
                {
                    Val1 = "";
                }
                if (Cidade == "")
                {
                    Val2 = "";
                }
                else
                {
                    Val2 = "AND FRN.CIDA = '" + Cidade + "' ";
                }
                if (Fornecedor == "")
                {
                    Val3 = "";
                }
                else
                {
                    Val3 = "AND FRN.FORN = '" + Fornecedor + "' ";
                }
                if (Classe == "")
                {
                    Val4 = "";
                }
                else
                {
                    Val4 = "AND (CAT.CATE = '" + Classe + "' OR CAT.CPAI = '" + Classe + "') ";
                }
                if (Pesquisa == "")
                {
                    Val5 = "";
                }
                else
                {
                    Val5 = "AND (PRO.PROD LIKE '%" + Pesquisa + "%' OR PRO.PDES LIKE '%" + Pesquisa + "%' OR CAT.CATE LIKE '%" + Pesquisa + "%' OR CAT.CPAI LIKE '%" + Pesquisa + "%') ";
                }
                command.CommandText = "SELECT ANU.PREC, PRO.FOTO, PRO.PROD, CONVERT(VARCHAR,ANU.DFIM,103) AS DFIM, FRN.FORN, CASE WHEN ANU.LINK='' THEN FRN.LINK ELSE ANU.LINK END AS LINK, ANU.TIPO, PRO.PDES FROM DBANUNCIOS ANU, DBFORNECEDOR FRN, DBPRODUTO PRO, DBCATEGORIA CAT WHERE ANU.SANU = 'A' AND FRN.SFOR = 'A' AND PRO.SPRD = 'A' AND CAT.SCAT = 'A' AND ANU.FRN_ID = FRN.FRN_ID AND ANU.PRD_ID = PRO.PRD_ID AND PRO.CAT_ID = CAT.CAT_ID AND ANU.DINI <= GETDATE() AND DATEADD(D,1,ANU.DFIM) >= GETDATE() " + Val2 + Val3 + Val4 + Val5 + "ORDER BY " + Val1 + "CASE ANU.TIPO WHEN 'AZUL' THEN 1 WHEN 'VERMELHO' THEN 2 ELSE 3 END";
                Conexao.Conectar();
                var reader = command.ExecuteReader();
                PesquisaAnuncios SelectAnuncio = null;
                if (NumPage > 0)
                {
                    NumPage = NumPage * 12;
                    while (NumPage > 0)
                    {
                        if (reader.Read())
                        {

                        }
                        NumPage = NumPage - 1;
                    }
                }
                if (reader.Read())
                {
                    SelectAnuncio = new PesquisaAnuncios();
                    SelectAnuncio.AnuncioPreco1 = "R$" + reader["PREC"].ToString();
                    SelectAnuncio.AnuncioFoto1 = reader["FOTO"].ToString();
                    SelectAnuncio.AnuncioProduto1 = reader["PROD"].ToString();
                    SelectAnuncio.AnuncioDataFim1 = "Válido até: " + reader["DFIM"].ToString();
                    SelectAnuncio.AnuncioFornecedor1 = reader["FORN"].ToString();
                    SelectAnuncio.AnuncioLink1 = reader["LINK"].ToString();
                    SelectAnuncio.AnuncioTipo1 = reader["TIPO"].ToString();
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
                    SelectAnuncio.AnuncioTipo2 = reader["TIPO"].ToString();
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
                    SelectAnuncio.AnuncioTipo3 = reader["TIPO"].ToString();
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
                    SelectAnuncio.AnuncioTipo4 = reader["TIPO"].ToString();
                    SelectAnuncio.AnuncioTitle4 = reader["PDES"].ToString();
                }
                if (reader.Read())
                {
                    SelectAnuncio.AnuncioPreco5 = "R$" + reader["PREC"].ToString();
                    SelectAnuncio.AnuncioFoto5 = reader["FOTO"].ToString();
                    SelectAnuncio.AnuncioProduto5 = reader["PROD"].ToString();
                    SelectAnuncio.AnuncioDataFim5 = "Válido até: " + reader["DFIM"].ToString();
                    SelectAnuncio.AnuncioFornecedor5 = reader["FORN"].ToString();
                    SelectAnuncio.AnuncioLink5 = reader["LINK"].ToString();
                    SelectAnuncio.AnuncioTipo5 = reader["TIPO"].ToString();
                    SelectAnuncio.AnuncioTitle5 = reader["PDES"].ToString();
                }
                if (reader.Read())
                {
                    SelectAnuncio.AnuncioPreco6 = "R$" + reader["PREC"].ToString();
                    SelectAnuncio.AnuncioFoto6 = reader["FOTO"].ToString();
                    SelectAnuncio.AnuncioProduto6 = reader["PROD"].ToString();
                    SelectAnuncio.AnuncioDataFim6 = "Válido até: " + reader["DFIM"].ToString();
                    SelectAnuncio.AnuncioFornecedor6 = reader["FORN"].ToString();
                    SelectAnuncio.AnuncioLink6 = reader["LINK"].ToString();
                    SelectAnuncio.AnuncioTipo6 = reader["TIPO"].ToString();
                    SelectAnuncio.AnuncioTitle6 = reader["PDES"].ToString();
                }
                if (reader.Read())
                {
                    SelectAnuncio.AnuncioPreco7 = "R$" + reader["PREC"].ToString();
                    SelectAnuncio.AnuncioFoto7 = reader["FOTO"].ToString();
                    SelectAnuncio.AnuncioProduto7 = reader["PROD"].ToString();
                    SelectAnuncio.AnuncioDataFim7 = "Válido até: " + reader["DFIM"].ToString();
                    SelectAnuncio.AnuncioFornecedor7 = reader["FORN"].ToString();
                    SelectAnuncio.AnuncioLink7 = reader["LINK"].ToString();
                    SelectAnuncio.AnuncioTipo7 = reader["TIPO"].ToString();
                    SelectAnuncio.AnuncioTitle7 = reader["PDES"].ToString();
                }
                if (reader.Read())
                {
                    SelectAnuncio.AnuncioPreco8 = "R$" + reader["PREC"].ToString();
                    SelectAnuncio.AnuncioFoto8 = reader["FOTO"].ToString();
                    SelectAnuncio.AnuncioProduto8 = reader["PROD"].ToString();
                    SelectAnuncio.AnuncioDataFim8 = "Válido até: " + reader["DFIM"].ToString();
                    SelectAnuncio.AnuncioFornecedor8 = reader["FORN"].ToString();
                    SelectAnuncio.AnuncioLink8 = reader["LINK"].ToString();
                    SelectAnuncio.AnuncioTipo8 = reader["TIPO"].ToString();
                    SelectAnuncio.AnuncioTitle8 = reader["PDES"].ToString();
                }
                if (reader.Read())
                {
                    SelectAnuncio.AnuncioPreco9 = "R$" + reader["PREC"].ToString();
                    SelectAnuncio.AnuncioFoto9 = reader["FOTO"].ToString();
                    SelectAnuncio.AnuncioProduto9 = reader["PROD"].ToString();
                    SelectAnuncio.AnuncioDataFim9 = "Válido até: " + reader["DFIM"].ToString();
                    SelectAnuncio.AnuncioFornecedor9 = reader["FORN"].ToString();
                    SelectAnuncio.AnuncioLink9 = reader["LINK"].ToString();
                    SelectAnuncio.AnuncioTipo9 = reader["TIPO"].ToString();
                    SelectAnuncio.AnuncioTitle9 = reader["PDES"].ToString();
                }
                if (reader.Read())
                {
                    SelectAnuncio.AnuncioPreco10 = "R$" + reader["PREC"].ToString();
                    SelectAnuncio.AnuncioFoto10 = reader["FOTO"].ToString();
                    SelectAnuncio.AnuncioProduto10 = reader["PROD"].ToString();
                    SelectAnuncio.AnuncioDataFim10 = "Válido até: " + reader["DFIM"].ToString();
                    SelectAnuncio.AnuncioFornecedor10 = reader["FORN"].ToString();
                    SelectAnuncio.AnuncioLink10 = reader["LINK"].ToString();
                    SelectAnuncio.AnuncioTipo10 = reader["TIPO"].ToString();
                    SelectAnuncio.AnuncioTitle10 = reader["PDES"].ToString();
                }
                if (reader.Read())
                {
                    SelectAnuncio.AnuncioPreco11 = "R$" + reader["PREC"].ToString();
                    SelectAnuncio.AnuncioFoto11 = reader["FOTO"].ToString();
                    SelectAnuncio.AnuncioProduto11 = reader["PROD"].ToString();
                    SelectAnuncio.AnuncioDataFim11 = "Válido até: " + reader["DFIM"].ToString();
                    SelectAnuncio.AnuncioFornecedor11 = reader["FORN"].ToString();
                    SelectAnuncio.AnuncioLink11 = reader["LINK"].ToString();
                    SelectAnuncio.AnuncioTipo11 = reader["TIPO"].ToString();
                    SelectAnuncio.AnuncioTitle11 = reader["PDES"].ToString();
                }
                if (reader.Read())
                {
                    SelectAnuncio.AnuncioPreco12 = "R$" + reader["PREC"].ToString();
                    SelectAnuncio.AnuncioFoto12 = reader["FOTO"].ToString();
                    SelectAnuncio.AnuncioProduto12 = reader["PROD"].ToString();
                    SelectAnuncio.AnuncioDataFim12 = "Válido até: " + reader["DFIM"].ToString();
                    SelectAnuncio.AnuncioFornecedor12 = reader["FORN"].ToString();
                    SelectAnuncio.AnuncioLink12 = reader["LINK"].ToString();
                    SelectAnuncio.AnuncioTipo12 = reader["TIPO"].ToString();
                    SelectAnuncio.AnuncioTitle12 = reader["PDES"].ToString();
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
