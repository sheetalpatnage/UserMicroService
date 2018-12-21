using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using UserType.Contracts.Interface;


 namespace UserType.GraphQL.Schemas
{
    public class UserQueries : ObjectGraphType<object>
    {
        public UserQueries(IUserReadOnlyRepository IUserRead)
        {
            Field<UserTypes>(
                "GetAllUser",
                resolve: context => IUserRead.FindAllAsync()
                );

            Field<UserTypes>(
                "GetById",
                    arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "Id" }),
                   resolve: context => IUserRead.GetByIdAsync(context.GetArgument<string>("ProductId"))
                );            
       
                
            }
        }

    }

