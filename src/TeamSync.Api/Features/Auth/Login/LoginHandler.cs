using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamSync.Api.Common;
using TeamSync.Api.Data;

namespace TeamSync.Api.Features.Auth.Login;

public sealed class LoginHandler(
    ApplicationDbContext dbContext,
    IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users
            .FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid email or password.");

        var token = jwtProvider.Generate(user);

        return new LoginResponse(token);
    }
}