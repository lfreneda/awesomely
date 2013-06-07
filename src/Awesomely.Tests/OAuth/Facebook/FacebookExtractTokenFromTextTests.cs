using Awesomely.OAuth.Facebook;
using FluentAssertions;
using NUnit.Framework;

namespace Awesomely.Tests.OAuth.Facebook {
    
    [TestFixture]
    public class FacebookExtractTokenFromTextTests {

        [Test]
        public void Extract_ForTheGivenText_ShouldReturnToken() {
            const string responseText = "access_token=AAAEcvlX8wxcBAHqvsvVLwjzcmCbQiIaxXh2pKvbmeDy822LsY9tWI0SSZCTjlEw1vPPoPLB05ImGIXllYsqqxZB1EQEGpsbkAyZB9plDgZDZD&expires=5181796";
            var extractTokenFromText = new FacebookExtractTokenFromText();
            var token = extractTokenFromText.Extract(responseText);
            token.Should().Be("AAAEcvlX8wxcBAHqvsvVLwjzcmCbQiIaxXh2pKvbmeDy822LsY9tWI0SSZCTjlEw1vPPoPLB05ImGIXllYsqqxZB1EQEGpsbkAyZB9plDgZDZD");
        }

        [Test]
        public void Extract_WhenTextIsInvalid_ShouldReturnNull() {
            const string responseText = "girlyouhavesomethingspecialforme?=AAAEcvlX8wxcBAHqvsvVLwjzcmCbQiIaxXh2pKvbmeDy822LsY9tWI0SSZCTjlEw1vPPoPLB05ImGIXllYsqqxZB1EQEGpsbkAyZB9plDgZDZD&expires=5181796";
            var extractTokenFromText = new FacebookExtractTokenFromText();
            var token = extractTokenFromText.Extract(responseText);
            token.Should().BeNull();
        }

        [Test]
        public void Extract_WhenTextIsNull_ShouldReturnNull() {
            const string responseText = null;
            var extractTokenFromText = new FacebookExtractTokenFromText();
            var token = extractTokenFromText.Extract(responseText);
            token.Should().BeNull();
        }
    }
}
