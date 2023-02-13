using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using server.models;
using server.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace APIBaseClient.Helpers{
    public static class AuthHelper{
        public static string GenerateIDToken(AuthSettings aAuthSettings, User aUser)
        {
            var claims = new[]
            {
                new Claim("Id", aUser.Id),
                new Claim("Name", aUser.Name),
                new Claim("Role", aUser.UtilisateurRoles.First().Role.Name),
                new Claim(ClaimTypes.NameIdentifier, aUser.Id)
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(aAuthSettings.Key));
            var token = new JwtSecurityToken(
                issuer: aAuthSettings.Issuer,
                audience: aAuthSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
                
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static RefreshToken GenerateRefreshToken(string userId)
        {
            using(var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshToken
                {
                    IdUtilisateur= userId,
                    Token = Convert.ToBase64String(randomBytes),
                    DateExpiration = DateTime.UtcNow.AddDays(7),
                    DateCreation = DateTime.UtcNow
                };
            }
        }
    }
}