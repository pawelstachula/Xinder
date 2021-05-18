using Newtonsoft.Json;

namespace Xinder.Models.DTOs
{
    public class LogInRequestDTO
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
