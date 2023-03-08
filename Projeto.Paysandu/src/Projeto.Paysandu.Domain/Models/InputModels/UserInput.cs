using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentValidator;
using Projeto.Paysandu.Domain.Entities;

namespace Projeto.Paysandu.Domain.Models.InputModels
{
    public class UserInput
    {

        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "First Name length must be at least 3 and up to a maximum of 10 characters long.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Last Name length must be at least 3 and up to a maximum of 10 characters long.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF must be 11 characters long.")]
        public string CPF { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password length must be at least 8 and up to 50 characters long.")]
        public string Password { get; set; }

        [Required]
        public int Role { get; set; }

        public bool ValidarCpf()
        {
            return CpfValidation.Validate(CPF);
        }
        
        public User MapUser()
        {
            return new User()
            {
               FirstName = FirstName,
                LastName = LastName,
                CPF = CPF,
                Email = Email,
                Password = Password,
                Role = Role,
            };
        }
    }
}
