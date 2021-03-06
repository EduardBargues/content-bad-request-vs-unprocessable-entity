using System;
using System.Collections.Generic;
using System.Text;

using ContentBadRequestVsUnprocessableEntity.Repositories.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace ContentBadRequestVsUnprocessableEntity.Repositories
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            return services;
        }
    }
}
