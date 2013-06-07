namespace Awesomely.OAuth {

    public class OAuthAuthentication {

        private readonly IWebRequestService _webRequestService;
        private readonly IUriAuthentication _uriAuthentication;
        private readonly IExtractTokenFromText _extractTokenFromText;

        public OAuthAuthentication(IWebRequestService webRequestService,
                                      IUriAuthentication uriAuthentication,
                                      IExtractTokenFromText extractTokenFromText) {

            _webRequestService = webRequestService;
            _uriAuthentication = uriAuthentication;
            _extractTokenFromText = extractTokenFromText;
        }

        public OAuthAuthentication(IUriAuthentication uriAuthentication,
                                   IExtractTokenFromText extractTokenFromText) {

            _webRequestService = new WebRequestService();
            _uriAuthentication = uriAuthentication;
            _extractTokenFromText = extractTokenFromText;
        }

        public string Token { get; private set; }

        public bool Authenticate(string authorizationCode) {
            return Authenticate(authorizationCode, RequestType.Get);
        }

        public bool Authenticate(string authorizationCode, RequestType requestType) {

            var uri = _uriAuthentication.GetUriTokenRetrieve(authorizationCode);

            var responseText = (requestType.Equals(RequestType.Get))
                                      ? _webRequestService.Get(uri)
                                      : _webRequestService.Post(uri);

            Token = _extractTokenFromText.Extract(responseText);
            return (Token != null);
        }
    }
}