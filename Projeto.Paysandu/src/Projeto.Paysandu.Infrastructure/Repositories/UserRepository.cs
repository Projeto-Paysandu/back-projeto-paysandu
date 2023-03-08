using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Projeto.Paysandu.Application.Exceptions;
using Projeto.Paysandu.Domain.Entities;
using Projeto.Paysandu.Domain.Models.InputModels;
using Projeto.Paysandu.Domain.Models.ViewModels;
using Projeto.Paysandu.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Paysandu.Domain.Interfaces.Repositories;

namespace Projeto.Paysandu.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;

        }

        ////GET:
        public async Task<List<User>> GetMany(int page, int qty)
        {
            int skip = (page - 1) * qty;
            return await _context.Users
                .Skip(skip)
                .Take(qty)
                .ToListAsync();

        }

        //GET:
        public async Task<User> Get(string cpf)
        {

            var userEntityFromDb = await _context.Users.FirstOrDefaultAsync(u => u.CPF.Equals(cpf));

            if (userEntityFromDb == null)
            {
                throw new UserDoesNotExistException();
            }

            return userEntityFromDb;

        }


        //POST:
        public async Task<User> Insert(User newUser)
        {
            var userEntityFromDb = await _context.Users.AnyAsync(user => user.CPF.Equals(newUser.CPF));
            if (userEntityFromDb)
            {
                throw new UserAlreadyExistsException();
            }

            //newInput.Id = Guid.NewGuid();    
            try
            {
                _context.Users.Add(newUser);
               var aa =  await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //catch (DbUpdateConcurrencyException)
            //{
            //    throw new DbUpdateConcurrencyException();
            //}

            return newUser;
        }

        public async Task<User> Update(string cpf, User user)
        {
            var userEntityFromDb = await _context.Users.FirstOrDefaultAsync(u => u.CPF.Equals(cpf));
            if (userEntityFromDb == null)
            {
                throw new UserDoesNotExistException();
            }
            userEntityFromDb.FirstName = user.FirstName;
            userEntityFromDb.LastName = user.LastName;
            userEntityFromDb.CPF = user.CPF;
            userEntityFromDb.Password = user.Password;
            userEntityFromDb.Email = user.Email;
            userEntityFromDb.Role = user.Role;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbUpdateConcurrencyException();
            }
            return userEntityFromDb;
            

        }

        public async Task Delete(string cpf)
        {
            var userEntityFromDb = await _context.Users.FirstOrDefaultAsync(u => u.CPF.Equals(cpf));
            if (userEntityFromDb == null)
            {
                throw new UserDoesNotExistException();
            }

            _context.Users.Remove(userEntityFromDb);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbUpdateConcurrencyException();
            }

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
