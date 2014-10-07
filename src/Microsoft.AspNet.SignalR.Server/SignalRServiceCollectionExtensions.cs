// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


using Microsoft.AspNet.SignalR;
using Microsoft.Framework.ConfigurationModel;
using System;

namespace Microsoft.Framework.DependencyInjection
{
    public static class SignalRServiceCollectionExtensions
    {
        public static IServiceCollection AddSignalR(this IServiceCollection services, Action<SignalROptions> configureOptions = null)
        {
            if (configureOptions != null)
            {
                services.ConfigureSignalR(configureOptions);
            }
            return services.Add(SignalRServices.GetDefaultServices());
        }

        public static IServiceCollection AddSignalR(this IServiceCollection services, IConfiguration configuration, Action<SignalROptions> configureOptions = null)
        {
            if (configuration != null)
            {
                services.ConfigureOptions<SignalROptions>(configuration);
            }
            if (configureOptions != null)
            {
                services.ConfigureSignalR(configureOptions);
            }
            return services.Add(SignalRServices.GetDefaultServices(configuration));
        }

        public static IServiceCollection ConfigureSignalR(this IServiceCollection services, Action<SignalROptions> configure)
        {
            return services.ConfigureOptions(configure);
        }
    }
}
