using System;
using System.Collections.Generic;
using System.Text;

using ContentBadRequestVsUnprocessableEntity.Services.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace ContentBadRequestVsUnprocessableEntity.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProcessService, ProcessService>();
            return services;
        }
    }
}
