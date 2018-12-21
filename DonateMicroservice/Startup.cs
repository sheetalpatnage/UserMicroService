using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using UserType.Common;
using UserType.Contracts.Model;
using UserType.Contracts.Interface;
using UserType.GraphQL.Schemas;
using UserType.Contracts.Repositories;
using GraphQL.Types;

namespace netcore_example
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddEntityFrameworkSqlServer().AddDbContext<UserContext>(con => Configuration.GetConnectionString(Constants.ConnectionStringName));

            services.AddSingleton<IUserReadOnlyRepository, UserRepository>();
            services.AddSingleton<IWriteRepository, UserRepository>();
            services.AddSingleton<UserTypes>();
            services.AddSingleton<UserQueries>();
            services.AddSingleton<UserMutation>();

            var sp = services.BuildServiceProvider();
            services.AddScoped<ISchema>(_ => new UserSchema(type => (GraphType)sp.GetService(type)) { Query = sp.GetService<UserQueries>() });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();       

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
