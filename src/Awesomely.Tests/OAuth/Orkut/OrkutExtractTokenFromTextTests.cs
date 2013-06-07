using Awesomely.OAuth.Orkut;
using FluentAssertions;
using NUnit.Framework;

namespace Awesomely.Tests.OAuth.Orkut {
    
    [TestFixture]
    public class OrkutExtractTokenFromTextTests {

        [Test]
        public void Extract_ForTheGivenText_ShouldReturnToken() {
            const string responseText = "{\"access_token\" : \"ya29.AHES6ZRpxXmtKIk-wILjffqg-CDaXjZEX26L5bvNW8QaH1FuIsdTNg\", \"token_type\" : \"Bearer\", \"expires_in\" : 3600 }";
            var extractTokenFromText = new OrkutExtractTokenFromText();
            var token = extractTokenFromText.Extract(responseText);
            token.Should().Be("ya29.AHES6ZRpxXmtKIk-wILjffqg-CDaXjZEX26L5bvNW8QaH1FuIsdTNg");
        }

        [Test]
        public void Extract_WhenTextIsInvalid_ShouldReturnNull() {
            const string responseText = "{\"sadghzxjhcbzxjhbca!!1!Oi26L5bvNW8QaH1FuIsdTNg\", \"token_type\" : \"Bearer\", \"expires_in\" : 3600 }";
            var extractTokenFromText = new OrkutExtractTokenFromText();
            var token = extractTokenFromText.Extract(responseText);
            token.Should().BeNull();
        }

        [Test]
        public void Extract_WhenTextIsNull_ShouldReturnNull() {
            const string responseText = null;
            var extractTokenFromText = new OrkutExtractTokenFromText();
            var token = extractTokenFromText.Extract(responseText);
            token.Should().BeNull();
        }
    }
}
