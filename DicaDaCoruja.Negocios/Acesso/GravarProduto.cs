using DicaDaCoruja.Dados;
using DicaDaCoruja.Entidades;

namespace DicaDaCoruja.Negocios.Acesso
{
    public class GravarProduto
    {
        private InsertCommand _insert;
        public AlertMenssagem InserirProduto(string ValCategoriaFilho, string ValProduto, string ValDescrição, string ValFoto)
        {
            _insert = new InsertCommand();
            var InserirRegistro = _insert.GerarInsert("PRODUTO", ValCategoriaFilho, ValProduto, ValDescrição, ValFoto, "", "", "", "", "", "", "", "", "");
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
