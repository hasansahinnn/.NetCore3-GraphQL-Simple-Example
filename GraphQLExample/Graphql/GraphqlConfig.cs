using GraphiQl;
using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using GraphQLExample.Graphql.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLExample.Graphql
{
    public static class GraphqlConfig
    {
        public static IServiceCollection addGraphqlConfig(this IServiceCollection services)
        {
            // add graph types
            services.AddSingleton<MaterialType>();
            services.AddSingleton<BrandType>();
            services.AddSingleton<InputBrandType>();

            // add graph queries
            services.AddSingleton<MarketingQuery>();
            services.AddSingleton<BrandQuery>();
            services.AddSingleton<BrandMutation>();

            // add graph schemas
            services.AddSingleton<ISchema, MarketingSchema>();
            services.AddSingleton<ISchema, BrandSchema>();

            // add resolver injection
            services.AddSingleton<IDependencyResolver>(_ => new FuncDependencyResolver(_.GetRequiredService));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = true;
            }).AddGraphTypes(ServiceLifetime.Scoped).AddDataLoader();
        

            return services; 
        }
    }
}
