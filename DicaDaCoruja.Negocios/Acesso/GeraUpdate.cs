using DicaDaCoruja.Dados;
using DicaDaCoruja.Entidades;

namespace DicaDaCoruja.Negocios.Acesso
{
    public class GeraUpdate
    {
        private UpdateCommand _update;
        public AlertMenssagem GerarUpdate(string ValTabela, string ValID, string ValCampo, string ValAtualizar)
        {
            _update = new UpdateCommand();
            var Update = _update.GerarUpdate(ValTabela, ValID, ValCampo, ValAtualizar);
            if (Update != null)
            {
                return Update;
            }
            else
            {
                return null;
            }
        }
    }
}
