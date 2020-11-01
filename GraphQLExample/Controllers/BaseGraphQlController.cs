using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLExample.Controllers
{
    public class BaseGraphQlController : ControllerBase
    {
        public readonly DocumentExecuter _documentExecuter = new DocumentExecuter();
        public readonly IEnumerable<ISchema> _schema;
        public BaseGraphQlController(IEnumerable<ISchema> schema)
        {
            _schema = schema ;
        }
    }
}
