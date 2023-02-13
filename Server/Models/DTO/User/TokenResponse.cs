namespace server.Models.DTO.Tokens;
    public class TokenRequest
    {
        public string RefreshToken { get; set; }
    }
    
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }