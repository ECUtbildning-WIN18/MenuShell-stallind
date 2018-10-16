using System.Collections.Generic;
using MenuShell.Domain;

namespace MenuShell.Services
{
    interface IAuthService
    {
        User Auth(string userName, string password);
    }
}
