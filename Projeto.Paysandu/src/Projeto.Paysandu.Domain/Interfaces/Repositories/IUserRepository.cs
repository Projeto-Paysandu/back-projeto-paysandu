using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Paysandu.Domain.Entities;
using Projeto.Paysandu.Domain.Models.InputModels;

namespace Projeto.Paysandu.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IDisposable
    {
        Task<List<User>> GetMany(int page, int qty);
        Task<User> Get(string cpf);
        Task<User> Insert(User newUser);
        Task<User> Update(string cpf, User user);
        Task Delete(string cpf);
    }
}
