using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace UserType.GraphQL.Schemas
{
    public class UserSchema : Schema
    {
        public UserSchema(Func<Type, GraphType> resolve) : base(resolve)
        {
            Query = (UserQueries)resolve(typeof(UserQueries));
            Mutation = (UserMutation)resolve(typeof(UserMutation));
        }
    }
}
