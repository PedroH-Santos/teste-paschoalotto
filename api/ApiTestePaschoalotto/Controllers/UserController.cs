using ApiTestePaschoalotto.DataBase;
using ApiTestePaschoalotto.Models;
using ApiTestePaschoalotto.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Text;

namespace ApiTestePaschoalotto.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel userLogin)
        {
            var token = await _userService.Authenticate(userLogin.Username, userLogin.Password);
            if (token == null)
                return Unauthorized(new { message = "Username or password is incorrect" });

            return Ok(new { token });
        }


        [AllowAnonymous]
        // GET: UserController
        [HttpGet]
        public async Task<List<UserModel>> GetAll()
        {
            return await _userService.GetUsers();
        }


        [AllowAnonymous]
        // POST: UserController/UploadNewUsers
        [HttpPost("/uploadNewUsers")]
        public async Task<IActionResult> UploadNewUsers()
        {
            try
            {
                await _userService.UploadNewUsers();
                return Ok("Users uploaded successfully.");
            }
            catch (Exception ex)
            {

                return BadRequest($"An error occurred while uploading users: {ex.Message}");
            }
        }
        [Authorize]
        // GET: UserController/ExportUsers
        [HttpGet("/exportUsers")]
        public async Task<IActionResult> ExportUsers()
        {
            try
            {
                var csvData = await _userService.ExportUsersAsCsv();
                var bytes = Encoding.UTF8.GetBytes(csvData);
                var output = new FileContentResult(bytes, "text/csv")
                {
                    FileDownloadName = "users.csv"
                };
                return output;
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // _logger.LogError(ex, "Error exporting users");

                return BadRequest($"An error occurred while exporting users: {ex.Message}");
            }
        }

    }
}
