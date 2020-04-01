using DicaDaCoruja.Dados;
using DicaDaCoruja.Entidades;

namespace DicaDaCoruja.Negocios.Acesso
{
    public class GravarPainel
    {
        private InsertCommand _insert;
        public AlertMenssagem InserirPainel(string ValDataInicio, string ValDataFim, string ValFornecedor, string ValDescricao, string ValFoto, string ValLink, string ValTipo)
        {
            _insert = new InsertCommand();
            var InserirRegistro = _insert.GerarInsert("PAINEL", ValDataInicio, ValDataFim, ValFornecedor, ValDescricao, ValFoto, ValLink, ValTipo, "", "", "", "", "", "");
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
