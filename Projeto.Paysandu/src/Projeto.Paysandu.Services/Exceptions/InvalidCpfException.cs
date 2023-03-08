using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Paysandu.Application.Exceptions
{
    public class InvalidCpfException : Exception
    {
        public InvalidCpfException() : base("Cpf is invalid.")
        {

        }

    }
}