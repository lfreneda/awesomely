using FluentAssertions;
using NUnit.Framework;
using Awesomely.Extensions;

namespace Awesomely.Tests
{
    [TestFixture]
    public class ObjectExtensionsTests
    {
        [Test]
        public void ToDictionary_WhenConvertingAnonymousObjectToDictionaryWith2Properties_CountShouldBe2()
        {
            var dictionary = new { name = "Luiz", lastName = "Freneda" }.ToDictionary();
            dictionary.Count.Should().Be(2);
        }

        [Test]
        public void ToDictionary_WhenConvertingAnonymousObjectToDictionary_ShouldContainPropertiesAsKeys()
        {
            var dictionary = new { name = "Luiz", lastName = "Freneda" }.ToDictionary();
            dictionary.ContainsKey("name").Should().Be(true);
            dictionary.ContainsKey("lastName").Should().Be(true);
        }

        [Test]
        public void ToDictionary_WhenConvertingAnonymousObjectToDictionary_ShouldContainValuesAsValues()
        {
            var dictionary = new { name = "Luiz", lastName = "Freneda" }.ToDictionary();
            dictionary["name"].Should().Be("Luiz");
            dictionary["lastName"].Should().Be("Freneda");
        }
    }
}
