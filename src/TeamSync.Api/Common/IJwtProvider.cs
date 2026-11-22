using TeamSync.Api.Domain;

namespace TeamSync.Api.Common;
public interface IJwtProvider
{
    string Generate(User user);
}