using System.Configuration;

namespace Awesomely.OAuth.Orkut
{
    public class OrkutConfiguration : IConfiguration {
        public string ApplicationId {
            get { return ConfigurationManager.AppSettings["orkut.client.id"]; }
        }

        public string ApplicationSecret {
            get { return ConfigurationManager.AppSettings["orkut.client.secret"]; }
        }

        public string RedirectUri {
            get { return ConfigurationManager.AppSettings["orkut.redirect.uri"]; }
        }
    }
}