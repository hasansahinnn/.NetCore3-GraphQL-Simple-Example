using GraphQL;
using GraphQL.Conversion;
using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace GraphQLExample.Graphql
{

    public class MarketingSchema : Schema
    {
        public MarketingSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<MarketingQuery>();
            Subscription = resolver.Resolve<BrandQuery>(); // Add BrandQueries
        }
    }
}