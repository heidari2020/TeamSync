using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamSync.Api.Common;
using TeamSync.Api.Data;
using TeamSync.Api.Domain;

namespace TeamSync.Api.Features.Auth.Register;

public sealed class RegisterHandler(
    ApplicationDbContext dbContext,
    IJwtProvider jwtProvider) : IRequestHandler<RegisterCommand, RegisterResponse>
{
    public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var emailExists = await dbContext.Users.AnyAsync(x => x.Email == request.Email, cancellationToken);
        if (emailExists)
            throw new Exception("Email is already registered."); 

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = passwordHash
        };

        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync(cancellationToken);

        var token = jwtProvider.Generate(user);

        return new RegisterResponse(user.Id, token);
    }
}