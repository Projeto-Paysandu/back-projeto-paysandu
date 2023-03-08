using Projeto.Paysandu.Domain.Entities;
using Projeto.Paysandu.Domain.Models.InputModels;
using Projeto.Paysandu.Domain.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Paysandu.Application.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<List<UserViewModel>> GetUsers(int page, int qty);
        Task<UserViewModel> GetUser(string cpf);
        Task<UserViewModel> InsertUser(UserInput user);
        Task<UserViewModel> UpdateUser(string cpf, UserInput user);
        Task DeleteUser(string cpf);
    }
}
