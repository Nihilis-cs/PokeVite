using System.Data.Entity;
using APIBaseClient.Helpers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using server.models;
using server.Models;
using server.Models.DTO.Tokens;
using server.Queries;

public class LoginQueryHandler : IRequestHandler<LoginQuery, TokenResponse>
{
    private readonly PokeDbContext _DbContext;
    private readonly SignInManager<User> _SignInManager;
    private readonly AuthSettings _AuthSettings;

    public LoginQueryHandler(PokeDbContext aDbContext, SignInManager<User> aSignInManager, AuthSettings aAuthSettings)
    {
        _DbContext = aDbContext;
        _SignInManager = aSignInManager;
        _AuthSettings = aAuthSettings;
    }

    public async Task<TokenResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var vUser = await _DbContext.Users.Where(u => u.Name == request._LoginDto.Name).FirstOrDefaultAsync();
        if (vUser == null) throw new Exception("Unknown user");

        var vResult = await _SignInManager.CheckPasswordSignInAsync(vUser, request._LoginDto.Password, false);
        if (!vResult.Succeeded) throw new Exception("Incorrect password");

        var vAccessToken = AuthHelper.GenerateIDToken(_AuthSettings, vUser);
        var vRefreshToken = AuthHelper.GenerateRefreshToken(vUser.Id);

        vUser.RefreshTokens.Add(vRefreshToken);
        await _DbContext.SaveChangesAsync();

        return new TokenResponse()
        {
            AccessToken = vAccessToken,
            RefreshToken = vRefreshToken.Token,
        };
    }

}
