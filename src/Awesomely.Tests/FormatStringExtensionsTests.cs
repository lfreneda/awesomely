using Awesomely.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace Awesomely.Tests {

    [TestFixture]
    public class FormatStringExtensionsTests {

        [Test]
        public void FormatWith_GivenAString_ShouldFormatIt() {
            const string name = "Luiz Freneda";
            "{0}, tudo bem?".FormatWith(name).Should().Be("Luiz Freneda, tudo bem?");
        }
    }
}
