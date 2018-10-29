using Container;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerUnitTest
{
    [TestClass]
    public class ContainerTests
    {
        private StandardContainer GetContainer(bool isSingletoneScope)
        {
            var container = new StandardContainer();

            if (isSingletoneScope)
            {
     
                container.Bind<ITestInterface>().To<TestClass>().InSingletoneScope();
                container.Bind<ITestService>().To<TestService>().InSingletoneScope();
            }
            else
            {
                container.Bind<ITestInterface>().To<TestClass>();
                container.Bind<ITestService>().To<TestService>();
            }

            return container;
        }
    
        [TestMethod]
        public void ContainerTest()
        {
          
            if(GetContainer(false).TryGet<ITestInterface>(out var entity))
            {
                Assert.IsTrue(entity is TestClass);
                Assert.IsTrue(entity.Service is TestService);
            }
            else
            {
                Assert.Fail("Container can't obj");
            }
        }
        [TestMethod]
        public void SingletoneContainerTest()
        {
            var container = GetContainer(true);
            if (container.TryGet<ITestInterface>(out var entity))
            {
                if(container.TryGet<ITestService>(out var service))
                {
                    Assert.IsTrue(entity.Service == service);
                }
            }
            else
            {
                Assert.Fail("Container can't obj");
            }
        }
        [TestMethod]
        public void ConstantContainerTest()
        {
            var container = new StandardContainer();
            var testClass = new TestClass(new TestService());
            container.Bind<ITestInterface>().ToConstant(testClass);
            if(container.TryGet<ITestInterface>(out var entity))
            {
                Assert.IsTrue(entity == testClass);
            }
            else
            {
                Assert.Fail("Container can't get obj");
            }
        }
    }
}
