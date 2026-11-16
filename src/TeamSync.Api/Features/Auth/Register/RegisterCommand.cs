using MediatR;

namespace TeamSync.Api.Features.Auth.Register;

public sealed record RegisterCommand(string Username, string Email, string Password) : IRequest<RegisterResponse>;

public sealed record RegisterResponse(Guid UserId, string Token);