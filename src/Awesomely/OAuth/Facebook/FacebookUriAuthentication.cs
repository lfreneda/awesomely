namespace Awesomely.OAuth.Facebook
{
    public class FacebookUriAuthentication : IUriAuthentication
    {
        private readonly IConfiguration _configuration; 
        public FacebookUriAuthentication(IConfiguration configuration) {
            _configuration = configuration;
        }

        public FacebookUriAuthentication() {
            _configuration = new FacebookConfiguration();
        }

        public string GetUriInitializeAuthentication() {
            return string.Format("https://www.facebook.com/dialog/oauth?client_id={0}&redirect_uri={1}&scope=email", 
                _configuration.ApplicationId, _configuration.RedirectUri);
        }

        public string GetUriTokenRetrieve(string authorizationCode) {
            return string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}",
                _configuration.ApplicationId, _configuration.RedirectUri, _configuration.ApplicationSecret, authorizationCode);
        }
    }
}