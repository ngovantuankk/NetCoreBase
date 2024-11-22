namespace NetCoreBase.Application.Common;

public interface IJwtGenerator
{
    string GenerateJwt(Guid id, string firstName, string lastName, string address);
}