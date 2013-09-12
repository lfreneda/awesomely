namespace Awesomely.OAuth.Facebook
{
    public class FacebookUriAuthentication : IUriAuthentication
    {
        private readonly bool _secure;
        private readonly IConfiguration _configuration;
        public FacebookUriAuthentication(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public FacebookUriAuthentication(bool secure)
        {
            _secure = secure;
            _configuration = new FacebookConfiguration();
        }

        public string GetUriInitializeAuthentication()
        {
            var redirectUrl = _configuration.RedirectUri;
            if (_secure)
            {
                redirectUrl = redirectUrl.Replace("http://", "https://");
            }

            return string.Format("https://www.facebook.com/dialog/oauth?client_id={0}&redirect_uri={1}&scope=email",
                _configuration.ApplicationId, redirectUrl);
        }

        public string GetUriTokenRetrieve(string authorizationCode)
        {
            var redirectUrl = _configuration.RedirectUri;
            if (_secure)
            {
                redirectUrl = redirectUrl.Replace("http://", "https://");
            }
            return string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}",
                _configuration.ApplicationId, redirectUrl, _configuration.ApplicationSecret, authorizationCode);
        }
    }
}