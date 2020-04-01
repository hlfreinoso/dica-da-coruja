using DicaDaCoruja.Dados;
using DicaDaCoruja.Entidades;

namespace DicaDaCoruja.Negocios.Acesso
{
    public class LerAnuncioHome
    {
        private SelectHomeAnuncio _select;
        public HomeAnuncios LerAnuncio(string CorDoAnuncio)
        {
            _select = new SelectHomeAnuncio();
            var SelectAnuncio = _select.ObterHomeAnuncio(CorDoAnuncio);
            if (SelectAnuncio == null)
            {
                return null;
            }
            else
            {
                return SelectAnuncio;
            }
        }
    }
}
