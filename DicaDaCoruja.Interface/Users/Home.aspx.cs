using DicaDaCoruja.Negocios.Acesso;
using System;

namespace DicaDaCoruja.Interface.Users
{
    public partial class Home : System.Web.UI.Page
    {
        private LerSelect _ler;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.ServerVariables["AUTH_USER"].ToUpper().ToString() == "ADMIN")
            {
                Response.Redirect("../Register/Home.aspx");
            }
            _ler = new LerSelect();
            var Dt = _ler.LerEmpresa(Request.ServerVariables["AUTH_USER"].ToString());
            LblHome.Text = "Seja bem vindo " + Request.ServerVariables["AUTH_USER"].ToString() + " da empresa " + Dt.ValDataTable.Rows[0]["1"].ToString();
        }
    }
}