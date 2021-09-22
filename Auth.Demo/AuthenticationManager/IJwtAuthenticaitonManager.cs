using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Demo.AuthenticationManager
{
    public interface IJwtAuthenticaitonManager
    {
        string Authentication(string username, string password);
    }
}
