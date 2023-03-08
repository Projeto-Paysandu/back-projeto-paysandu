using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Paysandu.Domain.Entities;
using Projeto.Paysandu.Domain.Models.InputModels;

namespace Projeto.Paysandu.Domain.Models.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        
        public UserViewModel(User user)
        {
            Id = user.Id;
            FirstName  = user.FirstName;
            LastName = user.LastName;
            CPF = user.CPF;
            Email = user.Email;
            Role = user.Role;
        }
    }
}
