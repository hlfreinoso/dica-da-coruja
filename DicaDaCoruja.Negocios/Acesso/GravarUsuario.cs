using DicaDaCoruja.Dados;
using DicaDaCoruja.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicaDaCoruja.Negocios.Acesso
{
    public class GravarUsuario
    {
        private InsertCommand _insert;
        public AlertMenssagem InserirUsuario(string ValFornecedor, string ValUsuario, string ValSenha)
        {
            _insert = new InsertCommand();
            var InserirRegistro = _insert.GerarInsert("USUARIO", ValUsuario, ValSenha, ValFornecedor, "", "", "", "", "", "", "", "", "", "");
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
