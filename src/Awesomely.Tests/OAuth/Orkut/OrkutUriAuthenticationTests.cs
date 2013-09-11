using Awesomely.OAuth;
using Awesomely.OAuth.Orkut;
using FluentAssertions;
using NUnit.Framework;

namespace Awesomely.Tests.OAuth.Orkut {

    [TestFixture]
    public class OrkutUriAuthenticationTests {

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
            var orkutUriAuthentication = new OrkutUriAuthentication(new FakeConfiguration());
            var uri = orkutUriAuthentication.GetUriInitializeAuthentication();
            uri.Should().Be("https://accounts.google.com/o/oauth2/auth?access_type=online&approval_prompt=auto&client_id=X&redirect_uri=Y&response_type=code&scope=https://orkut.gmodules.com/social/rest");
        }

        [Test]
        public void GetUriTokenRetrieve_ShouldReturnUriTokenRetrieveWithClientIdAndRedirectUriAndSecretAndAuthorizationCode() {
            var orkutUriAuthentication = new OrkutUriAuthentication(new FakeConfiguration());
            var uri = orkutUriAuthentication.GetUriTokenRetrieve("auth/code");
            uri.Should().Be("https://accounts.google.com/o/oauth2/token?code=auth/code&client_id=X&redirect_uri=Y&client_secret=W&grant_type=authorization_code");
        }
    }
}
