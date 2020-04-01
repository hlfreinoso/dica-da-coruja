using DicaDaCoruja.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DicaDaCoruja.Dados
{
    public class SelectCommand
    {
        public DataInformation ObterSelect(string ValTabela, string ValTexto1)
        {
            DataInformation Dt = null;
            Dt = new DataInformation();
            Dt.ValDataTable = new DataTable();
            var command = new SqlCommand();
            command.Connection = Conexao.connection;
            int ValColuna = 0;
            try
            {
                if (ValTabela == "DROP CATEGORIA")
                {
                    command.CommandText = "SELECT DISTINCT CAT.CATE FROM DBCATEGORIA CAT, DBANUNCIOS ANU, DBPRODUTO PRO, DBCIDADE CID, DBFORNECEDOR FRN WHERE CAT.SCAT='A' AND ANU.SANU='A' AND PRO.SPRD='A' AND CAT.CAT_ID=PRO.CAT_ID AND ANU.PRD_ID=PRO.PRD_ID AND ANU.DINI<=GETDATE() AND DATEADD(D,1,ANU.DFIM)>=GETDATE() AND FRN.CIDA=CID.CIDA AND FRN.ESTA=CID.ESTA AND ANU.FRN_ID=FRN.FRN_ID AND FRN.SFOR='A' AND CID.SCID='A' ORDER BY CAT.CATE";
                    Dt.ValDataTable.Columns.Add(new DataColumn("Categoria", typeof(string)));
                    DataRow Dr = Dt.ValDataTable.NewRow();
                    Dr[0] = "Categorias";
                    Dt.ValDataTable.Rows.Add(Dr);
                    ValColuna = 1;
                }
                if (ValTabela == "DROP LOJA")
                {
                    command.CommandText = "SELECT DISTINCT FRN.FORN FROM DBCATEGORIA CAT, DBANUNCIOS ANU, DBPRODUTO PRO, DBCIDADE CID, DBFORNECEDOR FRN WHERE CAT.SCAT='A' AND ANU.SANU='A' AND PRO.SPRD='A' AND CAT.CAT_ID=PRO.CAT_ID AND ANU.PRD_ID=PRO.PRD_ID AND ANU.DINI<=GETDATE() AND DATEADD(D,1,ANU.DFIM)>=GETDATE() AND FRN.CIDA=CID.CIDA AND FRN.ESTA=CID.ESTA AND ANU.FRN_ID=FRN.FRN_ID AND FRN.SFOR='A' AND CID.SCID='A' ORDER BY FRN.FORN";
                    Dt.ValDataTable.Columns.Add(new DataColumn("Loja", typeof(string)));
                    DataRow Dr = Dt.ValDataTable.NewRow();
                    Dr[0] = "Lojas";
                    Dt.ValDataTable.Rows.Add(Dr);
                    ValColuna = 1;
                }
                if (ValTabela == "DROP CIDADE")
                {
                    command.CommandText = "SELECT DISTINCT CID.CIDA FROM DBCATEGORIA CAT, DBANUNCIOS ANU, DBPRODUTO PRO, DBCIDADE CID, DBFORNECEDOR FRN WHERE CAT.SCAT='A' AND ANU.SANU='A' AND PRO.SPRD='A' AND CAT.CAT_ID=PRO.CAT_ID AND ANU.PRD_ID=PRO.PRD_ID AND ANU.DINI<=GETDATE() AND DATEADD(D,1,ANU.DFIM)>=GETDATE() AND FRN.CIDA=CID.CIDA AND FRN.ESTA=CID.ESTA AND ANU.FRN_ID=FRN.FRN_ID AND FRN.SFOR='A' AND CID.SCID='A' ORDER BY CID.CIDA";
                    Dt.ValDataTable.Columns.Add(new DataColumn("Cidade", typeof(string)));
                    DataRow Dr = Dt.ValDataTable.NewRow();
                    Dr[0] = "Cidades";
                    Dt.ValDataTable.Rows.Add(Dr);
                    ValColuna = 1;
                }
                else if (ValTabela == "ANUNCIO")
                {
                    if (ValTexto1.ToUpper() == "ADMIN")
                    {
                        command.CommandText = "SELECT CAT.CATE, CAT.CPAI, CONVERT(VARCHAR(10), ANU.DINI, 103) AS DINI, CONVERT(VARCHAR(10), ANU.DFIM, 103) AS DFIM, PRO.PROD, ANU.PREC, FRN.FORN, FRN.LOJA, ANU.TIPO, ANU.LINK, ANU.ANU_ID FROM DBANUNCIOS ANU, DBFORNECEDOR FRN, DBPRODUTO PRO, DBCATEGORIA CAT WHERE ANU.FRN_ID = FRN.FRN_ID AND ANU.PRD_ID = PRO.PRD_ID AND PRO.CAT_ID = CAT.CAT_ID AND DATEADD(D,1,ANU.DFIM)>GETDATE() AND SANU = 'A' ORDER BY FRN.FORN, FRN.LOJA, ANU.TIPO, PRO.PROD";
                    }
                    else
                    {
                        command.CommandText = "SELECT CAT.CATE, CAT.CPAI, CONVERT(VARCHAR(10), ANU.DINI, 103) AS DINI, CONVERT(VARCHAR(10), ANU.DFIM, 103) AS DFIM, PRO.PROD, ANU.PREC, FRN.FORN, FRN.LOJA, ANU.TIPO, ANU.LINK, ANU.ANU_ID FROM DBANUNCIOS ANU, DBFORNECEDOR FRN, DBPRODUTO PRO, DBCATEGORIA CAT, DBUSUARIO USU WHERE ANU.FRN_ID = FRN.FRN_ID AND ANU.PRD_ID = PRO.PRD_ID AND PRO.CAT_ID = CAT.CAT_ID AND DATEADD(D,1,ANU.DFIM)>GETDATE() AND ANU.SANU = 'A' AND FRN.FRN_ID = USU.FRN_ID AND USU.NUSU=UPPER('" + ValTexto1 + "') ORDER BY FRN.FORN, FRN.LOJA, ANU.TIPO, PRO.PROD";
                    }
                    Dt.ValDataTable.Columns.Add(new DataColumn("0", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("1", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("2", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("3", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("4", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("5", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("6", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("7", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("8", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("9", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("10", typeof(string)));
                    ValColuna = 11;
                }
                else if (ValTabela == "DROP FORNECEDOR CAD")
                {
                    command.CommandText = "SELECT FORN+'-'+CAST(LOJA AS VARCHAR(4)) AS LOJA, FRN_ID FROM DBFORNECEDOR WHERE SFOR='A' ORDER BY FORN, LOJA";
                    Dt.ValDataTable.Columns.Add(new DataColumn("Loja Des", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("Loja Val", typeof(string)));
                    DataRow Dr = Dt.ValDataTable.NewRow();
                    Dr[0] = "Lojas";
                    Dt.ValDataTable.Rows.Add(Dr);
                    ValColuna = 2;
                }
                else if (ValTabela == "DROP TIPO")
                {
                    command.CommandText = "SELECT TIPO + ' (R$ ' + CAST(CUST AS VARCHAR(6)) + ' /' + PERI + ')' AS TDES, PERI+TIPO FROM DBTIPO WHERE CONT=(SELECT CONT FROM DBFORNECEDOR WHERE FRN_ID=" + ValTexto1 + ") AND TIPO<>'PAINEL' ORDER BY CASE TIPO WHEN 'VERDE' THEN 1 WHEN 'VERMELHO' THEN 2 WHEN 'AZUL' THEN 3 ELSE 4 END, PERI";
                    Dt.ValDataTable.Columns.Add(new DataColumn("Tipo Des", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("Tipo Val", typeof(string)));
                    DataRow Dr = Dt.ValDataTable.NewRow();
                    Dr[0] = "Tipo";
                    Dt.ValDataTable.Rows.Add(Dr);
                    ValColuna = 2;
                }
                else if (ValTabela == "DROP CATEGORIA PAI")
                {
                    command.CommandText = "SELECT DISTINCT CPAI FROM DBCATEGORIA WHERE CATE NOT IN (SELECT CPAI FROM DBCATEGORIA) AND SCAT = 'A' ORDER BY CPAI";
                    Dt.ValDataTable.Columns.Add(new DataColumn("Categoria", typeof(string)));
                    DataRow Dr = Dt.ValDataTable.NewRow();
                    Dr[0] = "Categorias";
                    Dt.ValDataTable.Rows.Add(Dr);
                    ValColuna = 1;
                }
                else if (ValTabela == "DROP CATEGORIA FILHO")
                {
                    command.CommandText = "SELECT CATE, CAT_ID FROM DBCATEGORIA WHERE SCAT = 'A' AND CPAI = '" + ValTexto1 + "' ORDER BY CATE";
                    Dt.ValDataTable.Columns.Add(new DataColumn("Categoria Des", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("Categoria Val", typeof(string)));
                    DataRow Dr = Dt.ValDataTable.NewRow();
                    Dr[0] = "Categorias";
                    Dt.ValDataTable.Rows.Add(Dr);
                    ValColuna = 2;
                }
                else if (ValTabela == "DROP PRODUTO")
                {
                    command.CommandText = "SELECT PROD, PRD_ID FROM DBPRODUTO WHERE CAT_ID = " + ValTexto1;
                    Dt.ValDataTable.Columns.Add(new DataColumn("Produto Des", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("Produto Val", typeof(string)));
                    DataRow Dr = Dt.ValDataTable.NewRow();
                    Dr[0] = "Produtos";
                    Dt.ValDataTable.Rows.Add(Dr);
                    ValColuna = 2;
                }
                else if (ValTabela == "DROP ID ANUNCIO")
                {
                    command.CommandText = "SELECT PRO.PROD+'-'+CAST(ANU.ANU_ID AS CHAR), ANU.ANU_ID FROM DBANUNCIOS ANU, DBPRODUTO PRO WHERE ANU.PRD_ID=PRO.PRD_ID AND ANU.SANU='A' AND PRO.SPRD='A' AND ANU.DFIM>=GETDATE() ORDER BY 1";
                    Dt.ValDataTable.Columns.Add(new DataColumn("ID Des", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("ID Val", typeof(string)));
                    DataRow Dr = Dt.ValDataTable.NewRow();
                    Dr[0] = "ID";
                    Dt.ValDataTable.Rows.Add(Dr);
                    ValColuna = 2;
                }
                else if (ValTabela == "PAINEL")
                {
                    command.CommandText = "SELECT CONVERT(VARCHAR(10),PNL.DINI,103), CONVERT(VARCHAR(10),PNL.DFIM,103), FRN.FORN, FRN.LOJA, PNL.DPNL, PNL.LINK, PNL.PNL_ID FROM DBPAINEL PNL, DBFORNECEDOR FRN WHERE PNL.SPNL='A' AND DATEADD(D,1,PNL.DFIM) >= GETDATE() AND PNL.FRN_ID = FRN.FRN_ID AND FRN.SFOR='A' ORDER BY FRN.FORN, FRN.LOJA, PNL.DPNL";
                    Dt.ValDataTable.Columns.Add(new DataColumn("DATA INÍCIO", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("DATA FIM", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("NOME LOJA", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("NUM LOJA", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("DESCRIÇÃO", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("LINK", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("ID", typeof(string)));
                    ValColuna = 7;
                }
                else if (ValTabela == "DROP TIPO PAINEL")
                {
                    command.CommandText = "SELECT TIPO + ' (R$ ' + CAST(CUST AS VARCHAR(6)) + ' /' + PERI + ')' AS TDES, PERI+TIPO FROM DBTIPO WHERE CONT=(SELECT CONT FROM DBFORNECEDOR WHERE FRN_ID=" + ValTexto1 + ") AND TIPO='PAINEL' ORDER BY CASE TIPO WHEN 'VERDE' THEN 1 WHEN 'VERMELHO' THEN 2 WHEN 'AZUL' THEN 3 ELSE 4 END, PERI";
                    Dt.ValDataTable.Columns.Add(new DataColumn("Tipo Des", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("Tipo Val", typeof(string)));
                    DataRow Dr = Dt.ValDataTable.NewRow();
                    Dr[0] = "Tipo";
                    Dt.ValDataTable.Rows.Add(Dr);
                    ValColuna = 2;
                }
                else if (ValTabela == "PRODUTO")
                {
                    command.CommandText = "SELECT CAT.CPAI, CAT.CATE, PRO.PROD, PRO.PDES, PRO.SPRD, PRO.PRD_ID FROM DBPRODUTO PRO, DBCATEGORIA CAT WHERE PRO.CAT_ID = CAT.CAT_ID ORDER BY PROD";
                    Dt.ValDataTable.Columns.Add(new DataColumn("0", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("1", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("2", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("3", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("4", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("5", typeof(string)));
                    ValColuna = 6;
                }
                else if (ValTabela == "FORNECEDOR")
                {
                    command.CommandText = "SELECT GRUP, FORN, LOJA, CNPJ, RAZA, NCEP, RUAV, NUME, BAIR, CIDA, ESTA, LINK, SFOR, FRN_ID FROM DBFORNECEDOR ORDER BY FORN, LOJA";
                    Dt.ValDataTable.Columns.Add(new DataColumn("0", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("1", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("2", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("3", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("4", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("5", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("6", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("7", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("8", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("9", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("10", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("11", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("12", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("13", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("14", typeof(string)));
                    ValColuna = 15;
                }
                else if (ValTabela == "DROP ESTADO")
                {
                    command.CommandText = "SELECT DISTINCT ESTA FROM DBCIDADE WHERE SCID = 'A' ORDER BY ESTA";
                    Dt.ValDataTable.Columns.Add(new DataColumn("Estados", typeof(string)));
                    DataRow Dr = Dt.ValDataTable.NewRow();
                    Dr[0] = "Estado";
                    Dt.ValDataTable.Rows.Add(Dr);
                    ValColuna = 1;
                }
                else if (ValTabela == "DROP CIDADE CAD")
                {
                    command.CommandText = "SELECT CIDA FROM DBCIDADE WHERE SCID = 'A' AND ESTA = '" + ValTexto1 + "' ORDER BY CIDA";
                    Dt.ValDataTable.Columns.Add(new DataColumn("Cidades", typeof(string)));
                    DataRow Dr = Dt.ValDataTable.NewRow();
                    Dr[0] = "Cidade";
                    Dt.ValDataTable.Rows.Add(Dr);
                    ValColuna = 1;
                }
                else if (ValTabela == "CATEGORIA")
                {
                    command.CommandText = "SELECT CPAI, CATE, SCAT, CAT_ID FROM DBCATEGORIA ORDER BY CPAI, CATE";
                    Dt.ValDataTable.Columns.Add(new DataColumn("CATEGORIA PAI", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("CATEGORIA FILHO", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("STATUS", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("ID", typeof(string)));
                    ValColuna = 4;
                }
                else if (ValTabela == "CIDADE")
                {
                    command.CommandText = "SELECT CIDA, ESTA, SCID, CID_ID FROM DBCIDADE ORDER BY CIDA";
                    Dt.ValDataTable.Columns.Add(new DataColumn("CIDADES", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("ESTADO", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("STATUS", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("ID", typeof(string)));
                    ValColuna = 4;
                }
                else if (ValTabela == "USUARIOS")
                {
                    command.CommandText = "SELECT FRN.FORN, FRN.LOJA, USU.NUSU, USU.SENH, USU.SUSU FROM DBUSUARIO USU, DBFORNECEDOR FRN WHERE USU.FRN_ID=FRN.FRN_ID AND USU.NVL_ID=0 ORDER BY 1, 2, 3";
                    Dt.ValDataTable.Columns.Add(new DataColumn("0", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("1", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("2", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("3", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("4", typeof(string)));
                    ValColuna = 5;
                }
                else if (ValTabela == "EMPRESA")
                {
                    command.CommandText = "SELECT FRN.FORN+'-'+CAST(FRN.LOJA AS VARCHAR(2)), FRN.FORN FROM DBUSUARIO USU, DBFORNECEDOR FRN WHERE USU.FRN_ID=FRN.FRN_ID AND USU.NUSU=UPPER('" + ValTexto1 + "');";
                    Dt.ValDataTable.Columns.Add(new DataColumn("0", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("1", typeof(string)));
                    ValColuna = 2;
                }
                else if (ValTabela == "PRODUTO UNIT")
                {
                    command.CommandText = "SELECT PROD, PDES, FOTO FROM DBPRODUTO WHERE PRD_ID=" + ValTexto1 + ";";
                    Dt.ValDataTable.Columns.Add(new DataColumn("0", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("1", typeof(string)));
                    Dt.ValDataTable.Columns.Add(new DataColumn("2", typeof(string)));
                    ValColuna = 3;
                }
                Conexao.Conectar();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DataRow Dr = Dt.ValDataTable.NewRow();
                    if (ValColuna == 1)
                    {
                        Dr[0] = reader[0].ToString();
                    }
                    else if (ValColuna == 2)
                    {
                        Dr[0] = reader[0].ToString();
                        Dr[1] = reader[1].ToString();
                    }
                    else if (ValColuna == 3)
                    {
                        Dr[0] = reader[0].ToString();
                        Dr[1] = reader[1].ToString();
                        Dr[2] = reader[2].ToString();
                    }
                    else if (ValColuna == 4)
                    {
                        Dr[0] = reader[0].ToString();
                        Dr[1] = reader[1].ToString();
                        Dr[2] = reader[2].ToString();
                        Dr[3] = reader[3].ToString();
                    }
                    else if (ValColuna == 5)
                    {
                        Dr[0] = reader[0].ToString();
                        Dr[1] = reader[1].ToString();
                        Dr[2] = reader[2].ToString();
                        Dr[3] = reader[3].ToString();
                        Dr[4] = reader[4].ToString();
                    }
                    else if (ValColuna == 6)
                    {
                        Dr[0] = reader[0].ToString();
                        Dr[1] = reader[1].ToString();
                        Dr[2] = reader[2].ToString();
                        Dr[3] = reader[3].ToString();
                        Dr[4] = reader[4].ToString();
                        Dr[5] = reader[5].ToString();
                    }
                    else if (ValColuna == 7)
                    {
                        Dr[0] = reader[0].ToString();
                        Dr[1] = reader[1].ToString();
                        Dr[2] = reader[2].ToString();
                        Dr[3] = reader[3].ToString();
                        Dr[4] = reader[4].ToString();
                        Dr[5] = reader[5].ToString();
                        Dr[6] = reader[6].ToString();
                    }
                    /*else if (ValColuna == 8)
                    {
                        Dr[0] = reader[0].ToString();
                        Dr[1] = reader[1].ToString();
                        Dr[2] = reader[2].ToString();
                        Dr[3] = reader[3].ToString();
                        Dr[4] = reader[4].ToString();
                        Dr[5] = reader[5].ToString();
                        Dr[6] = reader[6].ToString();
                        Dr[7] = reader[7].ToString();
                    }
                    else if (ValColuna == 9)
                    {
                        Dr[0] = reader[0].ToString();
                        Dr[1] = reader[1].ToString();
                        Dr[2] = reader[2].ToString();
                        Dr[3] = reader[3].ToString();
                        Dr[4] = reader[4].ToString();
                        Dr[5] = reader[5].ToString();
                        Dr[6] = reader[6].ToString();
                        Dr[7] = reader[7].ToString();
                        Dr[8] = reader[8].ToString();
                    }
                    else if (ValColuna == 10)
                    {
                        Dr[0] = reader[0].ToString();
                        Dr[1] = reader[1].ToString();
                        Dr[2] = reader[2].ToString();
                        Dr[3] = reader[3].ToString();
                        Dr[4] = reader[4].ToString();
                        Dr[5] = reader[5].ToString();
                        Dr[6] = reader[6].ToString();
                        Dr[7] = reader[7].ToString();
                        Dr[8] = reader[8].ToString();
                        Dr[9] = reader[9].ToString();
                    }*/
                    else if (ValColuna == 11)
                    {
                        Dr[0] = reader[0].ToString();
                        Dr[1] = reader[1].ToString();
                        Dr[2] = reader[2].ToString();
                        Dr[3] = reader[3].ToString();
                        Dr[4] = reader[4].ToString();
                        Dr[5] = reader[5].ToString();
                        Dr[6] = reader[6].ToString();
                        Dr[7] = reader[7].ToString();
                        Dr[8] = reader[8].ToString();
                        Dr[9] = reader[9].ToString();
                        Dr[10] = reader[10].ToString();
                    }
                    /*else if (ValColuna == 12)
                    {
                        Dr[0] = reader[0].ToString();
                        Dr[1] = reader[1].ToString();
                        Dr[2] = reader[2].ToString();
                        Dr[3] = reader[3].ToString();
                        Dr[4] = reader[4].ToString();
                        Dr[5] = reader[5].ToString();
                        Dr[6] = reader[6].ToString();
                        Dr[7] = reader[7].ToString();
                        Dr[8] = reader[8].ToString();
                        Dr[9] = reader[9].ToString();
                        Dr[10] = reader[10].ToString();
                        Dr[11] = reader[11].ToString();
                    }
                    else if (ValColuna == 13)
                    {
                        Dr[0] = reader[0].ToString();
                        Dr[1] = reader[1].ToString();
                        Dr[2] = reader[2].ToString();
                        Dr[3] = reader[3].ToString();
                        Dr[4] = reader[4].ToString();
                        Dr[5] = reader[5].ToString();
                        Dr[6] = reader[6].ToString();
                        Dr[7] = reader[7].ToString();
                        Dr[8] = reader[8].ToString();
                        Dr[9] = reader[9].ToString();
                        Dr[10] = reader[10].ToString();
                        Dr[11] = reader[11].ToString();
                        Dr[12] = reader[12].ToString();
                    }
                    else if (ValColuna == 14)
                    {
                        Dr[0] = reader[0].ToString();
                        Dr[1] = reader[1].ToString();
                        Dr[2] = reader[2].ToString();
                        Dr[3] = reader[3].ToString();
                        Dr[4] = reader[4].ToString();
                        Dr[5] = reader[5].ToString();
                        Dr[6] = reader[6].ToString();
                        Dr[7] = reader[7].ToString();
                        Dr[8] = reader[8].ToString();
                        Dr[9] = reader[9].ToString();
                        Dr[10] = reader[10].ToString();
                        Dr[11] = reader[11].ToString();
                        Dr[12] = reader[12].ToString();
                        Dr[13] = reader[13].ToString();
                    }*/
                    else if (ValColuna == 15)
                    {
                        Dr[0] = reader[0].ToString();
                        Dr[1] = reader[1].ToString();
                        Dr[2] = reader[2].ToString();
                        Dr[3] = reader[3].ToString();
                        Dr[4] = reader[4].ToString();
                        Dr[5] = reader[5].ToString();
                        Dr[6] = reader[6].ToString();
                        Dr[7] = reader[7].ToString();
                        Dr[8] = reader[8].ToString();
                        Dr[9] = reader[9].ToString();
                        Dr[10] = reader[10].ToString();
                        Dr[11] = reader[11].ToString();
                        Dr[12] = reader[12].ToString();
                        Dr[13] = reader[13].ToString();
                        Dr[14] = reader[13].ToString();
                    }
                    Dt.ValDataTable.Rows.Add(Dr);
                }
                reader.Close();
                return Dt;
            }
            catch
            {
                if (Dt != null)
                {
                    return Dt;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}
