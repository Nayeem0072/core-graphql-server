using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalMagicClient.Entities;
using UniversalMagicClient.Queries.Types;
using UniversalMagicClient.Services;

namespace UniversalMagicClient.Mutations
{
    public class AuthorMutation : ObjectGraphType
    {
        public AuthorMutation(IBlogService blogService)
        {
            Name = "Mutation";
            Field<AuthorType>(
                "createAuthor",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AuthorInputType>> { Name = "author" }
                    ),
                resolve: context =>
                {
                    var author = context.GetArgument<Author>("author");
                    return blogService.CreateAuthor(author);
                }
            );
        }
    }
}
