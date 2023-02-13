using System;
using server.models;

public class RefreshToken
{
    public Guid Id { get; set; }
    public string IdUtilisateur { get; set; }
    public User User { get; set; }
    public string Token { get; set; }
    public DateTime DateCreation { get; set; }
    public DateTime DateExpiration { get; set; }
    public bool IsExpired => DateTime.UtcNow >= DateExpiration;
}