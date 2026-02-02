using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Common.Security
{
    public class RPGHubIdentity : IIdentity
    {
        public string AuthenticationType { internal set; get; }

        public bool IsAuthenticated { internal set; get; }

        public string Name { internal set; get; }

        public RPGHubIdentity(string userEmail)
        {
            Name = userEmail == string.Empty ? "Anon" : userEmail;
            IsAuthenticated = userEmail != string.Empty;
            AuthenticationType = string.Empty;
        }
    }
}
