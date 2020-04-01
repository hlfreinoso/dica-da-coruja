using DicaDaCoruja.Dados;
using DicaDaCoruja.Entidades;

namespace DicaDaCoruja.Negocios.Acesso
{
    public class GravarCidade
    {
        private InsertCommand _insert;
        public AlertMenssagem InserirCidade(string ValCidade, string ValEstado)
        {
            _insert = new InsertCommand();
            var InserirRegistro = _insert.GerarInsert("CIDADE", ValCidade, ValEstado, "", "", "", "", "", "", "", "", "", "", "");
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
