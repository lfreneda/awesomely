using Awesomely.OAuth;
using Awesomely.OAuth.Facebook;
using FluentAssertions;
using NUnit.Framework;

namespace Awesomely.Tests.OAuth.Facebook {
    
    [TestFixture]
    public class FacebookUriAuthenticationTests {

        public class FakeConfiguration : IConfiguration {
            public string ApplicationId {
                get { return "X"; }
            }

            public string ApplicationSecret {
                get { return "W"; }
            }

            public string RedirectUri {
                get { return "Y"; }
            }
        }

        [Test]
        public void GetUriInitializeAuthentication_ShouldReturnUriForAuthenticationWithClientIdAndRedirectUri() {
            var uriAuthenticationFacebook = new FacebookUriAuthentication(new FakeConfiguration());
            var uri = uriAuthenticationFacebook.GetUriInitializeAuthentication();
            uri.Should().Be("https://www.facebook.com/dialog/oauth?client_id=X&redirect_uri=Y&scope=email");
        }

        [Test]
        public void GetUriTokenRetrieve_ShouldReturnUriTokenRetrieveWithClientIdAndRedirectUriAndSecretAndAuthorizationCode() {
            var uriAuthenticationFacebook = new FacebookUriAuthentication(new FakeConfiguration());
            var uri = uriAuthenticationFacebook.GetUriTokenRetrieve("auth/code");
            uri.Should().Be("https://graph.facebook.com/oauth/access_token?client_id=X&redirect_uri=Y&client_secret=W&code=auth/code");
        }
    }
}
