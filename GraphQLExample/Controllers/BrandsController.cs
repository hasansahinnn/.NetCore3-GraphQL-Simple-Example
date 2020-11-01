using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Conversion;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using GraphQLExample.Graphql;
using GraphQLExample.Helpers;
using GraphQLExample.Models;

namespace GraphQLExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseGraphQlController
    {
        public BrandsController(IEnumerable<ISchema> schema):base(schema)
        {
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphqlQueryParameter query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }

            var executionOptions = new ExecutionOptions 
            {
            
                Schema = SchemaManager.GetBrandSchema(_schema), // We choose the Schema we will use. Queries can only access Fields in the selected schema.
                Query = query.Query,  // Select Query
                Inputs = query.Variables?.ToInputs(),  // Query Paramaters
            };

            try
            {
                var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

                if (result.Errors?.Count > 0)
                {
                    return BadRequest(result);
                }

                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}