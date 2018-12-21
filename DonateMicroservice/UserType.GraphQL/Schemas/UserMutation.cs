using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using UserType.Contracts.Interface;
using UserType.Contracts.Model;

namespace UserType.GraphQL.Schemas
{
    public class UserMutation : ObjectGraphType<object>
    {
        public UserMutation(IWriteRepository userWrite)
        {
            #region "AddUser"
            Field<UserTypes>(
                "AddUser",
                arguments: new QueryArguments
                (new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "User" }
                ),
                resolve: context =>
                {
                    var objUser = context.GetArgument<User>(Name = "User");
                    return userWrite.InsertAsync(objUser);
                });
            #endregion

            #region "UpdateUser"

            Field<UserTypes>(
                "UpdateUser",
                arguments: new QueryArguments
                (   
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "UserId" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "User" }
                ),
                resolve: context =>
                {
                    var userId = context.GetArgument<string>("Id");
                    var objUser = context.GetArgument<User>(Name = "User");
                    return userWrite.UpdateAync(userId, objUser);
                });

            #endregion
        }
    }
}
