using DicaDaCoruja.Dados;
using DicaDaCoruja.Entidades;

namespace DicaDaCoruja.Negocios.Acesso
{
    public class LerPainelHome
    {
        private SelectHomePainel _select;
        public HomePainel LerPainel()
        {
            _select = new SelectHomePainel();
            var Select = _select.ObterHomePainel();
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
    }
}
