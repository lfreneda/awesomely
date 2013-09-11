using Awesomely.OAuth;
using FluentAssertions;
using NUnit.Framework;

namespace lfreneda.oauth2.tests {
    
    [TestFixture]
    public class OAuthAuthenticationTests {

        public class WebRequestServiceFake : IWebRequestService {

            public int GetCalls { get; set; }
            public int PostCalls { get; set; }
            
            public string Get(string uri)
            {
                GetCalls++;
                return "";
            }

            public string Post(string uri) {
                PostCalls++;
                return "";
            }
        }
        public class UriAuthenticationFake : IUriAuthentication
        {
            public string GetUriInitializeAuthentication()
            {
                return "";
            }

            public string GetUriTokenRetrieve(string authorizationCode)
            {
                return "";
            }
        }
        public class ExtractTokenFromTextFake : IExtractTokenFromText
        {
            public string ExtractStringReturn { get; set; }

            public string Extract(string text) {
                return ExtractStringReturn;
            }
        }
        
        [Test]
        public void Authenticate_WhenResponseTypeIsGet_ShouldCallWebRequestServiceGetMethod() {

            WebRequestServiceFake mockWebRequestServiceFake;
            OAuthAuthentication oAuthAuthentication = CreateOAuthAuthentication(out mockWebRequestServiceFake);
            oAuthAuthentication.Authenticate("any authoritzation code", RequestType.Get);

            mockWebRequestServiceFake.GetCalls.Should().Be(1);
        }

        [Test]
        public void Authenticate_WhenResponseTypeIsPost_ShouldCallWebRequestServicePostMethod() {
            WebRequestServiceFake mockWebRequestServiceFake;
            OAuthAuthentication oAuthAuthentication = CreateOAuthAuthentication(out mockWebRequestServiceFake);
            oAuthAuthentication.Authenticate("any authoritzation code", RequestType.Post);

            mockWebRequestServiceFake.PostCalls.Should().Be(1);
        }

        [Test]
        public void Authenticate_WhenTokenReturnedByExtractClassIsNotNull_ShouldReturnTrue() {
            var extractTokenFromTextFake = new ExtractTokenFromTextFake { ExtractStringReturn = "token value" };
            OAuthAuthentication oAuthAuthentication = CreateOAuthAuthenticationWith(extractTokenFromTextFake);
            var gotToken = oAuthAuthentication.Authenticate("any authoritzation code", RequestType.Post);

            gotToken.Should().Be(true);
        }

        [Test]
        public void Authenticate_WhenTokenReturnedByExtractClassIsNull_ShouldReturnFalse() {
            var extractTokenFromTextFake = new ExtractTokenFromTextFake {ExtractStringReturn = null};
            OAuthAuthentication oAuthAuthentication = CreateOAuthAuthenticationWith(extractTokenFromTextFake);
            var gotToken = oAuthAuthentication.Authenticate("any authoritzation code", RequestType.Post);

            gotToken.Should().Be(false);
        }

        private OAuthAuthentication CreateOAuthAuthenticationWith(ExtractTokenFromTextFake extractTokenFromText) {
            WebRequestServiceFake mockWebRequestServiceFake;
            return CreateOAuthAuthentication(out mockWebRequestServiceFake, extractTokenFromText);
        }

        private static OAuthAuthentication CreateOAuthAuthentication(out WebRequestServiceFake webRequestServiceFake) {
            return CreateOAuthAuthentication(out webRequestServiceFake, new ExtractTokenFromTextFake());
        }

        private static OAuthAuthentication CreateOAuthAuthentication(out WebRequestServiceFake webRequestServiceFake, ExtractTokenFromTextFake extractTokenFromText) {

            var uriAuthenticationFake = new UriAuthenticationFake();
            webRequestServiceFake = new WebRequestServiceFake();

            return new OAuthAuthentication(webRequestServiceFake, uriAuthenticationFake, extractTokenFromText);
        }
    }
}
