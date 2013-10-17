using System.Linq;
using System.Reflection;
using Awesomely.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace Awesomely.Tests
{
    [TestFixture]
    public class AssemblyExtensionsTests {

        public interface ISample { }
        public class SampleOne : ISample { }
        public class SampleTwo : ISample { }

        [Test]
        public void GetInstancesOf_GivenAInterface_ShouldCreateInstanceOfAllImplementationsOfIt() {
            var samples = Assembly.GetExecutingAssembly().GetInstancesOf<ISample>();
            var sampleOne = samples.ElementAt(0);
            var sampleTwo = samples.ElementAt(1);
            sampleOne.Should().BeOfType<SampleOne>();
            sampleTwo.Should().BeOfType<SampleTwo>();
        }
    }
}