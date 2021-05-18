using Newtonsoft.Json;

namespace Xinder.Models.DTOs
{
    public class LogInResponseDTO
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
