using System;
using System.Collections.Generic;
using System.Text;

namespace UtilityManagerXamarin.Parameters
{
    public class Log
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class MonToken
    {

        public string id { get; set; }
        public string token { get; set; }
        public DateTime expiration { get; set; }
        public string Username { get; set; }
    }
}
