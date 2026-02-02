using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Common.Security
{
    public class RPGHubPrincipal : IPrincipal
    {
        public IIdentity Identity { internal set; get; }

        public RPGHubPrincipal(string userEmail)
        {
            IIdentity identity = new RPGHubIdentity(userEmail);
            Identity = identity;
        }
        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}
