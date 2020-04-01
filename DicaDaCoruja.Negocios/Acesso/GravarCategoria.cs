using DicaDaCoruja.Dados;
using DicaDaCoruja.Entidades;

namespace DicaDaCoruja.Negocios.Acesso
{
    public class GravarCategoria
    {
        private InsertCommand _insert;
        public AlertMenssagem InserirCategoria(string ValCategoria, string ValCatePai)
        {
            _insert = new InsertCommand();
            var InserirRegistro = _insert.GerarInsert("CATEGORIA", ValCategoria, ValCatePai, "", "", "", "", "", "", "", "", "", "", "");
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
