namespace Awesomely.OAuth.Orkut
{
    public class OrkutUriAuthentication : IUriAuthentication
    {
        private readonly IConfiguration _configuration;
        public OrkutUriAuthentication(IConfiguration configuration) {
            _configuration = configuration;
        }

        public OrkutUriAuthentication() {
            _configuration = new OrkutConfiguration();
        }

        public string GetUriInitializeAuthentication() {
            return string.Format("https://accounts.google.com/o/oauth2/auth?access_type=online&approval_prompt=auto&client_id={0}&redirect_uri={1}&response_type=code&scope=https://orkut.gmodules.com/social/rest", _configuration.ApplicationId, _configuration.RedirectUri);
        }

        public string GetUriTokenRetrieve(string authorizationCode) {

            return string.Format( "https://accounts.google.com/o/oauth2/token?code={0}&client_id={1}&redirect_uri={2}&client_secret={3}&grant_type=authorization_code",
                                  authorizationCode,
                                  _configuration.ApplicationId,
                                  _configuration.RedirectUri,
                                  _configuration.ApplicationSecret );
        }
    }
}