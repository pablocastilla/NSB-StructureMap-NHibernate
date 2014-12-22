using System;
using HandlerA;
using Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NServiceBus;
using NServiceBus.Testing;
using NServiceBus.UnitOfWork;
using Shared;
using Shared.NHibernate;
using StructureMap;

namespace UnitTests
{
    [TestClass]
    public class HandlerA_UnitTests
    {
        [TestMethod]
        public void HandlerATest()
        {
            //http://ayende.com/blog/3983/nhibernate-unit-testing

            var privateObject = new PrivateObject(typeof(UnitOfWork));

            var container = new Container(cfg =>
            {             
                cfg.For<IManageUnitsOfWork>().Use<NSBUnitOfWorkManager>();
                cfg.Policies.FillAllPropertiesOfType<IUnitOfWork>().Use<UnitOfWork>();


            });

            Test.Initialize();

            
            //Test.Handler<CommandAHandler>(b=> new CommandAHandler(null)).OnMessage<CommandA>(); 
        }
    }
}
