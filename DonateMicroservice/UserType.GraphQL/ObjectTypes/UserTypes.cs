using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using UserType.Contracts.Model;

namespace UserType.GraphQL.Schemas
{
    public class UserTypes : ObjectGraphType<User>
    {
        public UserTypes()
        {
            Field(x => x.Id);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.EmailAddress);
            Field(x => x.PhoneNumber);
            Field(x => x.UserType);
            Field(x => x.NgoName);
            Field(x => x.Address);
        }
               

    }
}
