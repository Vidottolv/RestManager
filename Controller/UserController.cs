using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestManager.Models;
using RestManager.Services;

namespace RestManager.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<User>>> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsers();
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro na hora de consultar os usuarios");
            }
        }

        [HttpGet("UserName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<User>>> GetUserByName([FromQuery] string name)
        {

            try
            {
                var users = await _userService.GetUserByName(name);
                
                if(users.Count()==0)
                    return NotFound($"Não existem usuarios com o nome {name}");

                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro na hora de consultar os usuarios");
            }
        }

        [HttpGet("{id:int}", Name="GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var users = await _userService.GetUser(id);
                if (users == null)
                    return NotFound($"Não existem usuarios com o id {id}");

                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro na hora de consultar os usuarios");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            try
            {
                await _userService.CreateUser(user);
                return CreatedAtRoute(nameof(GetUser), new { id = user.Id }, user);
            }
            catch 
            {
                return BadRequest("deu xabu");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            try
            {
                if(user.Id == id)
                {
                    await _userService.UpdateUser(user);
                    return Ok($"Usuário com id = {id} foi atualizado");
                }
                else
                {
                    return BadRequest("Dado inconsistente");
                }
            }
            catch
            {
                return BadRequest("deu xabu");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _userService.GetUser(id);
                if (user != null)
                {
                    await _userService.DeleteUser(user);
                    return Ok($"user de id = {id} foi excluido");
                }
                else {
                    return BadRequest($"user de id = {id} não encontrado");
                }
            }
            catch
            {
                return BadRequest("deu xabu");
            }
        }
    }
}
