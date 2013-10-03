using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Awesomely.Tests.Stubs {
    
    public class SomeClass {

        public string Property { get; set; }
        private string _field;

        public SomeClass(string field = null)
        {
            _field = field;
        }

        public string GetFieldValue() {
            return _field;
        }
    }
}
