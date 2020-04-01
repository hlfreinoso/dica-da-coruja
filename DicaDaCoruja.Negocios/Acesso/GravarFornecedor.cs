using DicaDaCoruja.Dados;
using DicaDaCoruja.Entidades;

namespace DicaDaCoruja.Negocios.Acesso
{
    public class GravarFornecedor
    {
        private InsertCommand _insert;
        public AlertMenssagem InserirFornecedor(string ValGrupo, string ValFornecedor, string ValLoja, string ValCNPJ, string ValRazao, string ValCEP, string ValRua, string ValNumero, string ValBairro, string ValCidade, string ValEstado, string ValLink, string ValContrato)
        {
            _insert = new InsertCommand();
            var InserirRegistro = _insert.GerarInsert("FORNECEDOR", ValGrupo, ValFornecedor, ValLoja, ValCNPJ, ValRazao, ValCEP, ValRua, ValNumero, ValBairro, ValCidade, ValEstado, ValLink, ValContrato);
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
