using DicaDaCoruja.Negocios.Acesso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DicaDaCoruja.Interface.ofertas
{
    public partial class ofertas : System.Web.UI.MasterPage
    {
        #region Declar Objects
        private LerSelect _ler;
        public string ValOrd = "";
        public string ValCid = "";
        public string ValFor = "";
        public string ValCla = "";
        public string ValPes = "";
        public string RedirectUrl = "";
        public int ValPag = 0;
        #endregion

        #region Load Area
        protected void Page_Load(object sender, EventArgs e)
        {
            Reload();
        }

        protected void Reload()
        {
            ValOrd = Request.QueryString["ORDE"];
            if (ValOrd == null)
            {
                ValOrd = "";
            }
            ValCid = Request.QueryString["CIDA"];
            if (ValCid == null)
            {
                ValCid = "";
            }
            ValFor = Request.QueryString["LOJA"];
            if (ValFor == null)
            {
                ValFor = "";
            }
            ValCla = Request.QueryString["CLAS"];
            if (ValCla == null)
            {
                ValCla = "";
            }
            ValPes = Request.QueryString["PESQ"];
            if (ValPes == null)
            {
                ValPes = "";
            }
            if (Request.QueryString["PAGE"] == null)
            {
                ValPag = 0;
            }
            else
            {
                ValPag = Convert.ToInt32(Request.QueryString["PAGE"]);
            }
            _ler = new LerSelect();
            var DtLoja = _ler.LerDropLoja();
            if (DtLoja != null && DropFornecedor.Items.Count.ToString() == "0")
            {
                DropFornecedor.DataTextField = "Loja";
                DropFornecedor.DataSource = DtLoja.ValDataTable;
                DropFornecedor.DataBind();
                DropFornecedor.AppendDataBoundItems = true;
            }
            _ler = new LerSelect();
            var DtCategoria = _ler.LerDropCategoria();
            if (DtCategoria != null && DropCategoria.Items.Count.ToString() == "0")
            {
                DropCategoria.DataTextField = "Categoria";
                DropCategoria.DataSource = DtCategoria.ValDataTable;
                DropCategoria.DataBind();
                DropCategoria.AppendDataBoundItems = true;
            }
            _ler = new LerSelect();
            var DtCidade = _ler.LerDropCidade();
            if (DtCidade != null && DropCidade.Items.Count.ToString() == "0")
            {
                DropCidade.DataTextField = "Cidade";
                DropCidade.DataSource = DtCidade.ValDataTable;
                DropCidade.DataBind();
                DropCidade.AppendDataBoundItems = true;
            }
        }
        #endregion

        #region Action Area
        protected void BtnPesquisa_Click(object sender, EventArgs e)
        {
            ValPes = TxtPesquisa.Text;
            ValOrd = "";
            ValCla = "";
            ValCid = "";
            ValFor = "";
            ValPag = 0;
            RedirectPage(ValOrd, ValCid, ValFor, ValCla, ValPes, ValPag);
        }

        protected void Change_Categoria(Object sender, EventArgs e)
        {
            ValCla = DropCategoria.SelectedItem.Value;
            ValOrd = "";
            ValPag = 0;
            ValPes = "";
            RedirectPage(ValOrd, ValCid, ValFor, ValCla, ValPes, ValPag);
        }

        protected void Change_Cidade(Object sender, EventArgs e)
        {
            ValCid = DropCidade.SelectedItem.Value;
            ValOrd = "";
            ValPag = 0;
            ValPes = "";
            RedirectPage(ValOrd, ValCid, ValFor, ValCla, ValPes, ValPag);
        }

        protected void Change_Fornecedor(Object sender, EventArgs e)
        {
            ValFor = DropFornecedor.SelectedItem.Value;
            ValOrd = "";
            ValPag = 0;
            ValPes = "";
            RedirectPage(ValOrd, ValCid, ValFor, ValCla, ValPes, ValPag);
        }

        protected void RedirectPage(string ValOrd, string ValCid, string ValFor, string ValCla, string ValPes, int ValPag)
        {
            RedirectUrl = "/ofertas/preco.aspx?ORDE=" + ValOrd + "&CIDA=" + ValCid + "&LOJA=" + ValFor + "&CLAS=" + ValCla + "&PESQ=" + ValPes + "&PAGE=" + ValPag.ToString();
            Response.Redirect(RedirectUrl);
        }
        #endregion
    }
}