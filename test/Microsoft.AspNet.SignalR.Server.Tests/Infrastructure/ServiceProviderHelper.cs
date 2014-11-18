﻿using System;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.DependencyInjection.Fallback;
using Microsoft.Framework.Logging;
using Microsoft.Framework.OptionsModel;
using Microsoft.Framework.Runtime.Infrastructure;

namespace Microsoft.AspNet.SignalR.Tests
{
    /// <summary>
    /// Summary description for ServiceProviderHelper
    /// </summary>
    public class ServiceProviderHelper
    {
        public static IServiceProvider CreateServiceProvider()
        {
            return CreateServiceProvider(_ => { });
        }

        public static IServiceProvider CreateServiceProvider(Action<IServiceCollection> configure)
        {
            var collection = new ServiceCollection()
                .Import(CallContextServiceLocator.Locator.ServiceProvider)
                .Add(OptionsServices.GetDefaultServices())
                .Add(HostingServices.GetDefaultServices())
                .Add(SignalRServices.GetDefaultServices());

            configure(collection);

            return collection.BuildServiceProvider();
        }
    }
}