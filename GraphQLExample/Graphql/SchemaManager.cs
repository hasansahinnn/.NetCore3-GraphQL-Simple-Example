using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLExample.Graphql
{
    public static class SchemaManager
    {
        public static ISchema GetMarketingSchema(IEnumerable<ISchema> schema) => schema.FirstOrDefault(o => o.GetType() == typeof(MarketingSchema));
        public static ISchema GetBrandSchema(IEnumerable<ISchema> schema) => schema.FirstOrDefault(o => o.GetType() == typeof(BrandSchema));
    }
}
