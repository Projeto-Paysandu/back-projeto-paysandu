using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Projeto.Paysandu.Application.Exceptions;
using Projeto.Paysandu.Application.Interfaces;
using Projeto.Paysandu.Domain.Entities;
using Projeto.Paysandu.Domain.Interfaces.Repositories;
using Projeto.Paysandu.Domain.Models.InputModels;
using Projeto.Paysandu.Domain.Models.ViewModels;

namespace Projeto.Paysandu.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;

        }


        //GET:
        public async Task<List<UserViewModel>> GetUsers(int page, int qty)
        {
            var res = await _userRepository.GetMany(page, qty);

            return res.Select(x => new UserViewModel(x)).ToList();
        }

        //GET:id
        public async Task<UserViewModel> GetUser(string cpf)
        {
            try
            {
                _logger.LogInformation($"Retrieving user data.");

                var user = await _userRepository.Get(cpf);

                _logger.LogInformation($"User data retrieved successfully.");

                return new UserViewModel(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving the data. Message: {ex.Message}");
                throw;
            }

        }

        //POST:
        public async Task<UserViewModel> InsertUser(UserInput newInsert)
        {

            try
            {
                if (newInsert.ValidarCpf() == false)
                {
                    throw new InvalidCpfException();

                }

                _logger.LogInformation($"Inserting new user...");

                var newUser = newInsert.MapUser();

                var user = await _userRepository.Insert(newUser);

                _logger.LogInformation($"User data retrieved successfully.");

                return new UserViewModel(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error insertingdata. Message: {ex.Message}");
                throw;
            }
            
        }

        //PUT
        public async Task<UserViewModel> UpdateUser(string cpf, UserInput user)
        {
            try
            {
                if (user.ValidarCpf() == false)
                {
                    throw new InvalidCpfException();

                }

                _logger.LogInformation($"Updating user data...");

                var userUpdate = user.MapUser();

                var userUpdated = await _userRepository.Update(cpf, userUpdate);

                _logger.LogInformation($"User data updated successfully.");

                return new UserViewModel(userUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating data. Message: {ex.Message}");
                throw;
            }

        }

        //DELETE
        public async Task DeleteUser(string cpf)
        {
            try
            {
                _logger.LogInformation($"Deleting user data...");

                await _userRepository.Delete(cpf);

                _logger.LogInformation($"User data deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting data. Message: {ex.Message}");
                throw;
            }

        }
        public void Dispose()
        {
            _userRepository?.Dispose();
        }
    }
}
