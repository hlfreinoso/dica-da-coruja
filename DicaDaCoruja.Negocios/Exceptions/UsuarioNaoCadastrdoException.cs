using System;

namespace DicaDaCoruja.Negocios.Exceptions
{
    public class UsuarioNaoCadastradoException : Exception
    {
        public UsuarioNaoCadastradoException()
        {
        }
        public UsuarioNaoCadastradoException(string message) : base(message)
        {
        }
        public UsuarioNaoCadastradoException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

