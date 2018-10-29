using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerUnitTest
{
    class TestClass : ITestInterface
    {
        public TestClass(ITestService service)
        {
            Service = service;
        }

        public ITestService Service { get; }
    }
}
