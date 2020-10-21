using System;
using System.Web;
using System.Web.Security;
using Ninject.Activation;
using SportStore.WebUI.Infrastructure.Abstract;
namespace SportsStore.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        [System.Obsolete]
        public bool Authenticate(string username, string password) {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }
        public bool isLogged(HttpCookie authCookie)
        {
            bool result = false;
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            string cookiePath = ticket.CookiePath;
            DateTime expiration = ticket.Expiration;
            bool expired = ticket.Expired;
            bool isPersistent = ticket.IsPersistent;
            DateTime issueDate = ticket.IssueDate;
            string name = ticket.Name;
            string userData = ticket.UserData;
            int version = ticket.Version;



            return result;
        }
    }
}