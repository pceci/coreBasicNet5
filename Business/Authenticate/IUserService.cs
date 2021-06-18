using coreBasicNet5.Entities.Authenticate;

namespace coreBasicNet5.Business
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}