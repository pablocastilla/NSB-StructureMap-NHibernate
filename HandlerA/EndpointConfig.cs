
using Shared;

namespace HandlerA
{
    using Messages;
    using NServiceBus;
    using NServiceBus.UnitOfWork;
    using Service1;
    using Shared.NHibernate;
    using StructureMap;
    using Domain;

    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            var container = new Container(cfg =>
                {
                    cfg.Policies.FillAllPropertiesOfType<IService1>().Use<VendorXService1>();
                    cfg.For<IService1>().Use<VendorXService1>().Named("VENDORX");
                    cfg.For<IService1Factory>().Use<Service1Factory>();                   
                  
                });

            configuration.SetDefaultDomainConfiguration(container);
            configuration.SetDefaultConfiguration(container);
            
        }
    }

    public class MyClass : IWantToRunWhenBusStartsAndStops
      {
          public IBus Bus { get; set; }

          public void Start()
          {               
              RunSamples();
          }

          private void RunSamples()
          {
              Bus.Send("HandlerA",new CommandA
              {
                  
              });
          }


          public void Stop()
          {

          }
      }
}
