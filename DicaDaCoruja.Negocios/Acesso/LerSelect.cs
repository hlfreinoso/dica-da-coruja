using DicaDaCoruja.Dados;
using DicaDaCoruja.Entidades;

namespace DicaDaCoruja.Negocios.Acesso
{
    public class LerSelect
    {
        private SelectCommand _select;
        public DataInformation LerDropCategoria()
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("DROP CATEGORIA", "");
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerDropLoja()
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("DROP LOJA", "");
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerDropCidade()
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("DROP CIDADE", "");
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerAnuncio(string user)
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("ANUNCIO", user);
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerPainel()
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("PAINEL", "");
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerProduto()
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("PRODUTO", "");
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerFornecedor()
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("FORNECEDOR", "");
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerCategoria()
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("CATEGORIA", "");
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerCidade()
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("CIDADE", "");
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerDropCategoriaPai()
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("DROP CATEGORIA PAI", "");
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerDropCategoriaFilho(string ValCategoriaPai)
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("DROP CATEGORIA FILHO", ValCategoriaPai);
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerDropProduto(string ValCategoriaFilho)
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("DROP PRODUTO", ValCategoriaFilho);
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerDropTipo(string ValContrato)
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("DROP TIPO", ValContrato);
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerDropTipoPnl(string ValContrato)
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("DROP TIPO PAINEL", ValContrato);
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerDropLojaCad()
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("DROP FORNECEDOR CAD", "");
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerDropCidadeCad(string ValEstado)
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("DROP CIDADE CAD", ValEstado);
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerDropIDAnuncio()
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("DROP ID ANUNCIO", "");
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerDropEstado()
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("DROP ESTADO", "");
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerUsuarios()
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("USUARIOS", "");
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerEmpresa(string user)
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("EMPRESA", user);
            if (Select == null)
            {
                return null;
            }
            else
            {
                return Select;
            }
        }
        public DataInformation LerProduto(string ID)
        {
            _select = new SelectCommand();
            var Select = _select.ObterSelect("PRODUTO UNIT", ID);
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
