using funny.Models;
using funny.Service;
using Microsoft.AspNetCore.Mvc;
using Serilog.Core;

namespace funny.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly HttpClient _httpClient;

        public UsersController(ILogger<UsersController> logger)
        {
            _httpClient = new HttpClient();
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO model)
        {
            if (model.Archive || model.Blocked)
            {
                return StatusCode(403, "Вы не обслуживаетесь");
            }

            try
            {
                var jsonOptions = new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = null
                };

                var response = await _httpClient.PostAsJsonAsync("http://localhost:8000/users/true", model, jsonOptions);

                if (response.IsSuccessStatusCode)
                {
                    return Ok(new { message = "Пользователь успешно создан в системе безопасности" });
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                return StatusCode((int)response.StatusCode, $"Ошибка смежной системы: {errorContent}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Не удалось связаться со службой безопасности: {ex.Message}");
            }
        }
    }
}
