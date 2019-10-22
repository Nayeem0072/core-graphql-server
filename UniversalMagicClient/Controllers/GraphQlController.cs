using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using UniversalMagicClient.Queries;
using UniversalMagicClient.Services;
using Microsoft.AspNetCore.Mvc;
using UniversalMagicClient.Models;
using Microsoft.AspNetCore.Cors;

namespace UniversalMagicClient.Controllers
{
    [Route(Startup.GraphQlPath)]
    public class GraphQlController : Controller
    {
        readonly BlogService blogService;
        public GraphQlController(BlogService blogService)
        {
            this.blogService = blogService;
        }
        [EnableCors("MyPolicy")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQlQuery query)
        {
            var schema = new Schema { Query = new AuthorQuery(blogService) };
            var result = await new DocumentExecuter().ExecuteAsync(x =>
            {
                x.Schema = schema;
                x.Query = query.Query;
                x.Inputs = query.Variables;
            });
            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors[0].Message);
            }
            return Ok(result);
        }
    }
}
