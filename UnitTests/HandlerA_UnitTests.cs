using System;
using Domain;
using HandlerA;
using Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
       /// Unit test using Moq
       /// </summary>
        [TestMethod]
        public void HandlerAUnitTestUsingMocks()
        {
            var nameToInsert = "Paco";

            //the dependencies are created.
            var service1Mock = new Mock<IService1>();
            service1Mock.Setup(s1 => s1.DoSomething(It.IsAny<string>()));
            
            var service1FactoryMock = new Mock<IService1Factory>();
            service1FactoryMock.Setup(sf1 => sf1.CreateService(It.IsAny<string>())).Returns(service1Mock.Object); 

            Test.Initialize();

            //calls to handler
            Test.Handler<CommandAHandler>(
                b => new CommandAHandler(b, service1FactoryMock.Object))
                .OnMessage(new CommandA() { Name = nameToInsert });


            //Verifies that the mock has been invoked.
            service1Mock.Verify(s1 => s1.DoSomething(It.IsAny<string>()),Times.Once);

                      
        }


        /// <summary>
        /// Test using a SQLite file database for testing.
        /// </summary>
        [TestMethod]
        public void HandlerAIntegrationTestUsingSQLite()
        {
            var nameToInsert = "Paco";

            //the dependencies are created using a special Session Factory for SQLite
            var domainTestSessionFactoryCreator = new DomainSessionFactoryTestCreator();
            IDomainUnitOfWork domainUoW = new DomainUnitOfWork(domainTestSessionFactoryCreator);

            Test.Initialize();

            Test.Handler<CommandAHandler>(
                b => new CommandAHandler(b, new Service1Factory(domainUoW, b)))
                .OnMessage(new CommandA() { Name = nameToInsert });

            var result = domainUoW.GetARepository().GetAsByName(nameToInsert);

            Assert.IsTrue(result.Count > 0);
        }
    }
}
