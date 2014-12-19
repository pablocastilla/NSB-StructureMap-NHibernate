
using Shared;

namespace HandlerA
{
    using Messages;
    using NServiceBus;
    using NServiceBus.UnitOfWork;
    using Service1;
    using Shared.NHibernate;
    using StructureMap;

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
                    cfg.Policies.FillAllPropertiesOfType<IService1>().Use<Service1>();
                   
                  //  cfg.Policies.FillAllPropertiesOfType<IService1>().Use<Service1>("prime");                   
                });

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
