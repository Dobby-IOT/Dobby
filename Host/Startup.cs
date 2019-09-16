using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate.AspNetCore;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.AspNetCore.Authorization;

namespace Dobby.Host
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInMemorySubscriptionProvider();

            services.AddDataLoaderRegistry();

            // Add GraphQL Services
            services.AddGraphQL(sp => SchemaBuilder.New()
                .AddDirectiveType<AuthorizeDirectiveType>()
                .AddQueryType<Query>()
                .Create());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UsePlayground();
            }

            app.UseWebSockets();
            app.UseGraphQL();
        }
    }
}
