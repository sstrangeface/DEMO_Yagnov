using DemoEx.DBmodel;

namespace DemoEx.Services
{
    public interface IAuthService
    {
        Users Authenticate(string login, string pass);
    }
}
