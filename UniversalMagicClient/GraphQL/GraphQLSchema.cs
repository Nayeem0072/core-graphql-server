using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalMagicClient.Mutations;
using UniversalMagicClient.Queries;

namespace UniversalMagicClient.GraphQL
{
    public class GraphQLSchema : Schema
    {
        public GraphQLSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<AuthorQuery>();
            Mutation = resolver.Resolve<AuthorMutation>();
        }
    }
}
