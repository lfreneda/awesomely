using Awesomely.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace Awesomely.Tests {

    [TestFixture]
    public class StringExtensionsTests {

        [Test]
        public void RemoveNewLinesAndSpaces_GivenAString_ShouldRemoveNewLinesAndSpaces() {
            const string givenString = @"oi
                                   tudo
                                   bom
                                   com               você?";

            givenString.RemoveNewLinesAndSpaces().Should().Be("oitudobomcomvocê?");
        }

        [Test]
        public void RemoveNewLinesAndSpaces_GivenOneMoreString_ShouldRemoveNewLinesAndSpaces() {
            const string givenString = "\noi\ntudo\nbom           ?";
            givenString.RemoveNewLinesAndSpaces().Should().Be("oitudobom?");
        }

        [Test]
        public void ExceptChars_GivenAString_ShouldExcludeCharacters() {
            "Can you remove 'a' from this phrase?".ExceptChars(new[] { 'a' })
                .Should().Be("Cn you remove '' from this phrse?");
        }

        [Test]
        public void RemoveSpecialCharacters_GivenString_ShouldRemoveAllSpecialCharacters() {
            @"""!@#$%¨&*()_+{}?:>^`<+.-*/\qwertyuiopasdfghjklçzxcvbnm0123456789".RemoveSpecialCharacters()
                .Should().Be("qwertyuiopasdfghjklçzxcvbnm0123456789");
        }

        [Test]
        public void ContainIn_GivenSubStringThatContainInAString_ShouldReturnTrue() {
            "ikeCho".ContainIn("ILikeChocolate").Should().Be(true);
        }

        [Test]
        public void ContainIn_GivenSubStringThatDoesNotContainInAString_ShouldReturnFalse() {
            "kehocole".ContainIn("ILikeChocolate").Should().Be(false);
        }
    }
}
