using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppInventario.Models
{
    public class UserDto
    {
        [Required]
        [JsonPropertyName("employeeNumber")]
        public string EmployeeNumber { get; set; } = string.Empty;

        [Required, StringLength(100)]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("ap")]
        public string? Ap { get; set; }

        [JsonPropertyName("am")]
        public string? Am { get; set; }

        [Required, StringLength(50)]
        [JsonPropertyName("userName")]
        public string UserName { get; set; } = string.Empty;

        [Required, StringLength(100)]
        [JsonPropertyName("accessKey")]
        public string AccessKey { get; set; } = string.Empty;

        [JsonPropertyName("position")]
        public string? Position { get; set; }

        [JsonPropertyName("department")]
        public string? Department { get; set; }

    }
}
