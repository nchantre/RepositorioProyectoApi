using AppInventario.Models;
using System.Net;

namespace AppInventario.Services
{
    public class UsersClient
    {
        private readonly HttpClient _http;

        public UsersClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<UserDto>> GetAllAsync(CancellationToken ct = default)
        {
            var result = await _http.GetFromJsonAsync<List<UserDto>>("User", cancellationToken: ct);
            return result ?? new List<UserDto>();
        }

        public async Task<UserDto?> GetByIdAsync(string employeeNumber, CancellationToken ct = default)
        {
            return await _http.GetFromJsonAsync<UserDto>($"User/{WebUtility.UrlEncode(employeeNumber)}", ct);
        }

        public async Task<(bool ok, string? error)> CreateAsync(UserDto user, CancellationToken ct = default)
        {
            var res = await _http.PostAsJsonAsync("User", user, ct);
            if (res.IsSuccessStatusCode) return (true, null);
            return (false, await res.Content.ReadAsStringAsync(ct));
        }

        public async Task<(bool ok, string? error)> UpdateAsync(UserDto user, CancellationToken ct = default)
        {
            // El body debe tener un objeto con propiedad "request"
            var body = new { request = user };

            // Llamada al endpoint con el employeeNumber en la URL
            var res = await _http.PutAsJsonAsync(
                $"User/{WebUtility.UrlEncode(user.EmployeeNumber)}",
                body,
                ct
            );

            if (res.IsSuccessStatusCode)
                return (true, null);

            return (false, await res.Content.ReadAsStringAsync(ct));
        }

        public async Task<(bool ok, string? error)> DeleteAsync(string employeeNumber, CancellationToken ct = default)
        {
            var res = await _http.DeleteAsync($"User/{WebUtility.UrlEncode(employeeNumber)}", ct);
            if (res.IsSuccessStatusCode) return (true, null);
            return (false, await res.Content.ReadAsStringAsync(ct));
        }
    }
}
