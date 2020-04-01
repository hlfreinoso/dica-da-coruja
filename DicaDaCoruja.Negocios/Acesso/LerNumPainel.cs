using DicaDaCoruja.Dados;
using DicaDaCoruja.Entidades;

namespace DicaDaCoruja.Negocios.Acesso
{
    public class LerNumPainel
    {
        private SelectNumPainel _select;
        public AlertMenssagem LerNumeroPnl()
        {
            _select = new SelectNumPainel();
            var SelectNumPnl = _select.ChecarNumero();
            if (SelectNumPnl == null)
            {
                return null;
            }
            else
            {
                return SelectNumPnl;
            }
        }
    }
}
