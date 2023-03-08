using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Paysandu.Domain.Entities
{
    [Table("user")]
    public class User : IdentityUser
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Column("FIRST_NAME")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [Column("LAST_NAME")]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [Column("CPF")]
        [Key]
        [StringLength(11)]
        public string CPF { get; set; }

        [Required]
        [Column("EMAIL")]
        [StringLength(20)]
        public string Email { get; set; }

        [Required]
        [Column("PASSWORD")]
        [StringLength(70)]
        public string Password { get; set; }

        [Required]
        [Column("ROLE")]
        public int Role { get; set; }

    }
}
