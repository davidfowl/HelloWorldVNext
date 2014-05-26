using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting.Server;
using Microsoft.AspNet.Owin;
using Microsoft.Framework.ConfigurationModel;
 
namespace Nowin.vNext
{
    public class NowinServerFactory : IServerFactory
    {
        private Func<object, Task> _callback;
 
        private Task HandleRequest(IDictionary<string, object> env)
        {
            return _callback(new OwinFeatureCollection(env));
        }
 
        public IServerInformation Initialize(IConfiguration configuration)
        {
            // TODO: Parse config
            var builder = ServerBuilder.New()
                                       .SetAddress(IPAddress.Any)
                                       .SetPort(8080)
                                       .SetOwinApp(HandleRequest);
 
            return new NowinServerInformation(builder);
        }
 
        public IDisposable Start(IServerInformation serverInformation, Func<object, Task> application)
        {
            var information = (NowinServerInformation)serverInformation;
            _callback = application;
            INowinServer server = information.Builder.Build();
            server.Start();
            return server;
        }
 
        private class NowinServerInformation : IServerInformation
        {
            public NowinServerInformation(ServerBuilder builder)
            {
                Builder = builder;
            }
 
            public ServerBuilder Builder { get; private set; }
 
            public string Name
            {
                get
                {
                    return "Nowin";
                }
            }
        }
    }
}