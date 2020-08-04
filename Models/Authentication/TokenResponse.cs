using Newtonsoft.Json;

namespace Nop.Plugin.Api.Models.Authentication
{
    public class TokenResponse
    {
        public TokenResponse(string errorDescription)
        {
            ErrorDescription = errorDescription;
        }

        public TokenResponse(string accessToken, long expiresInSeconds, string email, int id, bool active, string tokenType = "Bearer")
        {
            AccessToken = accessToken;
            ExpiresInSeconds = expiresInSeconds;
            TokenType = tokenType;
            Email = email;
            Id = id;
            Active = active;
        }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; } = "Bearer";

        [JsonProperty("expires_in")]
        public long ExpiresInSeconds { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}