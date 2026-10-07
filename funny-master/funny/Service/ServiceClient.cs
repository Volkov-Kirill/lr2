using funny.Models;
using System.Text.Json;

namespace funny.Service
{
    public class ServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        }

        public async Task<(bool IsSuccess, string Message, int StatusCode)> RegisterUserAsync(UserDTO model)
        {
            if (model.Archive || model.Blocked)
            {
                return (false, "Вы не обслуживаетесь", 403);
            }

            try
            {
                var response = await _httpClient.PostAsJsonAsync("http://localhost:8000/users/true", model, _jsonOptions);

                if (response.IsSuccessStatusCode)
                {
                    return (true, "Пользователь успешно создан в системе безопасности", 200);
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                return (false, $"Ошибка смежной системы: {errorContent}", (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                return (false, $"Не удалось связаться со службой безопасности: {ex.Message}", 500);
            }
        }
    }
}
