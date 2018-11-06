using MenuShell.Domain;

namespace MenuShell.Services
{
    internal interface IAuthService
    {
        User Auth(string username, string password);
    }
}