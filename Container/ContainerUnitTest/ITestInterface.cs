using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerUnitTest
{
    interface ITestInterface
    {
        ITestService Service { get; }
    }
}
