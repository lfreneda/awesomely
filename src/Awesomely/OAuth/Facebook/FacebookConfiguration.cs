using System.Configuration;

namespace Awesomely.OAuth.Facebook
{
    public class FacebookConfiguration : IConfiguration
    {
        public string ApplicationId {
            get { return ConfigurationManager.AppSettings["facebook.application.id"]; }
        }

        public string ApplicationSecret {
            get { return ConfigurationManager.AppSettings["facebook.application.secret"]; }
        }

        public string RedirectUri {
            get { return ConfigurationManager.AppSettings["facebook.redirect.uri"]; }
        }
    }
}