using DicaDaCoruja.Dados;
using DicaDaCoruja.Entidades;

namespace DicaDaCoruja.Negocios.Acesso
{
    public class LerNumProduto
    {
        private SelectNumProduto _select;
        public AlertMenssagem LerNumeroPrd()
        {
            _select = new SelectNumProduto();
            var SelectNumPrd = _select.ChecarNumero();
            if (SelectNumPrd == null)
            {
                return null;
            }
            else
            {
                return SelectNumPrd;
            }
        }
    }
}
