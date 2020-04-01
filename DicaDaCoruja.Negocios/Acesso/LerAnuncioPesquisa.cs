using DicaDaCoruja.Dados;
using DicaDaCoruja.Entidades;

namespace DicaDaCoruja.Negocios.Acesso
{
    public class LerAnuncioPesquisa
    {
        private SelectPesquisaAnuncio _select;
        public PesquisaAnuncios LerAnuncio(string Ordenar, string Cidade, string Fornecedor, string Classe, string Pesquisa, int NumPage)
        {
            _select = new SelectPesquisaAnuncio();
            var SelectAnuncio = _select.ObterPesquisaAnuncio(Ordenar, Cidade, Fornecedor, Classe, Pesquisa, NumPage);
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
