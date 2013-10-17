using System.Text;
using Awesomely.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace Awesomely.Tests {

    [TestFixture]
    public class EnumExtensionsTests {

        private enum EnumSample {
            [System.ComponentModel.Description("LaLaLa Description")]
            LaLaLa = 1,
            [System.ComponentModel.Description("LuLuLu Description")]
            LuLuLu = 2
        }

        [Test]
        public void GetDescription_GivenAEnumWithDescriptionAttr_ShouldGetCorrectDescription() {
            const EnumSample @enum = EnumSample.LaLaLa;
            @enum.GetDescription().Should().Be("LaLaLa Description");
        }
    }
}
