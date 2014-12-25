using System;
using Domain;
using HandlerA;
using Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NServiceBus;
using NServiceBus.Testing;
using NServiceBus.UnitOfWork;
using Service1;
using Shared;
using Shared.NHibernate;
using StructureMap;
using UnitTests.Utils;

namespace UnitTests
{
    [TestClass]
    public class HandlerA_UnitTests
    {
        /// <summary>
        /// Test using a SQLite file database for testing.
        /// </summary>
        [TestMethod]
        public void HandlerATest()
        {
            var nameToInsert = "Paco";

            //the dependencies are created.
            var domainTestSessionFactoryCreator = new DomainSessionFactoryTestCreator();
            IDomainUnitOfWork domainUoW =  new DomainUnitOfWork(domainTestSessionFactoryCreator);
            
            Test.Initialize();

            Test.Handler<CommandAHandler>(
                b => new CommandAHandler(domainUoW
                   , b, new Service1Factory(domainUoW, b)))
                .OnMessage(new CommandA() { Name = nameToInsert });

            var result = domainUoW.GetARepository().GetAsByName(nameToInsert);
          
            Assert.IsTrue(result.Count>0);
        }
    }
}
