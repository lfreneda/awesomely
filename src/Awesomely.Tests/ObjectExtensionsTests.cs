using System.Drawing;
using Awesomely.Tests.Stubs;
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

        [Test]
        public void SetPropertyValue_ShouldSetAPropertyViaReflection()
        {
            var obj = new SomeClass();
            obj.SetPropertyValue("Value", "Property");
            obj.Property.Should().Be("Value");
        }

        [Test]
        public void SetFieldValue_ShouldSetAPropertyViaReflection()
        {
            var obj = new SomeClass();
            obj.SetFieldValue("Value", "_field");
            obj.GetFieldValue().Should().Be("Value");
        }

        [Test]
        public void GetPropertyValue_ShouldReturnPropertyValueViaReflection()
        {
            var obj = new SomeClass { Property = "DatValue" };
            obj.GetPropertyValue("Property").Should().Be("DatValue");
        }

        [Test]
        public void GetFieldValue_ShouldReturnFieldValueViaReflection()
        {
            var obj = new SomeClass("privateFieldValue");
            obj.GetFieldValue().Should().Be("privateFieldValue");
        }

        [Test]
        public void InvokeMethod_GivenAVoidMethodWithNoParameters()
        {
            var obj = new SomeClass();
            obj.InvokeMethod("ProtectedVoidMethodWithNoParameters");
            obj.ProtectedVoidMethodWithNoParametersCalls.Should().Be(1);
        }

        [Test]
        public void InvokeMethod_GivenAMethodWithNoParameters()
        {
            var obj = new SomeClass();
            var result = obj.InvokeMethod<string>("ProtectedMethodWithNoParameters");
            obj.ProtectedMethodWithNoParametersCalls.Should().Be(1);
            result.Should().Be("Result");
        }

        [Test]
        public void InvokeMethod_GivenAVoidMethodWithParameters()
        {
            var obj = new SomeClass();
            obj.InvokeMethod("ProtectedVoidMethodWithParameters", "ParameterValue");
            obj.ProtectedVoidMethodWithParametersCalls.Should().Be(1);
            obj.ProtectedVoidMethodWithParametersParameterValue.Should().Be("ParameterValue");
        }

        [Test]
        public void InvokeMethod_GivenAMethodWithParameters()
        {
            var obj = new SomeClass();
            var result = obj.InvokeMethod<string>("ProtectedMethodWithParameters", "ParameterValue");
            obj.ProtectedMethodWithParametersCalls.Should().Be(1);
            obj.ProtectedMethodWithParametersValue.Should().Be("ParameterValue");
            result.Should().Be("Result");
        }

    }
}
