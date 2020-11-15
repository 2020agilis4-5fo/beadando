using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imagehub.Core
{
    public static class StringConstants
    {
        public const string DB_CONNECTION_STRING = "Server=tcp:dbdev45.database.windows.net,1433;Initial Catalog=45dev;Persist Security Info=False;User ID=ddani;Password=Asdasd123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=240;";
        public const string CHARACTERS_ALL = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        public const string PATH_LOGIN = "/Account/Login";
        public const string CORS_POLICY_NAME = "img";
        public const string SITE = "https://agilis45dev.azurewebsites.net";
    }
}
