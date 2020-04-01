using DicaDaCoruja.Dados;
using DicaDaCoruja.Entidades;

namespace DicaDaCoruja.Negocios.Acesso
{
    public class GravarAnuncio
    {
        private InsertCommand _insert;
        public AlertMenssagem InserirAnuncio(string ValProduto, string ValDataInicio, string ValDataFim, string ValPreco, string ValFornecedor, string ValTipo, string ValLink)
        {
            _insert = new InsertCommand();
            var InserirRegistro = _insert.GerarInsert("ANUNCIOS", ValProduto, ValDataInicio, ValDataFim, ValPreco, ValFornecedor, ValTipo, ValLink, "", "", "", "", "", "");
            if (InserirRegistro != null)
            {
                return InserirRegistro;
            }
            else
            {
                return null;
            }
        }
    }
}
