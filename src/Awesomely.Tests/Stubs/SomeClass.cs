using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Awesomely.Tests.Stubs
{

    public class SomeClass
    {

        public string Property { get; set; }
        private string _field;

        public SomeClass(string field = null)
        {
            _field = field;
        }

        public SomeClass()
        {
        }


        public string GetFieldValue()
        {
            return _field;
        }


        public int ProtectedVoidMethodWithNoParametersCalls { get; set; }
        protected void ProtectedVoidMethodWithNoParameters()
        {
            ProtectedVoidMethodWithNoParametersCalls++;
        }

        public int ProtectedMethodWithNoParametersCalls { get; set; }
        protected string ProtectedMethodWithNoParameters()
        {
            ProtectedMethodWithNoParametersCalls++;
            return "Result";
        }

        public string ProtectedMethodWithParametersValue { get; set; }
        public int ProtectedMethodWithParametersCalls { get; set; }
        protected string ProtectedMethodWithParameters(string parameter)
        {
            ProtectedMethodWithParametersValue = parameter;
            ProtectedMethodWithParametersCalls++;
            return "Result";
        }

        public int ProtectedVoidMethodWithParametersCalls { get; set; }
        public string ProtectedVoidMethodWithParametersParameterValue { get; set; }
        protected void ProtectedVoidMethodWithParameters(string parameter)
        {
            ProtectedVoidMethodWithParametersParameterValue = parameter;
            ProtectedVoidMethodWithParametersCalls++;
        }

    }
}
