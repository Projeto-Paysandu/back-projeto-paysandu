using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Paysandu.Application.Exceptions
{
    public class UserDoesNotExistException : Exception
    {
        public UserDoesNotExistException() : base("User Does Not Exist.")
        {

        }
    }
}
