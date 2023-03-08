using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Paysandu.Application.Interfaces;
using Projeto.Paysandu.Domain.Models.InputModels;
using Projeto.Paysandu.Domain.Models.ViewModels;
using System.Data;

namespace Projeto.Paysandu.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;

        }

        //[HttpGet]
        ////[Authorize(Roles = ",")]
        //public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers()
        //{
        //    var victims = await _service.GetUsers();

        //    if (victims.Count == 0)
        //    {
        //        return NoContent();
        //    }

        //    return Ok(victims);
        //}


        // GET api/<UsersController>/5
        [HttpGet("{userId}", Name = "GetUser")]
        public async Task<ActionResult<UserViewModel>> GetUser([FromRoute] string userId)
        {

            try
            {
                var userFromDb = await _service.GetUser(userId);
                return Ok(userFromDb);

            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        //[HttpGet("byEmail", Name = "GetUserByEmail")]
        //public async Task<ActionResult<UserViewModel>> GetUserByCpf([FromQuery] string cpf)
        //{
        //    var userFromDb = await _service.GetByEmail(cpf);

        //    if (userFromDb == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(userFromDb);
        //}

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<UserViewModel>> AddUser([FromBody] UserInput userInput)
        {
            if (userInput is null)
                return BadRequest(new ArgumentNullException());

            try
            {
                var userEntity = await _service.InsertUser(userInput);

                return Created(nameof(GetUser), userEntity);

            }
            //InvalidCpfException
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser([FromRoute] string userId, [FromBody] UserInput personInput)
        {
            try
            {
                var updatedUser = await _service.UpdateUser(userId, personInput);
                return Ok(updatedUser);

            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }


        // DELETE api/<UsersController>/5
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            try
            {
                await _service.DeleteUser(userId);
                return NoContent();
            }

            
            catch (Exception e)
            {
                return NotFound(e);
            };

        }
    }
}
