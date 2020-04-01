using DicaDaCoruja.Dados;
using DicaDaCoruja.Entidades;

namespace DicaDaCoruja.Negocios.Acesso
{
    public class GravarLog
    {
        private InsertCommand _insert;
        public AlertMenssagem InserirLog(string ValIP, string ValRequest)
        {
            _insert = new InsertCommand();
            var InserirRegistro = _insert.GerarInsert("LOG", ValIP, ValRequest, "", "", "", "", "", "", "", "", "", "", "");
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
