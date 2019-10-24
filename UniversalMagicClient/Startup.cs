using GraphiQl;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversalMagicClient.GraphQL;
using UniversalMagicClient.Mutations;
using UniversalMagicClient.Queries;
using UniversalMagicClient.Queries.Types;
using UniversalMagicClient.Services;

namespace UniversalMagicClient
{
    public class Startup
    {
        public const string GraphQlPath = "/graphql";
        

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.AddScoped<BlogService>();            

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSingleton<IDependencyResolver>(s => new
                FuncDependencyResolver(s.GetRequiredService));

            services.AddSingleton<IBlogService, BlogService>();
            services.AddSingleton<ISchema, GraphQLSchema>();

            services.AddSingleton<AuthorQuery>();
            services.AddSingleton<AuthorMutation>();

            services.AddSingleton<AuthorType>();
            services.AddSingleton<CommentType>();
            services.AddSingleton<PostType>();
            services.AddSingleton<RatingType>();
            services.AddSingleton<SocialNetworkType>();

            services.AddSingleton<AuthorInputType>();

            services.AddGraphQL();



        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            //app.UseGraphiQl(GraphQlPath);
            app.UseCors("MyPolicy");

            app.UseGraphQL<ISchema>("/graphql");

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/ui/playground"
            });

        }
    }
}
