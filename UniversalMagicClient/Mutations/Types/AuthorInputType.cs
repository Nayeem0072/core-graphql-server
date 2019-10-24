using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversalMagicClient.Queries.Types
{
    public class AuthorInputType: InputObjectGraphType
    {
        public AuthorInputType()
        {
            Name = "authorInput";
            Field<NonNullGraphType<StringGraphType>>("Id");
            Field<NonNullGraphType<StringGraphType>>("Name");
            Field<NonNullGraphType<StringGraphType>>("Bio");
            Field<NonNullGraphType<StringGraphType>>("ImgUrl");
            Field<NonNullGraphType<StringGraphType>>("ProfileUrl");
        }
    }
}
